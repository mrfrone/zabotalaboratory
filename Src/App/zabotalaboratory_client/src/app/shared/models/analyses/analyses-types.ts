import {LaboratoryAnalysesTests} from "./laboratory-analyses-tests";

export class AnalysesTypes {
  public id: number;
  public number1C: number;
  public numberInOrder: number;
  public name: string;
  public excelName: string;
  public pdfName: string;
  public isValid: boolean;
  public laboratoryAnalysesTests: LaboratoryAnalysesTests[];
  public bioMaterial: string;
}
