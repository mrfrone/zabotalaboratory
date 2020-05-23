import {Component, OnInit} from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {map, shareReplay, take} from 'rxjs/operators';
import {AuthCheckerService} from "../../../core/services/auth-checker.service";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AuthApiClient} from "../../../core/apiClient/auth.api-client";
import {MessageService} from "../../../core/services/message.service";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public role: string = 'Загрузка...';

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
    this.role = this._authCheckerService.getRole();
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
}
