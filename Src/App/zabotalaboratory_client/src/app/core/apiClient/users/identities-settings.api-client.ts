import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";
import {Identity} from "../../../shared/models/users/identity";
import {AddIdentityForm} from "../../../shared/forms/identities/add-identity.form";
import {UpdateIdentityForm} from "../../../shared/forms/identities/update-identity.form";


@Injectable({providedIn: 'root'})

export class IdentitiesSettingsApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getIdentities(): Observable<ZabotaResult<Identity[]>> {
    return this.get<ZabotaResult<Identity[]>>('/api/Identities/GetIdentities');
  }

  public getIdentity(id: number): Observable<ZabotaResult<Identity>> {
    return this.getWithId<ZabotaResult<Identity>>('/api/Identities/GetIdentityById', id);
  }

  public addIdentity(form: AddIdentityForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, AddIdentityForm>('/api/Identities/AddIdentity', form);
  }

  public updateIdentity(form: UpdateIdentityForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateIdentityForm>('/api/Identities/UpdateIdentity', form);
  }

  public deleteIdentity(id: number): Observable<ZabotaResult<boolean>> {
    return this.getWithId<ZabotaResult<boolean>>('/api/Identities/DeleteIdentityById', id);
  }
}
