using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Common.RazorReports.Reports.Analyses
{
    public interface IAnalysesReportsService
    {
        Task<ZabotaResult<byte[]>> GetAnalysesResultReportById(int id);

        Task<ZabotaResult<byte[]>> GetMedicalRecordReportById(int id);
    }
}
