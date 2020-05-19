import {Injectable} from "@angular/core";
import {BaseApiClient} from "./base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../shared/models/zabota-result/zabota-result";
import {LaboratoryAnalyses} from "../../shared/models/analyses/laboratory-analyses";

@Injectable({providedIn: 'root'})

export class AnalysesApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getLaboratoryAnalyses(): Observable<ZabotaResult<LaboratoryAnalyses[]>> {
    return this.get<ZabotaResult<LaboratoryAnalyses[]>>('/api/analyses/LaboratoryAnalyses');
  }
}
