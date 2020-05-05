import {ZabotaError} from "./zabota-error/zabota-error";

export class BaseZabotaResult {
  public error: ZabotaError;
  public isCorrect: boolean;
  public isNotCorrect: boolean;
}
