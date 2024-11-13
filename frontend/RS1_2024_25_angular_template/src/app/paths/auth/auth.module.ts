import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AuthRoutingModule} from './auth-routing.module';
import {AuthLayoutComponent} from './auth-layout/auth-layout.component';
import {RegisterComponent} from './register/register.component';
import {LogoutComponent} from './logout/logout.component';
import {TwoFactorComponent} from './two-factor/two-factor.component';
import {ForgetPasswordComponent} from './forget-password/forget-password.component';
import {FormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    AuthLayoutComponent,
    RegisterComponent,
    LogoutComponent,
    TwoFactorComponent,
    ForgetPasswordComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule
  ]
})
export class AuthModule {
}
