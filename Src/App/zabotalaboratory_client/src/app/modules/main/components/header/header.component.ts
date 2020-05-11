import {Component} from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {map, shareReplay} from 'rxjs/operators';
import {AuthService} from "../../../../core/services/auth.service";
import {ZabotaResult} from "../../../../shared/models/zabota-result/zabota-result";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  public role: string = this._auth.getRole()

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private readonly breakpointObserver: BreakpointObserver,
              private readonly _auth: AuthService) {
  }

  public logOut(): void {
    this._auth.logOut();
  }
}
