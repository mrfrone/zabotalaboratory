import {BaseZabotaResult} from "./base-zabota-result";

export class ZabotaResult<T> extends BaseZabotaResult {
  public result: T;

  constructor(val: T = null) {
    super();
  }
}
