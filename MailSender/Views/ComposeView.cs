using System.ComponentModel;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailSender.Controls;
using MailSender.Forms;
using MailSender.Models;
using MailSender.Services;
using MimeKit;

namespace MailSender.Views
{
    /// <summary>
    /// "메일 작성" 화면. 받는 사람/제목/내용 입력, 양식 불러오기, 첨부파일 구분 선택,
    /// 메일 전송, 전송 결과의 DB 이력 저장까지 담당한다.
    /// </summary>
    public partial class ComposeView : UserControl, IRefreshable
    {
        /// <summary>메일 한 통에 첨부할 수 있는 최대 용량 (20MB). 넘으면 여러 통으로 나눠 보낸다.</summary>
        private const long MaxAttachmentBytes = 20L * 1024 * 1024;

        /// <summary>지금 체크되어 있는 첨부파일 구분의 DB 번호들</summary>
        private readonly HashSet<long> _selected = new();

        /// <summary>
        /// 화면을 만들고, 양식/첨부파일이 바뀌면 자동으로 새로 읽도록 연결한다.
        /// </summary>
        public ComposeView()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            AppEvents.TemplatesChanged += LoadTemplates;
            AppEvents.CategoriesChanged += LoadCategories;
        }

        /// <summary>
        /// 화면이 보여질 때 양식과 첨부파일 구분을 DB에서 새로 읽는다.
        /// </summary>
        public void RefreshView()
        {
            LoadTemplates();
            LoadCategories();
        }

        /// <summary>
        /// 글자 길이에 맞는 폭의 알약(Chip) 버튼을 만든다. (양식/구분 버튼 공통)
        /// </summary>
        private static UiButton MakeChip(string text, bool checkable)
        {
            var font = new Font("맑은 고딕", 9.5F, FontStyle.Bold);
            int width = TextRenderer.MeasureText(text, font).Width + 34;

            return new UiButton
            {
                Kind = ButtonKind.Chip,
                Text = text,
                Font = font,
                Checkable = checkable,
                Size = new Size(Math.Max(64, width), 34),
                Margin = new Padding(0, 0, 8, 8),
            };
        }

