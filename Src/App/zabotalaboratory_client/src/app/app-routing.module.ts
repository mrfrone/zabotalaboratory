import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuthGuard} from "./core/guards/auth-guard";

import {LoginComponent} from "./pages/auth/login/login.component";
import {AnalysesComponent} from "./pages/analyses/analyses/analyses.component";
import {AddAnalysesComponent} from "./pages/analyses/add-analyses/add-analyses.component";
import {AnalysesTestsComponent} from "./pages/analyses/analyses-tests/analyses-tests.component";
import {AnalysesTypesComponent} from "./pages/analyses/analyses-types/analyses-types.component";
import {HeaderComponent} from "./pages/layers/header/header.component";


const routes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: 'analyses',
    component: HeaderComponent,
    canActivate: [AuthGuard],
    children: [
      {path: '', component: AnalysesComponent},
      {path: 'add', component: AddAnalysesComponent},
      {path: 'tests', component: AnalysesTestsComponent},
      {path: 'types', component: AnalysesTypesComponent},
    ]
  },
  //{ path: 'analyses/add', component: AddAnalysesComponent, canActivate: [AuthGuard] },
  //{ path: 'analyses/tests', component: AnalysesTestsComponent, canActivate: [AuthGuard] },
  //{ path: 'analyses/types', component: AnalysesTypesComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: 'analyses' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
