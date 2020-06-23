using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.Talons;
using zabotalaboratory.Analyses.Services.Analyses;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;

namespace zabotalaboratory.Common.ExcelReports.Analyses
{
    internal class LaboratoryAnalysesExcelReportsService : ILaboratoryAnalysesExcelReportsService
    {
        private readonly ILaboratoryAnalysesService _laboratoryAnalysesService;
        private readonly IAnalysesService _analysesService;
        public LaboratoryAnalysesExcelReportsService(ILaboratoryAnalysesService laboratoryAnalysesService,
                                                     IAnalysesService analysesService)
        {
            _laboratoryAnalysesService = laboratoryAnalysesService;
            _analysesService = analysesService;
        }

        public async Task<ZabotaResult<byte[]>> GetLaboratoryAnalysesExcelReportByDate(DateTimeOffset date)
        {
            var analyses = await _laboratoryAnalysesService.GetLaboratoryAnalysesByDate(date);
            if (analyses.IsNotCorrect)
                return ZabotaErrorCodes.EmptyResult;

            var analysesTypes = await _analysesService.GetAnalysesTypes(true, true);
            if (analyses.IsNotCorrect)
                return ZabotaErrorCodes.EmptyResult;

            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Analyses");

                var currentRow = 1;
                var currentColumn = 1;

                workSheet.Cell(currentRow, currentColumn).Value = "№ п/п";
                workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.Yellow);
                currentColumn++;
                workSheet.Cell(currentRow, currentColumn).Value = date.ToString("dd.MM.yyyy");
                workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.LightBrown);
                currentColumn++;

                foreach (var type in analysesTypes.Result)
                {
                    workSheet.Cell(currentRow, currentColumn).Value = type.ExcelName;
                    workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.LightGreen);
                    currentColumn++;

                    foreach (var test in type.LaboratoryAnalysesTests)
                    {
                        workSheet.Cell(currentRow, currentColumn).Value = test.ExcelName;
                        workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.Orange);
                        currentColumn++;
                    }

                }

                workSheet.Cell(currentRow, currentColumn).Value = "ФИО";
                currentColumn++;
                workSheet.Cell(currentRow, currentColumn).Value = "Дата рождения";
                currentColumn++;
                workSheet.Cell(currentRow, currentColumn).Value = "Пол";
                currentColumn++;
                workSheet.Cell(currentRow, currentColumn).Value = "Доктор";
                currentColumn++;
                workSheet.Cell(currentRow, currentColumn).Value = "Пункт";
                currentColumn++;

                currentRow++;

                foreach(var (analyse, i) in analyses.Result.Select((analyse, i) => (analyse, i)))
                {
                    currentColumn = 1;

                    workSheet.Cell(currentRow, currentColumn).Value = i + 1;
                    workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.Yellow);
                    currentColumn++;

                    workSheet.Cell(currentRow, currentColumn).Value = date.ToString("dd.MM.yyyy");
                    workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.LightBrown);
                    currentColumn++;

                    foreach (var type in analysesTypes.Result)
                    {
                        var talon = analyse.Talons.FirstOrDefault(t => t.AnalysesType.Id == type.Id);

                        if (talon == null)
                        {
                            workSheet.Cell(currentRow, currentColumn).Value = "Не заказан";
                            currentColumn++;
                        }
                        else
                        {
                            workSheet.Cell(currentRow, currentColumn).Value = talon.Id;
                            workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.LightBlue);
                            currentColumn++;
                        }

                        foreach (var test in type.LaboratoryAnalysesTests)
                        {
                            ZabotaAnalysesResult result = null;

                            if (talon != null)
                                result = talon.AnalysesResult.FirstOrDefault(t => t.LaboratoryAnalysesTest.Id == test.Id);
                            
                            if (result == null)
                            {
                                currentColumn++;
                            }
                            else
                            {
                                workSheet.Cell(currentRow, currentColumn).Style.Fill.SetBackgroundColor(XLColor.LightBlue);
                                currentColumn++;
                            }
                        }
                    }

                    workSheet.Cell(currentRow, currentColumn).Value = analyse.FullName;
                    currentColumn++;
                    workSheet.Cell(currentRow, currentColumn).Value = analyse.DateOfBirth.ToString("dd.MM.yyyy");
                    currentColumn++;
                    workSheet.Cell(currentRow, currentColumn).Value = analyse.Gender.ShortName;
                    currentColumn++;
                    workSheet.Cell(currentRow, currentColumn).Value = analyse.Doctor;
                    currentColumn++;
                    workSheet.Cell(currentRow, currentColumn).Value = analyse.Clinic.Name;
                    currentColumn++;

                    currentRow++;
                }

                currentColumn--;
                currentRow--;

                workSheet.Range(1, 1, currentRow, currentColumn).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                workSheet.Range(1, 1, currentRow, currentColumn).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                workSheet.Range(1, 1, currentRow, currentColumn).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                workSheet.Range(1, 1, currentRow, currentColumn).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                workSheet.Range(1, 1, currentRow, currentColumn).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var excel = stream.ToArray();

                    return new ZabotaResult<byte[]>(excel);
                }
            }     
        }
    }
}
