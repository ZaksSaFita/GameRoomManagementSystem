import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {AdminDashboardComponent} from './admin-dashboard/admin-dashboard.component';
import {DeviceListComponent} from './device-list/device-list.component';
import {UserListComponent} from './user-list/user-list.component';
import {EventListComponent} from './event-list/event-list.component';
import {ShopListComponent} from './shop-list/shop-list.component';
import {GameSessionComponent} from './game-session/game-session.component';

const routes: Routes = [
  {
    path: '', component: AdminLayoutComponent, children: [
      {path: '', redirectTo: 'admin-dashboard', pathMatch: 'full'},
      {path: 'admin-dashboard', component: AdminDashboardComponent},
      {path: 'device-list', component: DeviceListComponent},
      {path: 'user-list', component: UserListComponent},
      {path: 'event-list', component: EventListComponent},
      {path: 'shop-list', component: ShopListComponent},
      {path: 'game-session', component: GameSessionComponent},


      {path: '**', component: AdminDashboardComponent}
    ]

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
