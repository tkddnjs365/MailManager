using MailSender.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace MailSender.Services
{
    public static class InvoicePdfService
    {
        /// <summary>
        /// 거래명세서 데이터로 새 PDF 파일을 만들고, 만들어진 파일의 전체 경로를 반환한다.
        /// 호출할 때마다 새 파일이 만들어지며 기존 PDF는 그대로 유지된다.
        /// </summary>
        public static string GeneratePdf(InvoiceData data)
        {
            AppPaths.EnsureFolders();
            var baseName = $"거래명세서_{DateTime.Now:yyyyMMdd_HHmmss}";
            var fullPath = Path.Combine(AppPaths.InvoiceFolder, baseName + ".pdf");

            // 같은 이름의 PDF가 이미 있으면 덮어쓰지 않고 (2), (3)... 을 붙여서 새 파일로 만든다.
            for (var n = 2; File.Exists(fullPath); n++)
            {
                fullPath = Path.Combine(AppPaths.InvoiceFolder, $"{baseName}({n}).pdf");
            }

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(24);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("맑은 고딕"));

                    page.Content().Column(col =>
                    {
                        // 상단 제목 부
                        col.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(0.2f);
                                c.RelativeColumn(0.2f);
                                c.RelativeColumn(1.3f);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(0.5f).AlignMiddle().AlignRight().PaddingRight(2).Text("권").FontSize(15).Bold();
                                header.Cell().Border(0.5f).AlignMiddle().AlignRight().PaddingRight(2).Text("호").FontSize(15).Bold();
                                header.Cell().Border(0.5f).AlignMiddle().AlignLeft().PaddingLeft(40).Text("거 래 명 세 표").FontSize(22).Bold();
                            });
                        });


                        // 중간부
                        col.Item().PaddingTop(0).Row(row =>
                        {
                            row.RelativeItem(4.5f).Row(inner =>
                            {
                                inner.RelativeItem().Column(c =>
                                {
                                    InfoValueRow(c, $"{data.Date}", 11);
                                    c.Item().Height(25).Border(0.5f).Row(r =>
                                    {
                                        r.RelativeItem().AlignCenter().AlignMiddle().Text(data.BuyerName).FontSize(11).Bold();

                                        r.ConstantItem(50).PaddingRight(10).AlignRight().AlignMiddle().Text("귀하").FontSize(11).Bold();
                                    });
                                    InfoValueRow(c, "아래와 같이 계산합니다.", 11, true);
                                    InfoValueRow(c, "(\\ " + $"{data.Amt}" + " )", 11, true, true);
                                });
                            });

                            row.RelativeItem(6.5f).Row(inner =>
                            {
                                inner.ConstantItem(25).Background(Colors.Grey.Lighten3).Border(0.5f).AlignCenter().AlignMiddle().Text("공\n급\n자").FontSize(12);

                                inner.RelativeItem().Column(c =>
                                {
                                    InfoRow(c, "사업자등록번호", data.RegNo, 11);
                                    //InfoRow(c, "상호(법인명)", data.CompanyName, 11, "성명", data.CeoName + "  (인)");
                                    InfoRow(c, "상호(법인명)", data.CompanyName, 11, "성명", data.CeoName,
                                        showSeal: data.SealImage is { Length: > 0 }, sealImage: data.SealImage);
                                    InfoRow(c, "사업장 주소", data.Address, 11);
                                    InfoRow(c, "업태", data.BizType, 11, "종목", data.BizItem);
                                });
                            });
                        });

                        col.Item().PaddingTop(0).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(0.1f);
                                c.RelativeColumn(1.3f);
                                c.RelativeColumn(0.2f);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(0.5f).AlignMiddle().AlignCenter().PaddingLeft(2).PaddingRight(2).Text("합계\n금액").FontSize(11);
                                header.Cell().Border(0.5f).BorderRight(0).AlignMiddle().AlignLeft().PaddingLeft(10).Text($"{NumberToKorean(long.Parse(data.Amt.Replace(",", "")))}").FontSize(11).Bold();
                                header.Cell().BorderRight(0.5f).BorderTop(0.5f).BorderBottom(0.5f).AlignMiddle().AlignRight().PaddingRight(10).Text("원정").FontSize(11);
                            });
                        });


                        col.Item().PaddingTop(0).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(1.3f);
                                c.RelativeColumn(3);
                                c.RelativeColumn(1.6f);
                                c.RelativeColumn(1.3f);
                                //c.RelativeColumn(1.8f);
                                c.RelativeColumn(2.2f);
                                c.RelativeColumn(1.8f);
                            });

                            table.Header(header =>
                            {
                                foreach (var h in new[] { "일 자", "품 명", "규 격", "기 타", "공 급 가 액", "세 액" })
                                {
                                    header.Cell().Border(0.5f).Background(Colors.Grey.Lighten3)
                                        .AlignCenter().Padding(5).Text(h).FontSize(9).Bold();
                                }
                            });

                            foreach (var item in data.Items)
                            {
                                decimal.TryParse(item.Amt, out var AmtVal);
                                table.Cell().Border(0.5f).Padding(5).Text(item.Date).FontSize(9);
                                table.Cell().Border(0.5f).Padding(5).Text(item.Name).FontSize(9);
                                table.Cell().Border(0.5f).Padding(5).AlignCenter().Text(item.Spec).FontSize(9);
                                table.Cell().Border(0.5f).Padding(5).AlignCenter().Text(item.Etc).FontSize(9);
                                //table.Cell().Border(0.5f).Padding(5).AlignRight().Text(item.UnitPrice).FontSize(9);
                                table.Cell().Border(0.5f).Padding(5).AlignRight()
                                    .Text(AmtVal > 0 ? AmtVal.ToString("N0") : "").FontSize(9);
                                table.Cell().Border(0.5f).Padding(5).AlignRight().Text(item.TaxAmount).FontSize(9);
                            }

                            var blankRows = Math.Max(0, 20 - data.Items.Count);
                            for (var i = 0; i < blankRows; i++)
                            {
                                for (var c = 0; c < 6; c++)
                                {
                                    table.Cell().Border(0.5f).Padding(5).Text(" ").FontSize(9);
                                }
                            }

                            //table.Cell().ColumnSpan(4).Border(0.5f).Background(Colors.Grey.Lighten3)
                            //    .AlignCenter().Padding(5).Text("계").FontSize(9).Bold();
                            //table.Cell().Border(0.5f).Padding(5).AlignRight()
                            //    .Text(data.SupplyTotal.ToString("N0")).FontSize(9).Bold();
                            //table.Cell().Border(0.5f).Padding(5).AlignRight()
                            //    .Text(data.TaxTotal.ToString("N0")).FontSize(9).Bold();
                        });

                        //col.Item().Border(1).Background(Colors.Grey.Lighten4).Padding(10).AlignCenter().Row(row =>
                        //{
                        //    row.AutoItem().Text("합    계        ").FontSize(15).Bold();
                        //    row.AutoItem().Text($"{data.GrandTotal:N0} 원 ( ￦ {data.GrandTotal:N0} )").FontSize(15).Bold();
                        //});
                    });
                });
            });

            document.GeneratePdf(fullPath);
            return fullPath;
        }

        /// <summary>
        /// PDF 문서에 "항목명 + 값" 형태의 한 줄을 추가한다.
        /// </summary>
        private static void InfoRow(
            QuestPDF.Fluent.ColumnDescriptor col,   // PDF에서 세로로 내용을 쌓아가는 영역
            string label1,                          // 첫 번째 컬럼 이름
            string value1,                          // 첫 번째 컬럼에 들어갈 값
            float fontSize = 9,
            string? label2 = null,                  // 두 번째 컬럼 이름. 기본값은 없음
            string? value2 = null,                  // 두 번째 컬럼 값. 기본값은 없음
            bool isLast = false,                    // 마지막 행인지 여부. 기본값은 false
            bool showSeal = false,
            byte[]? sealImage = null)
        {
            // 현재 Column 안에 새로운 한 줄(Row)을 만든다.
            col.Item().Row(r =>
            {
                // 첫 번째 컬럼 이름을 만든다.
                r.ConstantItem(100)                  // 컬럼 너비를 78로 고정한다.
                    .Height(25)
                    .Background(Colors.Grey.Lighten4) // 컬럼 배경을 연한 회색으로 만든다.
                    .Border(0.5f)                   // 위/아래/왼쪽/오른쪽에 모두 0.5 두께의 테두리를 만든다.
                    .Padding(4)                     // 글자 주변에 4만큼 여백을 준다.
                    .AlignMiddle()                  // 글자를 세로 가운데에 배치한다.
                    .Text(label1)                   // 첫 번째 컬럼 이름을 표시한다.
                    .AlignCenter()
                    .FontSize(fontSize);                   // 글자 크기를 8로 설정한다.


                // 첫 번째 컬럼의 값을 만든다.
                r.RelativeItem()                    // 남은 가로 공간을 자동으로 사용한다.
                    .Height(25)
                    .Border(0.5f)                   // 위/아래/왼쪽/오른쪽에 모두 0.5 두께의 테두리를 만든다.
                    .Padding(4)                     // 글자 주변에 4만큼 여백을 준다.
                    .AlignMiddle()                  // 글자를 세로 가운데에 배치한다.
                    .Text(value1)                   // 첫 번째 값을 표시한다.
                    .AlignCenter()
                    .Bold()
                    .FontSize(fontSize);                   // 글자 크기를 9로 설정한다.


                // 두 번째 컬럼이 있는 경우에만 만든다.
                if (label2 != null)
                {
                    // 두 번째 컬럼 이름을 만든다.
                    r.ConstantItem(46)              // 컬럼 너비를 46으로 고정한다.
                        .Height(25)
                        .Background(Colors.Grey.Lighten4) // 컬럼 배경을 연한 회색으로 만든다.
                        .Border(0.5f)               // 위/아래/왼쪽/오른쪽에 모두 0.5 두께의 테두리를 만든다.
                        .Padding(4)                 // 글자 주변에 4만큼 여백을 준다.
                        .AlignMiddle()              // 글자를 세로 가운데에 배치한다.
                        .Text(label2)               // 두 번째 컬럼 이름을 표시한다.
                        .AlignCenter()
                        .FontSize(fontSize);               // 글자 크기를 8로 설정한다.


                    // 두 번째 컬럼의 값을 만든다.
                    r.ConstantItem(80) // 값의 너비를 80으로 고정한다.
                        .Height(25)
                        .Border(0.5f) // 위/아래/왼쪽/오른쪽에 모두 0.5 두께의 테두리를 만든다.
                        .PaddingLeft(4) // 글자 주변에 4만큼 여백을 준다.
                        .PaddingRight(2) // 글자를 세로 가운데에 배치한다.
                        .AlignMiddle()
                        .Row(inner =>
                        {
                            // 성명 표시
                            inner.RelativeItem()
                                .AlignCenter()
                                .AlignMiddle()
                                .Text(value2 ?? "")
                                .Bold()
                                .FontSize(fontSize);

                            if (showSeal && sealImage is { Length: > 0 })
                            {
                                inner.ConstantItem(30)
                                    .AlignCenter()
                                    .AlignMiddle()
                                    .Image(sealImage)
                                    .FitArea();
                            }
                        });
                }
            });
        }

        /// <summary>
        /// PDF 문서에 전체 너비를 사용하는 "값 하나짜리 행"을 추가한다.
        /// </summary>
        private static void InfoValueRow(
            QuestPDF.Fluent.ColumnDescriptor col,   // PDF에서 세로로 내용을 쌓아가는 영역
            string value,                            // 전체 너비에 표시할 값
            float fontSize = 9,
            bool merge = false,
            bool isLast = false)                     // 마지막 행인지 여부. 기본값은 false
        {
            // 현재 Column 안에 새로운 한 줄(Row)을 만든다.
            col.Item().Row(r =>
            {
                // 전체 가로 공간을 사용하는 영역을 만든다.
                if (!merge)
                    r.RelativeItem()                     // 남아있는 가로 공간 전체를 사용한다.
                        .Height(25)
                        .Border(0.5f)                   // 위/아래/왼쪽/오른쪽에 모두 0.5 두께의 테두리를 만든다.
                        .Padding(4)                      // 글자 주변에 4만큼 여백을 준다.
                        .AlignMiddle()                   // 글자를 세로 가운데에 배치한다.
                        .AlignCenter()
                        .Text(value)                     // 전달받은 값을 표시한다.
                        .Bold()
                        .FontSize(fontSize);                    // 값의 글자 크기를 9로 설정한다.
                else
                    r.RelativeItem()                     // 남아있는 가로 공간 전체를 사용한다.
                        .Height(25)
                        .BorderLeft(0.5f)
                        .BorderRight(0.5f)
                        .BorderBottom(isLast ? 0.5f : 0)
                        .PaddingLeft(4)
                        .PaddingRight(4)
                        .PaddingTop(isLast ? 0.5f : 4)
                        .PaddingBottom(isLast ? 4 : 0)
                        .AlignMiddle()                   // 글자를 세로 가운데에 배치한다.
                        .AlignCenter()
                        .Text(value)                     // 전달받은 값을 표시한다.
                        .Bold()
                        .FontSize(fontSize);                    // 값의 글자 크기를 9로 설정한다.
            });
        }

        // 숫자를 한글로 변환
        private static string NumberToKorean(long number)
        {
            // 0이면 "영"
            if (number == 0)
                return "영";

            string[] numbers =
            {
                "", "일", "이", "삼", "사",
                "오", "육", "칠", "팔", "구"
            };

            string[] units =
            {
                "", "십", "백", "천"
            };

            string[] bigUnits =
            {
                "", "만", "억", "조", "경"
            };

            string result = "";

            // 만 단위씩 끊어서 처리
            int bigUnitIndex = 0;

            while (number > 0)
            {
                int part = (int)(number % 10000);

                if (part > 0)
                {
                    string partText = "";

                    int unitIndex = 0;

                    while (part > 0)
                    {
                        int digit = part % 10;

                        if (digit > 0)
                        {
                            // 숫자 1은 십/백/천 앞에서는 생략
                            string numberText =
                                (digit == 1 && unitIndex > 0)
                                ? ""
                                : numbers[digit];

                            partText =
                                numberText +
                                units[unitIndex] +
                                partText;
                        }

                        part /= 10;
                        unitIndex++;
                    }

                    result = partText + bigUnits[bigUnitIndex] + result;
                }

                number /= 10000;
                bigUnitIndex++;
            }

            return result;
        }
    }
}
