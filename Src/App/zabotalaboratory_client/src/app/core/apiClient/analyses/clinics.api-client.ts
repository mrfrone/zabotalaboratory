import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";
import {AddClinicRoleForm} from "../../../shared/forms/clinics/add-clinic-role.form";
import {UpdateClinicForm} from "../../../shared/forms/clinics/update-clinic.form";
import {UpdateClinicValidForm} from "../../../shared/forms/clinics/update-clinic-valid.form";
import {Clinic} from "../../../shared/models/analyses/clinic";


@Injectable({providedIn: 'root'})

export class ClinicsApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getClinics(): Observable<ZabotaResult<Clinic[]>> {
    return this.get<ZabotaResult<Clinic[]>>('/api/Clinics/GetClinics');
  }

  public getOnlyValidClinics(): Observable<ZabotaResult<Clinic[]>> {
    return this.get<ZabotaResult<Clinic[]>>('/api/Clinics/GetOnlyValidClinics');
  }

  public getClinicsForCurrentUser(): Observable<ZabotaResult<Clinic[]>> {
    return this.get<ZabotaResult<Clinic[]>>('/api/Clinics/GetClinicsForCurrentUser');
  }

  public getClinicById(id: number): Observable<ZabotaResult<Clinic>> {
    return this.getWithId<ZabotaResult<Clinic>>('/api/Clinics/GetClinicById', id);
  }

  public addClinic(form: AddClinicRoleForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, AddClinicRoleForm>('/api/Clinics/AddClinic', form);
  }

  public updateClinic(form: UpdateClinicForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateClinicForm>('/api/Clinics/UpdateClinic', form);
  }

  public updateClinicValidation(form: UpdateClinicValidForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateClinicValidForm>('/api/Clinics/UpdateClinicValid', form);
  }
}
