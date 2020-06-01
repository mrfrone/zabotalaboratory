import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router} from "@angular/router";
import {MessageService} from "../services/message.service";
import {AuthCheckerService} from "../services/auth-checker.service";

@Injectable({providedIn: 'root'})

export class RolesGuard implements CanActivate{
  constructor(private readonly _router: Router,
              private readonly _message: MessageService,
              private readonly _authChecker: AuthCheckerService) {}

  canActivate(route: ActivatedRouteSnapshot) {
    let roles = route.data["roles"] as Array<string>;
    let currentRole = this._authChecker.getCurrentRole();

    let roleExists: boolean = false;

    roles.forEach(function (value) {
      if(value == currentRole) {
        roleExists = true;
        return;
      }
    });

    if(roleExists)
      return true;

    this._message.showMessage('Нет доступа');
    this._router.navigate(["home/analyses"])
    return false;
  }
}
