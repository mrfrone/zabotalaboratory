import {TokenGetter} from "../../shared/consts/tokenGetter";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Injectable} from "@angular/core";

@Injectable({providedIn: 'root'})
export class AuthCheckerService {

    constructor(private readonly _jwtHelper: JwtHelperService) {}

  public isAuth(): boolean{

    let token = TokenGetter.GetToken();

    if (token && !this._jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }
}
