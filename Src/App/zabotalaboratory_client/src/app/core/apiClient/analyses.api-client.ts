import {Injectable} from "@angular/core";
import {BaseApiClient} from "./base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../shared/models/zabota-result/zabota-result";
import {LaboratoryAnalyses} from "../../shared/models/analyses/laboratory-analyses";
import {AnalysesTypes} from "../../shared/models/analyses/analyses-types";
import {NewAnalysesTestForm} from "../../shared/forms/Analyses/new-analyses-test.form";
import {LaboratoryAnalysesTests} from "../../shared/models/analyses/laboratory-analyses-tests";
import {UpdateAnalysesTestForm} from "../../shared/forms/Analyses/update-analyses-test.form";
import {UpdateAnalysesTestValidForm} from "../../shared/forms/Analyses/update-analyses-test-valid.form";

@Injectable({providedIn: 'root'})

export class AnalysesApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getLaboratoryAnalyses(): Observable<ZabotaResult<LaboratoryAnalyses[]>> {
    return this.get<ZabotaResult<LaboratoryAnalyses[]>>('/api/LaboratoryAnalyses/GetLaboratoryAnalyses');
  }

  public getAnalysesTypes(): Observable<ZabotaResult<AnalysesTypes[]>> {
    return this.get<ZabotaResult<AnalysesTypes[]>>('/api/AnalysesTypes/GetAnalysesTypes');
  }

  public getAnalysesTest(id: number): Observable<ZabotaResult<LaboratoryAnalysesTests>>{
    return this.getWithId<ZabotaResult<LaboratoryAnalysesTests>>('/api/AnalysesTests/AnalysesTestById', id);
  }

  public addNewAnalysesTest(form: NewAnalysesTestForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, NewAnalysesTestForm>('/api/AnalysesTests/AddAnalysesTest', form);
  }

  public updateAnalysesTest(form: UpdateAnalysesTestForm): Observable<ZabotaResult<boolean>>{
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTestForm>('/api/AnalysesTests/UpdateAnalysesTest', form);
  }

  public updateValidation(form: UpdateAnalysesTestValidForm): Observable<ZabotaResult<boolean>>{
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTestValidForm>('/api/AnalysesTests/UpdateAnalysesTestValid', form);
  }
}
