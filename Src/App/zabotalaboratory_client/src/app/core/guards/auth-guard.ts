import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";
import {JwtHelperService} from "@auth0/angular-jwt";
import {TokenGetter} from "../../shared/consts/tokenGetter";

@Injectable({providedIn: 'root'})

export class AuthGuard implements CanActivate {
  constructor(private jwtHelper: JwtHelperService, private router: Router) {
  }
  canActivate() {
    let token = TokenGetter.GetToken();

    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    this.router.navigate([""]);
    return false;
  }
}
