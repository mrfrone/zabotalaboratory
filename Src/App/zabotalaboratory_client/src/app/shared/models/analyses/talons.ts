import { AnalysesResult } from './analyses-result';
import {AnalysesTypes} from "./analyses-types";

export class Talons{
  public id: number;
  public analysesType: AnalysesTypes;
  public analysesResult: AnalysesResult[];
  public performedBy: string;
}
