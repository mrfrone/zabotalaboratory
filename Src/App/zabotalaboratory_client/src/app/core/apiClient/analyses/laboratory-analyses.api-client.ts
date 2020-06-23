import {Injectable} from "@angular/core";
import {BaseApiClient} from "../base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {LaboratoryAnalyses} from "../../../shared/models/analyses/laboratory-analyses";
import {AddLaboratoryAnalysesForm} from "../../../shared/forms/laboratory-analyses/add-laboratory-analyses.form";
import {Pager} from "../../../shared/models/pager/pager";
import {SearchLaboratoryAnalysesForm} from "../../../shared/forms/laboratory-analyses/search-laboratory-analyses.form";
import {DownloadFileForm} from "../../../shared/forms/common/download-file.form";
import {GetLaboratoryAnalyseToNotAuthForm} from "../../../shared/forms/auth/get-laboratory-analyse-to-not-auth.form";
import {DownloadFileByDateForm} from "../../../shared/forms/common/download-file-by-date.form";
import {Gender} from "../../../shared/models/analyses/gender";

@Injectable({providedIn: 'root'})

export class LaboratoryAnalysesApiClient extends BaseApiClient{
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getGenders(): Observable<ZabotaResult<Gender[]>> {
    return this.get<ZabotaResult<Gender[]>>('/api/LaboratoryAnalyses/GetGenders');
  }

  public getLaboratoryAnalyses(page: number): Observable<ZabotaResult<Pager<LaboratoryAnalyses[]>>> {
    return this.getWithId<ZabotaResult<Pager<LaboratoryAnalyses[]>>>('/api/LaboratoryAnalyses/GetLaboratoryAnalyses', page);
  }

  public getSearchLaboratoryAnalyses(form: SearchLaboratoryAnalysesForm): Observable<ZabotaResult<Pager<LaboratoryAnalyses[]>>> {
    return this.post<ZabotaResult<Pager<LaboratoryAnalyses[]>>, SearchLaboratoryAnalysesForm>('/api/LaboratoryAnalyses/GetLaboratoryAnalyses', form);
  }

  public getLaboratoryAnalyseById(id: number): Observable<ZabotaResult<LaboratoryAnalyses>> {
    return this.getWithId<ZabotaResult<LaboratoryAnalyses>>('/api/LaboratoryAnalyses/LaboratoryAnalyseById', id);
  }

  public getLaboratoryAnalyseId(form: GetLaboratoryAnalyseToNotAuthForm): Observable<ZabotaResult<number>> {
    return this.post<ZabotaResult<number>, GetLaboratoryAnalyseToNotAuthForm>('/api/LaboratoryAnalyses/LaboratoryAnalyseId', form);
  }

  public getLaboratoryAnalyseReportById(form: DownloadFileForm): Observable<Blob> {
    return this.getFile('/api/LaboratoryAnalyses/GetLaboratoryAnalyseReportById', form);
  }

  public getLaboratoryAnalyseReportByDate(form: DownloadFileByDateForm): Observable<Blob> {
    return this.getFile('/api/LaboratoryAnalyses/GetLaboratoryAnalyseExcelReportByDate', form);
  }

  public addLaboratoryAnalyse(form: AddLaboratoryAnalysesForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, AddLaboratoryAnalysesForm>('/api/LaboratoryAnalyses/AddLaboratoryAnalyse', form);
  }
}