        /// <summary>
        /// 안내 문구 한 줄짜리 라벨을 만든다. (등록된 항목이 없을 때 표시)
        /// </summary>
        private static Label MakeHint(string text) => new()
        {
            Text = text,
            AutoSize = true,
            ForeColor = Ui.Muted,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 8, 0, 0),
        };

        /// <summary>
        /// DB의 메일 양식을 읽어서 "양식 불러오기" 버튼들로 표시한다. 누르면 제목/내용이 채워진다.
        /// </summary>
        private void LoadTemplates()
        {
            AppServices.Templates.Load();
            flowTpl.Controls.Clear();

            foreach (var template in AppServices.Templates.Templates)
            {
                var chip = MakeChip(template.Name, false);
                chip.Click += (_, _) =>
                {
                    txtSubject.Text = template.Title;
                    txtBody.Text = template.Content;
                    ToastForm.Show(this, "양식을 불러왔어요");
                };
                flowTpl.Controls.Add(chip);
            }

            if (AppServices.Templates.Templates.Count == 0)
            {
                flowTpl.Controls.Add(MakeHint("등록된 양식이 없어요. 관리 > 메일 양식에서 추가해 보세요."));
            }
        }

        /// <summary>
        /// DB의 첨부파일 구분을 읽어서 선택 가능한 버튼들로 표시한다.
        /// </summary>
        private void LoadCategories()
        {
            AppServices.Categories.Load();
            flowCats.Controls.Clear();

            // 삭제된 구분이 선택 목록에 남아 있지 않도록 정리한다.
            _selected.RemoveWhere(id => AppServices.Categories.Categories.All(c => c.Id != id));

            foreach (var category in AppServices.Categories.Categories)
            {
                var chip = MakeChip(category.Name, true);
                chip.Checked = _selected.Contains(category.Id);
                chip.CheckedChanged += (_, _) =>
                {
                    if (chip.Checked) _selected.Add(category.Id); else _selected.Remove(category.Id);
                    RenderFiles();
                };
                flowCats.Controls.Add(chip);
            }

            if (AppServices.Categories.Categories.Count == 0)
            {
                flowCats.Controls.Add(MakeHint("등록된 구분이 없어요. 관리 > 첨부파일에서 먼저 등록해 주세요."));
            }

            RenderFiles();
        }

        /// <summary>
        /// 선택한 구분들의 첨부파일을 하나의 목록으로 합친다. 같은 내용의 파일은 한 번만 포함한다.
        /// </summary>
        private List<AttachmentFile> GetSelectedFiles()
        {
            return AppServices.Categories.Categories
                .Where(c => _selected.Contains(c.Id))
                .SelectMany(c => c.Files)
                .DistinctBy(f => f.FileHash)
                .ToList();
        }

        /// <summary>
        /// 선택된 첨부파일을 카드 형태로 그리고, 아래 요약(개수/용량)도 갱신한다.
        /// </summary>
        private void RenderFiles()
        {
            flowFiles.Controls.Clear();
            var files = GetSelectedFiles();

            if (files.Count == 0)
            {
                flowFiles.Controls.Add(MakeHint("구분을 선택하면 첨부파일이 여기에 표시돼요."));
            }

            foreach (var file in files)
            {
                flowFiles.Controls.Add(MakeFileTile(file));
            }

            long total = files.Sum(f => f.FileSize);
            int parts = Math.Max(1, (int)Math.Ceiling(total / (double)MaxAttachmentBytes));

            lblSummary.Text = $"첨부 {files.Count}개  ·  {FormatSize(total)}" +
                              (parts > 1 ? $"  ·  용량이 커서 {parts}통으로 나눠 전송돼요" : "");
        }

        /// <summary>
        /// 첨부파일 한 개를 보여줄 작은 카드(확장자 배지 + 파일명 + 크기)를 만든다.
        /// 파일 개수가 실행 중에 달라지므로 코드로 생성한다.
        /// </summary>
        private static UiCard MakeFileTile(AttachmentFile file)
        {
            string ext = Path.GetExtension(file.FileName).TrimStart('.').ToUpperInvariant();
            if (ext.Length == 0) ext = "FILE";
            if (ext.Length > 4) ext = ext[..4];

            Color badge = ext == "PDF" ? Color.FromArgb(0xE5, 0x48, 0x4D)
                        : ext is "JPG" or "JPEG" or "PNG" or "GIF" or "BMP" ? Color.FromArgb(0x3B, 0x82, 0xF6)
                        : Color.FromArgb(0x6B, 0x72, 0x80);

            var card = new UiCard
            {
                Size = new Size(150, 100),
                FillColor = Ui.Surface2,
                Margin = new Padding(0, 0, 10, 10),
                Radius = 12,
            };

            card.Controls.Add(new Label
            {
                Text = ext, ForeColor = Color.White, BackColor = badge, TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("맑은 고딕", 8F, FontStyle.Bold), Location = new Point(12, 12), Size = new Size(42, 26),
            });
            card.Controls.Add(new Label
            {
                Text = file.FileName, AutoEllipsis = true, BackColor = Color.Transparent, ForeColor = Ui.Text,
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold), Location = new Point(12, 46), Size = new Size(128, 20),
            });
            card.Controls.Add(new Label
            {
                Text = FormatSize(file.FileSize), BackColor = Color.Transparent, ForeColor = Ui.Muted,
                Font = new Font("맑은 고딕", 8.5F), Location = new Point(12, 68), Size = new Size(128, 18),
            });

            return card;
        }

        /// <summary>
        /// byte 크기를 KB / MB처럼 읽기 쉬운 글자로 바꾼다.
        /// </summary>
        private static string FormatSize(long bytes)
        {
            if (bytes >= 1024 * 1024) return $"{bytes / 1024.0 / 1024.0:N1} MB";
            if (bytes >= 1024) return $"{bytes / 1024.0:N0} KB";
            return $"{bytes} B";
        }

        /// <summary>
        /// "메일 전송" 버튼 클릭. 입력 검증 → 확인 → (백그라운드) SMTP 전송 → DB 이력 저장 → 결과 알림 순서로 처리한다.
        /// 전송 중에도 화면이 멈추지 않도록 await를 사용한다.
        /// </summary>
        private async void btnSend_Click(object? sender, EventArgs e)
        {
            string to = txtTo.Text.Trim();
            string title = txtSubject.Text.Trim();
            string content = string.IsNullOrWhiteSpace(txtBody.Text) ? " " : txtBody.Text;

            if (to.Length == 0) { ToastForm.Show(this, "받는 사람 메일을 입력해 주세요", true); txtTo.Inner.Focus(); return; }
            if (title.Length == 0) { ToastForm.Show(this, "메일 제목을 입력해 주세요", true); txtSubject.Inner.Focus(); return; }

            MailAccountSetting account;
            try
            {
                account = MailAccountStore.Load();
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "메일 설정 오류", ex.Message);
                return;
            }

            if (string.IsNullOrWhiteSpace(account.MailId) || string.IsNullOrWhiteSpace(account.Password))
            {
                ToastForm.Show(this, "메일 계정을 먼저 등록해 주세요", true);
                AppEvents.Navigate("manage", "acc");
                return;
            }

            var files = GetSelectedFiles();
            if (files.Count == 0) { ToastForm.Show(this, "첨부파일이 없어요. 구분을 선택해 주세요", true); return; }

            // 용량이 크면 20MB 이내씩 묶어서 여러 통으로 나눈다.
            var groups = SplitAttachmentsBySize(files, MaxAttachmentBytes);

            string detail = $"받는 사람   {to}\n제목   {title}\n첨부   {files.Count}개" +
                            (groups.Count > 1 ? $"  ({groups.Count}통으로 분할)" : "");
            if (!Dialogs.Confirm(FindForm()!, "메일을 전송할까요?", detail, "전송")) return;

            btnSend.Enabled = false;
            btnSend.Text = "전송 중...";

            try
            {
                // SMTP 전송은 시간이 걸리므로 다른 스레드에서 처리한다.
                var (sent, error) = await Task.Run(() => SendAll(account, to, title, content, groups));

                if (error == null)
                {
                    SaveMailHistory(to, title, content, groups, "성공", "");
                    ToastForm.Show(this, groups.Count > 1 ? $"{groups.Count}통으로 나눠 전송했어요" : "메일을 전송했어요");
                }
                else
                {
                    SaveMailHistory(to, title, content, groups, "실패", $"{groups.Count}통 중 {sent}통 전송 후 오류: {error.Message}");
                    ShowSendError(error);
                }
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "메일 전송";
            }
        }

        /// <summary>
        /// 메일 서버에 연결해서 그룹 수만큼 메일을 차례로 전송한다. (백그라운드 스레드에서 실행)
        /// </summary>
        /// <returns>전송에 성공한 통수와, 오류가 났다면 그 오류(없으면 null)</returns>
        private (int Sent, Exception? Error) SendAll(MailAccountSetting account, string to, string title,
            string content, List<List<AttachmentFile>> groups)
        {
            int sent = 0;

            try
            {
                using var smtp = new SmtpClient();
                smtp.Connect(account.MailServer, account.SmtpPort, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(account.MailId, account.Password);

                for (int i = 0; i < groups.Count; i++)
                {
                    using var message = BuildMailMessage(account, to, title, content, groups[i], i + 1, groups.Count);
                    smtp.Send(new SmtpSendRequest(message));
                    sent++;
                }

                smtp.Disconnect(true);
                return (sent, null);
            }
            catch (Exception ex)
            {
                return (sent, ex);
            }
        }

        /// <summary>
        /// 전송 오류의 종류에 맞는 안내 창을 보여준다. (차단된 첨부 형식 / 일반 오류)
        /// </summary>
        private void ShowSendError(Exception error)
        {
            string msg = error.Message?.ToLower() ?? "";

            if (error is SmtpCommandException && (msg.Contains("restricted") || msg.Contains("blocked")))
            {
                Dialogs.Info(FindForm()!, "첨부파일이 차단됐어요",
                    "관리자가 차단한 파일 형식(압축파일, 실행파일 등)이 포함되어 있어 메일 서버가 전송을 거부했습니다.\n압축파일이나 실행파일을 제외하고 다시 시도해 주세요.");
            }
            else
            {
                Dialogs.Info(FindForm()!, "메일 전송 오류",
                    $"{error.Message}\n\n(메일의 용량이 너무 큰 경우에도 발생할 수 있습니다.)");
            }
        }

        /// <summary>
        /// 메일 전송 결과(받는사람, 제목, 내용, 첨부파일명, 원본경로)를 DB에 저장한다.
        /// 이력 저장이 실패해도 메일 전송에는 영향이 없으므로 안내만 보여준다.
        /// </summary>
        private void SaveMailHistory(string to, string title, string content,
            List<List<AttachmentFile>> groups, string status, string errorMessage)
        {
            try
            {
                var record = new MailHistoryRecord
                {
                    Recipient = to, Subject = title, Body = content, Status = status,
                    ErrorMessage = errorMessage, MailCount = groups.Count,
                };

                for (int i = 0; i < groups.Count; i++)
                {
                    foreach (var file in groups[i])
                    {
                        record.Attachments.Add(new MailHistoryAttachment
                        {
                            MailIndex = i + 1, FileName = file.FileName,
                            FilePath = file.OriginalPath, FileSize = file.FileSize,
                        });
                    }
                }

                MailHistoryStore.Save(record);
                AppEvents.RaiseHistoryChanged();
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "이력 저장 오류", $"메일 전송 이력을 DB에 저장하지 못했습니다.\n\n{ex.Message}");
            }
        }

        /// <summary>
        /// 첨부파일 목록을 한 그룹(=메일 한 통)이 maxBytes를 넘지 않도록 여러 그룹으로 나눈다.
        /// 파일 하나가 maxBytes보다 커도 그 파일은 단독 그룹으로 보낸다.
        /// </summary>
        private static List<List<AttachmentFile>> SplitAttachmentsBySize(List<AttachmentFile> files, long maxBytes)
        {
            var groups = new List<List<AttachmentFile>>();
            var current = new List<AttachmentFile>();
            long currentSize = 0;

            foreach (var file in files)
            {
                if (current.Count > 0 && currentSize + file.FileSize > maxBytes)
                {
                    groups.Add(current);
                    current = new List<AttachmentFile>();
                    currentSize = 0;
                }

                current.Add(file);
                currentSize += file.FileSize;
            }

            if (current.Count > 0) groups.Add(current);
            return groups;
        }

        /// <summary>
        /// 실제로 전송할 메일 한 통(제목 + 본문 + 첨부파일)을 만든다. 첨부파일 내용은 DB에서 읽는다.
        /// 여러 통이면 제목 뒤에 "(1/3)"처럼 순번을 붙인다.
        /// </summary>
        private static MimeMessage BuildMailMessage(MailAccountSetting account, string to, string title, string content,
            List<AttachmentFile> files, int index, int total)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(account.SenderName, account.MailId));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = total > 1 ? $"{title} ({index}/{total})" : title;

            var multipart = new Multipart("mixed");
            multipart.Add(new TextPart("plain") { Text = content });

            foreach (var file in files)
            {
                byte[] data = AppServices.Categories.GetFileData(file.Id);

                multipart.Add(new MimePart
                {
                    Content = new MimeContent(new MemoryStream(data)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = file.FileName,
                });
            }

            message.Body = multipart;
            return message;
        }
    }
}
