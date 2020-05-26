import {Injectable} from "@angular/core";
import {BaseApiClient} from "../base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {NewAnalysesTestForm} from "../../../shared/forms/analyses-tests/new-analyses-test.form";
import {LaboratoryAnalysesTests} from "../../../shared/models/analyses/laboratory-analyses-tests";
import {UpdateAnalysesTestForm} from "../../../shared/forms/analyses-tests/update-analyses-test.form";
import {UpdateAnalysesTestValidForm} from "../../../shared/forms/analyses-tests/update-analyses-test-valid.form";

@Injectable({providedIn: 'root'})

export class AnalysesTestsApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
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

  public updateTestValidation(form: UpdateAnalysesTestValidForm): Observable<ZabotaResult<boolean>>{
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTestValidForm>('/api/AnalysesTests/UpdateAnalysesTestValid', form);
  }
}
