import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginForm} from "../../shared/forms/LoginForm";

@Injectable({providedIn: 'root'})

export class Auth{
  constructor(private http: HttpClient) {}

  Authorize(form: LoginForm){

    console.log(form)
    //this.http.post('', form)
  }
}
