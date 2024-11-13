import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AdminRoutingModule} from './admin-routing.module';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {AdminDashboardComponent} from './admin-dashboard/admin-dashboard.component';
import {AdminUsersComponent} from './admin-users/admin-users.component';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    AdminDashboardComponent,
    AdminUsersComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule {
}
