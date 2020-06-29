using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;
using zabotalaboratory.Common.Razor.Consts;
using zabotalaboratory.Common.Razor.RazorRender;
using zabotalaboratory.Common.RazorReports.HtmlToPDFConverter;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;

namespace zabotalaboratory.Common.RazorReports.Reports.Analyses
{
    internal class AnalysesReportsService : IAnalysesReportsService
    {
        private readonly ILaboratoryAnalysesService _laboratoryAnalysesService;
        private readonly IRazorRenderService _razorRenderService;
        private readonly IHtmlToPDFConverterService _htmlToPDFConverterService;

        public AnalysesReportsService(ILaboratoryAnalysesService laboratoryAnalysesService,
                                      IRazorRenderService razorRenderService,
                                      IHtmlToPDFConverterService htmlToPDFConverterService)
        {
            _laboratoryAnalysesService = laboratoryAnalysesService;
            _razorRenderService = razorRenderService;
            _htmlToPDFConverterService = htmlToPDFConverterService;
        }

        public async Task<ZabotaResult<byte[]>> GetAnalysesResultReportById(int id)
        {
            var result = await _laboratoryAnalysesService.GetLaboratoryAnalyseById(id);
            if (result.IsNotCorrect)
                return ZabotaErrorCodes.EmptyResult;

            var html = await _razorRenderService.GetRenderedHtml(result.Result, DefaultTemplateNames.AnalysesResult);
            var pdf = _htmlToPDFConverterService.GetConvertedPdf(html);

            return new ZabotaResult<byte[]>(pdf);
        }

        public async Task<ZabotaResult<byte[]>> GetMedicalRecordReportById(int id)
        {
            var result = await _laboratoryAnalysesService.GetLaboratoryAnalyseWithMedicalRecordById(id);
            if (result.IsNotCorrect)
                return ZabotaErrorCodes.EmptyResult;

            var html = await _razorRenderService.GetRenderedHtml(result.Result, DefaultTemplateNames.MedicalRecord);
            var pdf = _htmlToPDFConverterService.GetConvertedPdf(html);

            return new ZabotaResult<byte[]>(pdf);
        }
    }
}
