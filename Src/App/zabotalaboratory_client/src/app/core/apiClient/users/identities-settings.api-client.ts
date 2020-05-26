import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";
import {Identity} from "../../../shared/models/users/identity";
import {NewIdentityForm} from "../../../shared/forms/identities/new-identity.form";


@Injectable({providedIn: 'root'})

export class IdentitiesSettingsApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getIdentities(): Observable<ZabotaResult<Identity[]>> {
    return this.get<ZabotaResult<Identity[]>>('/api/Identities/GetIdentities');
  }

  public addIdentity(form: NewIdentityForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, NewIdentityForm>('/api/Identities/AddIdentity', form);
  }
}
