import {Injectable} from "@angular/core";
import {BaseApiClient} from "../base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {AnalysesTypes} from "../../../shared/models/analyses/analyses-types";
import {UpdateAnalysesTestValidForm} from "../../../shared/forms/analyses-tests/update-analyses-test-valid.form";
import {UpdateAnalysesTypeForm} from "../../../shared/forms/analyses-types/update-analyses-type.form";
import {NewAnalysesTypeForm} from "../../../shared/forms/analyses-types/new-analyses-type.form";

@Injectable({providedIn: 'root'})

export class AnalysesTypesApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getAnalysesTypesWithTests(): Observable<ZabotaResult<AnalysesTypes[]>> {
    return this.get<ZabotaResult<AnalysesTypes[]>>('/api/AnalysesTypes/GetAnalysesTypesWithTests');
  }

  public getAnalysesTypesWithoutTests(): Observable<ZabotaResult<AnalysesTypes[]>> {
    return this.get<ZabotaResult<AnalysesTypes[]>>('/api/AnalysesTypes/GetAnalysesTypesWithoutTests');
  }

  public getAnalysesType(id: number): Observable<ZabotaResult<AnalysesTypes>> {
    return this.getWithId<ZabotaResult<AnalysesTypes>>('/api/AnalysesTypes/GetAnalysesType', id);
  }

  public addNewAnalysesType(form: NewAnalysesTypeForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, NewAnalysesTypeForm>('/api/AnalysesTypes/AddAnalysesType', form);
  }

  public updateAnalysesType(form: UpdateAnalysesTypeForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTypeForm>('/api/AnalysesTypes/UpdateAnalysesType', form);
  }

  public updateTypeValidation(form: UpdateAnalysesTestValidForm): Observable<ZabotaResult<boolean>>{
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTestValidForm>('/api/AnalysesTypes/UpdateAnalysesTypeValid', form);
  }
}
