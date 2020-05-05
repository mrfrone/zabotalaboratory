import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {MessageService} from "../../../core/services/message.service";
import {AuthService} from "../../../core/services/auth.service";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(private _auth: AuthService,
              private _router: Router,
              private readonly _message: MessageService) { }

  ngOnInit(): void {
  }

  public logOut(): void {
    this._auth.logOut().subscribe();
  }
}
