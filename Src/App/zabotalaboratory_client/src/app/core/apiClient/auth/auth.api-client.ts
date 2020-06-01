import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginForm} from "../../../shared/forms/auth/login.form";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {Jwt} from "../../../shared/models/jwt/jwt";
import {Observable} from "rxjs";
import {BaseApiClient} from "../base.api-client";


@Injectable({providedIn: 'root'})

export class AuthApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public authorize(form: LoginForm): Observable<ZabotaResult<Jwt>> {
    return this.post<ZabotaResult<Jwt>, LoginForm>('/api/auth/login', form);
  }

  public logOut(): Observable<ZabotaResult<boolean>> {
    return this.postWithoutBody<ZabotaResult<boolean>>('/api/auth/logout');
  }

  public getRole(): Observable<ZabotaResult<string>>{
    return this.get<ZabotaResult<string>>('/api/userprofile/getrole');
  }
}
