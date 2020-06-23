import {Injectable} from "@angular/core";
import {BaseApiClient} from "../base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {AnalysesTypes} from "../../../shared/models/analyses/analyses-types";
import {UpdateAnalysesTestValidForm} from "../../../shared/forms/analyses-tests/update-analyses-test-valid.form";
import {UpdateAnalysesTypeForm} from "../../../shared/forms/analyses-types/update-analyses-type.form";
import {AddNewAnalysesTypeForm} from "../../../shared/forms/analyses-types/add-new-analyses-type.form";
import {AnalysesTypesAddForm} from "../../../shared/models/analyses/add-form/analyses-types.add-form";
import {UpdateAnalysesTypesNumberInOrderForm} from "../../../shared/forms/analyses-types/update-analyses-types-number-in-order.form";

@Injectable({providedIn: 'root'})

export class AnalysesTypesApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getAnalysesTypesWithTestsToAddForm(): Observable<ZabotaResult<AnalysesTypesAddForm[]>> {
    return this.get<ZabotaResult<AnalysesTypesAddForm[]>>('/api/AnalysesTypes/GetAnalysesTypesToAddForm');
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

  public addNewAnalysesType(form: AddNewAnalysesTypeForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, AddNewAnalysesTypeForm>('/api/AnalysesTypes/AddAnalysesType', form);
  }

  public updateAnalysesType(form: UpdateAnalysesTypeForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTypeForm>('/api/AnalysesTypes/UpdateAnalysesType', form);
  }

  public updateTypeValidation(form: UpdateAnalysesTestValidForm): Observable<ZabotaResult<boolean>>{
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTestValidForm>('/api/AnalysesTypes/UpdateAnalysesTypeValid', form);
  }

  public updateTypeNumberInOrder(form: UpdateAnalysesTypesNumberInOrderForm): Observable<ZabotaResult<boolean>>{
    return this.post<ZabotaResult<boolean>, UpdateAnalysesTypesNumberInOrderForm>('/api/AnalysesTypes/UpdateAnalysesTypeNumber', form);
  }
}
