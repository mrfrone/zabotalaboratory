import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";
import {TokenGetter} from "../../shared/consts/tokenGetter";
import {AuthCheckerService} from "../services/auth-checker.service";
import {MessageService} from "../services/message.service";

@Injectable({providedIn: 'root'})

export class AuthGuard implements CanActivate {
  constructor(private readonly _authChecker: AuthCheckerService,
              private readonly router: Router,
              private readonly _messageService: MessageService) {
  }
  canActivate() {
    let token = TokenGetter.GetToken();

    if (this._authChecker.isAuth()){
      return true;
    }
    this._messageService.showMessage('Вы не авторизованы')
    this.router.navigate([""]);
    return false;
  }
}
