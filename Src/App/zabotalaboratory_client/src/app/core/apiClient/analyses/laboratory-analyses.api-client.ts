import {Injectable} from "@angular/core";
import {BaseApiClient} from "../base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {LaboratoryAnalyses} from "../../../shared/models/analyses/laboratory-analyses";
import {Clinic} from "../../../shared/models/analyses/clinic";

@Injectable({providedIn: 'root'})

export class LaboratoryAnalysesApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getLaboratoryAnalyses(): Observable<ZabotaResult<LaboratoryAnalyses[]>> {
    return this.get<ZabotaResult<LaboratoryAnalyses[]>>('/api/LaboratoryAnalyses/GetLaboratoryAnalyses');
  }

  public getLaboratoryAnalyseById(id: number): Observable<ZabotaResult<LaboratoryAnalyses>> {
    return this.getWithId<ZabotaResult<LaboratoryAnalyses>>('/api/LaboratoryAnalyses/LaboratoryAnalyseById', id);
  }

  public getClinics(): Observable<ZabotaResult<Clinic[]>> {
    return this.get<ZabotaResult<Clinic[]>>('/api/LaboratoryAnalyses/GetClinics');
  }
}
