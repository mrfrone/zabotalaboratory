using Microsoft.AspNetCore.Hosting;
using SelectPdf;

namespace zabotalaboratory.Common.RazorReports.HtmlToPDFConverter
{
    internal class HtmlToPDFConverterService : IHtmlToPDFConverterService
    {
        private IWebHostEnvironment _hostingEnvironment;

        public HtmlToPDFConverterService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public byte[] GetConvertedPdf(string html)
        {
            HtmlToPdf converter = new HtmlToPdf();
            var pdf = converter.ConvertHtmlString(html, @"file:///" + _hostingEnvironment.WebRootPath.Replace('\\', '/') + @"/images/");

            return pdf.Save();
        }
    }
}
