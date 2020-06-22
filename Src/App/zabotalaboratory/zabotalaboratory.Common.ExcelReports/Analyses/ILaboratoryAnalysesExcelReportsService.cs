using System;
using System.Threading.Tasks;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Common.ExcelReports.Analyses
{
    public interface ILaboratoryAnalysesExcelReportsService
    {
        Task<ZabotaResult<byte[]>> GetLaboratoryAnalysesExcelReportByDate(DateTimeOffset date);
    }
}
