import {Component, OnInit} from '@angular/core';
import {LoginForm} from "../../../shared/forms/auth/login.form";
import {finalize} from "rxjs/operators";
import {AuthCheckerService} from "../../../core/services/auth-checker.service";
import {Router} from "@angular/router";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AuthApiClient} from "../../../core/apiClient/auth/auth.api-client";
import {MessageService} from "../../../core/services/message.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {GetLaboratoryAnalyseToNotAuthForm} from "../../../shared/forms/auth/get-laboratory-analyse-to-not-auth.form";
import {LaboratoryAnalysesApiClient} from "../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {AnalysesDialogComponent} from "../../analyses/analyses/analyses-dialog/analyses-dialog.component";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public authForm: FormGroup = new FormGroup({
    "authLogin": new FormControl("", Validators.required),
    "authPassword": new FormControl("", Validators.required)
  });

  public getLaboratoryAnalyseForm: FormGroup = new FormGroup({
    "laboratoryAnalyseNumber": new FormControl("", [
      Validators.required,
      Validators.pattern("^[0-9]*$")
    ]),
    "laboratoryAnalyseLastName": new FormControl("", Validators.required)
  });

  public isLogin: boolean = true;
  public isProgress: boolean = false

  constructor(private readonly _auth: AuthApiClient,
              private readonly _authChecker: AuthCheckerService,
              private readonly _analyses: LaboratoryAnalysesApiClient,
              private readonly  _router: Router,
              private readonly _messages: MessageService,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    if(this._authChecker.isAuth()) {
      this.goToMainPage();
    }
  }

  public getLaboratoryAnalyse(): void{
    const form: GetLaboratoryAnalyseToNotAuthForm = {
      id: this.getLaboratoryAnalyseForm.controls['laboratoryAnalyseNumber'].value,
      lastName: this.getLaboratoryAnalyseForm.controls['laboratoryAnalyseLastName'].value
    };

    this._analyses.getLaboratoryAnalyseId(form).subscribe(res => {
      if(res.isNotCorrect)
        this._messages.showMessage(res.error.message)

      if(res.isCorrect) {
        this._dialog.open(AnalysesDialogComponent, {
          data: res.result
        });
      }
    });
  }

  public login(): void {
    this.isProgress = true

    const form: LoginForm = {
      login: this.authForm.controls['authLogin'].value,
      password: this.authForm.controls['authPassword'].value
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
    this._router.navigate(['laboratory/analyses']);
  }
}
