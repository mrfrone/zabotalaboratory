import {Injectable} from "@angular/core";
import {AnalysesApiClient} from "../apiClient/analyses.api-client";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../shared/models/zabota-result/zabota-result";
import {take} from "rxjs/operators";
import {LaboratoryAnalyses} from "../../shared/models/analyses/laboratory-analyses";

@Injectable({providedIn: 'root'})

export class AnalysesService {
  constructor(private readonly _analyses: AnalysesApiClient) {
  }

  public getLaboratoryAnalyses(): Observable<ZabotaResult<LaboratoryAnalyses[]>> {
    return this._analyses.getLaboratoryAnalyses().pipe(
      take(1)
    );
  }
}
