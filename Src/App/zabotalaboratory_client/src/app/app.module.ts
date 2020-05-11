import {NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { JwtModule } from "@auth0/angular-jwt";
import {TokenGetter} from "./shared/consts/tokenGetter";
import {DefaultUrls} from "./shared/consts/defaultUrls";

import { AppComponent } from './app.component';
import { LoginComponent } from './modules/auth/pages/login/login.component';
import {AnalysesComponent} from "./modules/main/pages/analyses/analyses.component";
import {HeaderComponent} from "./modules/main/components/header/header.component";
import {MaterialModule} from "./modules/material.module";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AnalysesComponent,
    HeaderComponent
  ],
  imports: [
    MaterialModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: TokenGetter.GetToken,
        whitelistedDomains: [DefaultUrls.Domain],
        blacklistedRoutes: []
      }
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [
    MaterialModule
  ]
})
export class AppModule { }
