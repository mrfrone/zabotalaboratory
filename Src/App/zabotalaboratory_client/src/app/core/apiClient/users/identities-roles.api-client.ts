import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";
import {Roles} from "../../../shared/models/users/roles";
import {SubRoles} from "../../../shared/models/users/sub-roles";
import {AddNewSubRoleForm} from "../../../shared/forms/sub-roles/add-new-sub-role.form";
import {UpdateSubRoleForm} from "../../../shared/forms/sub-roles/update-sub-role.form";
import {UpdateSubRoleValidForm} from "../../../shared/forms/sub-roles/update-sub-role-valid.form";


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

  public getOnlyValidSubRoles(): Observable<ZabotaResult<SubRoles[]>> {
    return this.get<ZabotaResult<SubRoles[]>>('/api/Identities/GetOnlyValidSubRoles');
  }

  public getSubRoleById(id: number): Observable<ZabotaResult<SubRoles>> {
    return this.getWithId<ZabotaResult<SubRoles>>('/api/Identities/GetSubRoleById', id);
  }

  public addSubRole(form: AddNewSubRoleForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, AddNewSubRoleForm>('/api/Identities/AddSubRole', form);
  }

  public updateSubRole(form: UpdateSubRoleForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateSubRoleForm>('/api/Identities/UpdateSubRole', form);
  }

  public updateSubRoleValidation(form: UpdateSubRoleValidForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateSubRoleValidForm>('/api/Identities/UpdateSubRoleValid', form);
  }
}
