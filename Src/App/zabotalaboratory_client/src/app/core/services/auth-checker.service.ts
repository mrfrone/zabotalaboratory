import {TokenGetter} from "../../shared/consts/tokenGetter";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Injectable} from "@angular/core";
import {AuthApiClient} from "../apiClient/auth.api-client";
import * as jwt_decode from "jwt-decode";

@Injectable({providedIn: 'root'})
export class AuthCheckerService {

    constructor(private readonly _jwtHelper: JwtHelperService,
                private readonly _authApiClient: AuthApiClient) {}

  public isAuth(): boolean{

    let token = TokenGetter.getToken();

    if (token && !this._jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }
  public getRole(): string {
      const token = TokenGetter.getToken();
            const decodedToken = jwt_decode(token);

      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }
}
