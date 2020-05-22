import {NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MaterialModule} from "../assets/material.module";

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { JwtModule } from "@auth0/angular-jwt";
import {TokenGetter} from "./shared/consts/tokenGetter";
import {DefaultUrls} from "./shared/consts/defaultUrls";

import { AppComponent } from './app.component';
import { LoginComponent } from './modules/auth/pages/login/login.component';
import {AnalysesComponent} from "./modules/main/pages/analyses-pages/analyses/analyses.component";
import {HeaderComponent} from "./modules/main/components/header/header.component";
import {AddAnalysesComponent} from "./modules/main/pages/analyses-pages/add-analyses/add-analyses.component";
import {AnalysesTestsComponent} from "./modules/main/pages/analyses-pages/analyses-tests/analyses-tests.component";
import { AnalysesTestsDialogComponent } from './modules/main/pages/analyses-pages/analyses-tests/analyses-tests-dialog/analyses-tests-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AnalysesComponent,
    HeaderComponent,
    AddAnalysesComponent,
    AnalysesTestsComponent,
    AnalysesTestsDialogComponent
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
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [
    MaterialModule
  ]
})
export class AppModule { }
