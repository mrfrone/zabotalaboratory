import {LaboratoryAnalysesTestsAddForm} from "./laboratory-analyses-tests.add-form";

export class AnalysesTypesAddForm {
  public id: number;
  public number1C: number;
  public name: string;
  public excelName: string;
  public pdfName: string;
  public isNeeded?: boolean;
  public laboratoryAnalysesTests: LaboratoryAnalysesTestsAddForm[];
}
