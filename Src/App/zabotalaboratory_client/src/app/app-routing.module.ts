import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuthGuard} from "./core/guards/auth-guard";

import {LoginComponent} from "./pages/auth/login/login.component";
import {HeaderComponent} from "./pages/layers/header/header.component";
import {AnalysesComponent} from "./pages/analyses/analyses/analyses.component";
import {AddAnalysesComponent} from "./pages/analyses/add-analyses/add-analyses.component";
import {AnalysesTestsComponent} from "./pages/analyses/analyses-tests/analyses-tests.component";
import {AnalysesTypesComponent} from "./pages/analyses/analyses-types/analyses-types.component";
import {IdentitiesSettingsComponent} from "./pages/users/identities-settings/identities-settings.component";
import {ClinicsSettingsComponent} from "./pages/analyses/clinics-settings/clinics-settings.component";
import {RolesGuard} from "./core/guards/roles-guard";
import {StaticRoles} from "./shared/consts/staticRoles";
import {UserProfileComponent} from "./pages/users/user-profile/user-profile.component";


const routes: Routes = [
  { path: 'auth', component: LoginComponent },
  {
    path: '',
    component: HeaderComponent,
    canActivate: [AuthGuard],
    children: [
      {path: 'analyses', component: AnalysesComponent},
      {path: 'analyses/add', component: AddAnalysesComponent, canActivate: [RolesGuard], data: { roles: [StaticRoles.admin, StaticRoles.laborant] }},
      {path: 'analyses/tests', component: AnalysesTestsComponent, canActivate: [RolesGuard], data: { roles: [StaticRoles.admin, StaticRoles.laborant] }},
      {path: 'analyses/types', component: AnalysesTypesComponent, canActivate: [RolesGuard], data: { roles: [StaticRoles.admin, StaticRoles.laborant] }},
      {path: 'users', component: IdentitiesSettingsComponent, canActivate: [RolesGuard], data: { roles: [StaticRoles.admin] }},
      {path: 'users/clinics', component: ClinicsSettingsComponent, canActivate: [RolesGuard], data: { roles: [StaticRoles.admin] }},
      {path: 'profile', component: UserProfileComponent},
      {path: '**', redirectTo: 'auth'}
    ]
  },
  { path: '**', redirectTo: 'auth' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
