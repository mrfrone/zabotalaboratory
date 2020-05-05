import { Component, OnInit } from '@angular/core';
import {MatInput} from "@angular/material/input";
import {MatButton} from "@angular/material/button";
import {Auth} from "../../../core/apiClient/auth";
import {LoginForm} from "../../../shared/forms/LoginForm";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private log: string = ''
  private pass: string = ''

  constructor(private _auth: Auth) { }

  ngOnInit(): void {
  }

  Login(){
    const form: LoginForm = {
      log: this.log,
      pass: this.pass
    }
    this._auth.Authorize(form)
  }
}
