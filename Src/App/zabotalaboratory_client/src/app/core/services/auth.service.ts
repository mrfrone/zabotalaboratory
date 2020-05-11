import {Injectable} from "@angular/core";
import {LoginForm} from "../../shared/forms/LoginForm";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../shared/models/zabota-result/zabota-result";
import {Jwt} from "../../shared/models/jwt/jwt";
import {AuthApiClient} from "../apiClient/auth.api-client";
import {Router} from "@angular/router";
import {MessageService} from "./message.service";
import {JwtHelperService} from "@auth0/angular-jwt";
import {take} from "rxjs/operators";

@Injectable({providedIn: 'root'})
export class AuthService {
  constructor(private readonly _auth: AuthApiClient,
              private readonly _router: Router,
              private readonly _message: MessageService,
              private readonly _jwtService: JwtHelperService) {
  }

  public authorize(form: LoginForm): Observable<ZabotaResult<Jwt>> {
    const apiResult = this._auth.authorize(form).pipe(
      take(1)
    );

    apiResult.subscribe(res => this.onAuthorized(res));

    return apiResult;
  }

  private onAuthorized(res: ZabotaResult<Jwt>): void {
    if (res.isCorrect === true) {
      localStorage.setItem("jwt", res.result.token);
      this._message.showMessage('Авторизация успешна');
      this._router.navigate(["analyses"]);
    } else {
      this._message.showMessage(res.error.message);
    }
  }

  public logOut(): Observable<ZabotaResult<boolean>> {
    const apiResult = this._auth.logOut().pipe(
      take(1)
    );

    apiResult.subscribe(res => this.onLogOut(res));

    return apiResult;
  }
  private onLogOut(res: ZabotaResult<boolean>): void{
    if(res.isCorrect === true){
      localStorage.removeItem('jwt');
      this._message.showMessage('Выход из аккаунта успешно выполнен')
      this._router.navigate([""]);
    }
    else{
      this._message.showMessage(res.error.message)
    }
  }

  public getRole(): string {
    const apiResult = this._auth.getRole().pipe(
      take(1)
    );

    let result: string;
    apiResult.subscribe(res =>
    {
      this.onGetRole(res)
      result = res.result;
    });

    return result;
  }
  private onGetRole(res: ZabotaResult<string>): void{
    if(res.isNotCorrect === true)
    {
      this._message.showMessage(res.error.message)
    }
  }
}
