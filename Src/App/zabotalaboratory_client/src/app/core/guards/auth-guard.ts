import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";
import {AuthCheckerService} from "../services/auth-checker.service";
import {MessageService} from "../services/message.service";

@Injectable({providedIn: 'root'})

export class AuthGuard implements CanActivate {
  constructor(private readonly _authChecker: AuthCheckerService,
              private readonly router: Router,
              private readonly _message: MessageService) {
  }
  canActivate() {
    if (this._authChecker.isAuth()){
      return true;
    }
    this._message.showMessage('Вы не авторизованы')
    this.router.navigate([""]);
    return false;
  }
}
