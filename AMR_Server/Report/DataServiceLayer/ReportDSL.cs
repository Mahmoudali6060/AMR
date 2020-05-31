using DinkToPdf;
using DinkToPdf.Contracts;
using Reports.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reports.DataServiceLayer
{
    public class ReportDSL : IReportDSL
    {
        private readonly IConverter _converter;

        public ReportDSL(IConverter converter)
        {
            _converter = converter;
        }

        public string CreatePDF(string html)
        {
            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = Path.Combine(Directory.GetCurrentDirectory(), "PdfReports", "Report.pdf")  //USE THIS PROPERTY TO SAVE PDF TO A PROVIDED LOCATION
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html,
                    //Page = "https://www.facebook.com/", //USE THIS PROPERTY TO GENERATE PDF CONTENT FROM AN HTML PAGE
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets/css", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9,  },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                _converter.Convert(pdf); //IF WE USE Out PROPERTY IN THE GlobalSettings CLASS, THIS IS ENOUGH FOR CONVERSION

                //var file = _converter.Convert(pdf);
                //return Ok("Successfully created PDF document.");
                //return File(file, "application/pdf", "EmployeeReport.pdf");
                //return File(file, "application/pdf");

                return "PdfReports/Report.pdf";
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}