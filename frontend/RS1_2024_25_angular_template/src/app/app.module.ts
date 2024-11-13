import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {AppRoutingModule} from './app-routing.module'; // Uvoz rute modula
import {AppComponent} from './app.component';
import {AuthGuardService} from './services/auth-services/auth-guard.service';
import {RoleGuard} from './services/auth-services/role-guard.service';
import {AuthService} from './services/auth-services/auth.service';
import {RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule, // Modul za forme
    AppRoutingModule,
    RouterModule,
    HttpClientModule,

  ],
  providers: [
    AuthService, // Pružanje Auth Service-a
    AuthGuardService, // Pružanje Auth Guard-a
    RoleGuard // Pružanje Role Guard-a
  ],
  bootstrap: [AppComponent] // Bootstrap glavne aplikacije
})
export class AppModule {
}
