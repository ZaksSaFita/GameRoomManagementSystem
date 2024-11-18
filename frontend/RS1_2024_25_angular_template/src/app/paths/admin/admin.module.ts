import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AdminRoutingModule} from './admin-routing.module';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {AdminDashboardComponent} from './admin-dashboard/admin-dashboard.component';
import {AdminUsersComponent} from './admin-users/admin-users.component';
import {DeviceListComponent} from './device-list/device-list.component';
import {FormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import { UserListComponent } from './user-list/user-list.component';
import { ShopListComponent } from './shop-list/shop-list.component';
import { EventListComponent } from './event-list/event-list.component';
import { GameSessionComponent } from './game-session/game-session.component';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    AdminDashboardComponent,
    AdminUsersComponent,
    DeviceListComponent,
    UserListComponent,
    ShopListComponent,
    EventListComponent,
    GameSessionComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule
  ]
})
export class AdminModule {
}
