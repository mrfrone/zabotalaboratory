import {Injectable} from "@angular/core";
import {AuthCheckerService} from "./auth-checker.service";

@Injectable({providedIn: 'root'})
export class AvailableRoleService {
  constructor(private readonly _authCheckerService: AuthCheckerService) {
  }

  public isAvailable(roles: string[]): boolean {
    const currentRole: string = this._authCheckerService.getCurrentRole()
    return roles.includes(currentRole);
  }
}
