namespace zabotalaboratory.Common.RazorReports.HtmlToPDFConverter
{
    internal interface IHtmlToPDFConverterService
    {
        byte[] GetConvertedPdf(string html);
    }
}
