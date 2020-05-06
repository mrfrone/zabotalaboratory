import {Component, OnInit} from '@angular/core';
import {LoginForm} from "../../../shared/forms/LoginForm";
import {finalize} from "rxjs/operators";
import {AuthService} from "../../../core/services/auth.service";
import {AuthCheckerService} from "../../../core/services/auth-checker.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public log: string = ''
  public pass: string = ''
  public isProgress: boolean = false

  constructor(private readonly _authService: AuthService,
              private readonly _authChecker: AuthCheckerService,
              private readonly  _router: Router) { }

  ngOnInit(): void {
    if(this._authChecker.isAuth()) {
      this._router.navigate(['main'])
    }
  }

  public login(): void {
    this.isProgress = true

    const form: LoginForm = {
      login: this.log,
      password: this.pass
    }

    this._authService.authorize(form).pipe(
      finalize(() => this.isProgress = false)
    ).subscribe();
  }
}
