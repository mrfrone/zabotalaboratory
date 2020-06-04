import {Roles} from "./roles";

export class Identity {
  public id: number;
  public login: string;
  public role: Roles;
  public clinicId: number;
  public clinicName: string;
}
