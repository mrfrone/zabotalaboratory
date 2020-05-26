import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";
import {Identity} from "../../../shared/models/users/identity";
import {Roles} from "../../../shared/models/users/roles";
import {SubRoles} from "../../../shared/models/users/sub-roles";


@Injectable({providedIn: 'root'})

export class IdentitiesRolesApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getRoles(): Observable<ZabotaResult<Roles[]>> {
    return this.get<ZabotaResult<Roles[]>>('/api/Identities/GetRoles');
  }

  public getSubRoles(): Observable<ZabotaResult<SubRoles[]>> {
    return this.get<ZabotaResult<SubRoles[]>>('/api/Identities/GetSubRoles');
  }
}
