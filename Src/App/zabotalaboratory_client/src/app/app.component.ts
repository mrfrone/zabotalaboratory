import { Component } from '@angular/core';
import {AuthCheckerService} from "./core/services/auth-checker.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(public readonly _isAuth: AuthCheckerService) {
  }
}
