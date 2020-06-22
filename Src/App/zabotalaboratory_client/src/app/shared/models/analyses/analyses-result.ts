import {LaboratoryAnalysesTests} from "./laboratory-analyses-tests";

export class AnalysesResult {
  public id: number;
  public result: string;
  public laboratoryAnalysesTest: LaboratoryAnalysesTests;
  public units: string;
  public referenceLimits: string;
}
