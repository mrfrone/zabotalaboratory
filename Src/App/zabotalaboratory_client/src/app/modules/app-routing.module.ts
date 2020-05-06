import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from "./pages/login/login.component";
import {MainComponent} from "./pages/main/main.component";
import {AuthGuard} from "../core/guards/auth-guard";


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'main', component: MainComponent, canActivate: [AuthGuard] },
  {path: '**', redirectTo: 'main'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
