import {Roles} from "./roles";
import {SubRoles} from "./sub-roles";

export class Identity {
  public id: number;
  public login: string;
  public role: Roles;
  public subRole?: SubRoles;
}
