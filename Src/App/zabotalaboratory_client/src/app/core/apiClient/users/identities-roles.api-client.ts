import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";
import {Roles} from "../../../shared/models/users/roles";


@Injectable({providedIn: 'root'})

export class IdentitiesRolesApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getRoles(): Observable<ZabotaResult<Roles[]>> {
    return this.get<ZabotaResult<Roles[]>>('/api/Identities/GetRoles');
  }
}
