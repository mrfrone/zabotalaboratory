import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {map, shareReplay, take} from 'rxjs/operators';
import {AuthService} from "../../../../core/services/auth.service";
import {AuthCheckerService} from "../../../../core/services/auth-checker.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public role: string

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private readonly breakpointObserver: BreakpointObserver,
              private readonly _auth: AuthService,
              private readonly _authCheckerService: AuthCheckerService) {
  }

  ngOnInit(): void {
    this._authCheckerService.getRole().pipe(
      take(1)
    ).subscribe(res =>
    {
      this.role = res.result
    });
  }

  public logOut(): void {
    this._auth.logOut();
  }
}
