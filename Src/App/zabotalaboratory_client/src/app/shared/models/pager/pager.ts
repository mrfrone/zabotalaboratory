import {BasePager} from "./base-pager";

export class Pager<T> extends BasePager {
  public pageResult: T;

  constructor(val: T = null) {
    super();
  }
}
