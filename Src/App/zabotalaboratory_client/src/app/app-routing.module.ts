import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from "./modules/auth/pages/login/login.component";
import {AuthGuard} from "./core/guards/auth-guard";
import {AnalysesComponent} from "./modules/main/pages/analyses/analyses.component";


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'analyses', component: AnalysesComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: 'analyses' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
