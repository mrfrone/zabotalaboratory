import {Component, OnInit} from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {map, shareReplay} from 'rxjs/operators';
import {AuthCheckerService} from "../../../core/services/auth-checker.service";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AuthApiClient} from "../../../core/apiClient/auth/auth.api-client";
import {MessageService} from "../../../core/services/message.service";
import {Router} from "@angular/router";
import { StaticRoles } from "../../../shared/consts/staticRoles";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public currentRole: string = 'Загрузка...';
  public admin: string = StaticRoles.admin;
  public laborant: string = StaticRoles.laborant;
  public clinic: string = StaticRoles.clinic;


  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private readonly breakpointObserver: BreakpointObserver,
              private readonly _auth: AuthApiClient,
              private readonly _authCheckerService: AuthCheckerService,
              private readonly _messages: MessageService,
              private readonly _router: Router) {
  }

  ngOnInit(): void {
    this.currentRole = this._authCheckerService.getCurrentRole();
  }

  public logOut(): void {
    this._auth.logOut().subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onLogout)

      if (res.isCorrect === true){
        localStorage.removeItem('jwt');
        this._router.navigate(['']);
      }
    });
  }

  public isAvailableRoute(roles: string[]): boolean {
    let access: boolean = false;
    let currentRole: string = this._authCheckerService.getCurrentRole()

    roles.forEach(function (value) {
      if(value == currentRole) {
        access = true;
        return;
      }
    });

    if(access)
      return true;

    return false;
  }
}
