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
import { LoginComponent } from './pages/auth/login/login.component';
import {AnalysesComponent} from "./pages/analyses/analyses/analyses.component";
import {HeaderComponent} from "./pages/layers/header/header.component";
import {AddAnalysesComponent} from "./pages/analyses/add-analyses/add-analyses.component";
import {AnalysesTestsComponent} from "./pages/analyses/analyses-tests/analyses-tests.component";
import { AnalysesTestsDialogComponent } from './pages/analyses/analyses-tests/analyses-tests-dialog/analyses-tests-dialog.component';
import { AnalysesTypesComponent } from './pages/analyses/analyses-types/analyses-types.component';
import { AnalysesTypesDialogComponent } from './pages/analyses/analyses-types/analyses-types-dialog/analyses-types-dialog.component';
import { IdentitiesSettingsComponent } from './pages/users/identities-settings/identities-settings.component';
import { IdentitiesSettingsDialogComponent } from './pages/users/identities-settings/identities-settings-dialog/identities-settings-dialog.component';
import { SubRolesSettingsComponent } from './pages/users/sub-roles-settings/sub-roles-settings.component';
import { SubRolesSettingsDialogComponent } from './pages/users/sub-roles-settings/sub-roles-settings-dialog/sub-roles-settings-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AnalysesComponent,
    HeaderComponent,
    AddAnalysesComponent,
    AnalysesTestsComponent,
    AnalysesTestsDialogComponent,
    AnalysesTypesComponent,
    AnalysesTypesDialogComponent,
    IdentitiesSettingsComponent,
    IdentitiesSettingsDialogComponent,
    SubRolesSettingsComponent,
    SubRolesSettingsDialogComponent
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
        tokenGetter: TokenGetter.getToken,
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
