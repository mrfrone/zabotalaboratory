import {TokenGetter} from "../../shared/consts/tokenGetter";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Injectable} from "@angular/core";
import * as jwt_decode from "jwt-decode";
import {Roles} from "../../shared/models/users/roles";
import {IdentitiesRolesApiClient} from "../apiClient/users/identities-roles.api-client";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../shared/models/zabota-result/zabota-result";

@Injectable({providedIn: 'root'})
export class AuthCheckerService {

  constructor(private readonly _jwtHelper: JwtHelperService,
              private readonly _roles: IdentitiesRolesApiClient) {}

  public isAuth(): boolean{

    let token = TokenGetter.getToken();

    if (token && !this._jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }

  public getCurrentRole(): string {
      const token = TokenGetter.getToken();
            const decodedToken = jwt_decode(token);

      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }
}
