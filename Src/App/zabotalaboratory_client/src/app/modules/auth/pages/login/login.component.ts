import {Component, OnInit} from '@angular/core';
import {LoginForm} from "../../../../shared/forms/Auth/login.form";
import {finalize} from "rxjs/operators";
import {AuthCheckerService} from "../../../../core/services/auth-checker.service";
import {Router} from "@angular/router";
import {ZabotaResult} from "../../../../shared/models/zabota-result/zabota-result";
import {Jwt} from "../../../../shared/models/jwt/jwt";
import {DefaultSuccessMessages} from "../../../../shared/consts/defaultSuccessMessages";
import {AuthApiClient} from "../../../../core/apiClient/auth.api-client";
import {MessageService} from "../../../../core/services/message.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public log: string = ''
  public pass: string = ''
  public isProgress: boolean = false

  constructor(private readonly _auth: AuthApiClient,
              private readonly _authChecker: AuthCheckerService,
              private readonly  _router: Router,
              private readonly _messages: MessageService) { }

  ngOnInit(): void {
    if(this._authChecker.isAuth()) {
      this.goToMainPage();
    }
  }

  public login(): void {
    this.isProgress = true

    const form: LoginForm = {
      login: this.log,
      password: this.pass
    }

    this._auth.authorize(form).pipe(
      finalize(() => this.isProgress = false)
    ).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onAuth)

      if (res.isCorrect === true) {
        localStorage.setItem('jwt', res.result.token);
        this.goToMainPage();
      }
    });
  }

  private goToMainPage(): void {
    this._router.navigate(['analyses']);
  }
}
