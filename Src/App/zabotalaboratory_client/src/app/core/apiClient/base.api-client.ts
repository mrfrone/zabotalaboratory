import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {BaseZabotaResult} from "../../shared/models/zabota-result/base-zabota-result";
import {DefaultUrls} from "../../shared/consts/defaultUrls";

export class BaseApiClient {
  constructor(private readonly _httpClient: HttpClient) {
  }

  protected post<TRes extends BaseZabotaResult, TForm>(url: string, form: TForm): Observable<TRes> {
    const serializedForm = JSON.stringify(form);
    return this._httpClient.post<TRes>(DefaultUrls.ServerUrl + url, serializedForm, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  protected postWithoutBody<TRes extends BaseZabotaResult>(url: string): Observable<TRes> {
    return this._httpClient.post<TRes>(DefaultUrls.ServerUrl + url, '', {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  protected get<TRes extends BaseZabotaResult>(url: string): Observable<TRes> {
    return this._httpClient.get<TRes>(DefaultUrls.ServerUrl + url);
  }

  protected getWithId<TRes extends BaseZabotaResult>(url: string, id: number): Observable<TRes> {
    return this._httpClient.get<TRes>(DefaultUrls.ServerUrl + url + "/?id=" + id);
  }
}
