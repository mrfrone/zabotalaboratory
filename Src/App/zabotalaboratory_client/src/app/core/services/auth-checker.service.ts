import {TokenGetter} from "../../shared/consts/tokenGetter";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../shared/models/zabota-result/zabota-result";
import {AuthApiClient} from "../apiClient/auth.api-client";

@Injectable({providedIn: 'root'})
export class AuthCheckerService {

    constructor(private readonly _jwtHelper: JwtHelperService,
                private readonly _authApiClient: AuthApiClient) {}

  public isAuth(): boolean{

    let token = TokenGetter.GetToken();

    if (token && !this._jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }
  public getRole(): Observable<ZabotaResult<string>> {
    return this._authApiClient.getRole();
  }
}
