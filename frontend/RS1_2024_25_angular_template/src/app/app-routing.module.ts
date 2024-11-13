import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RoleGuard} from './services/auth-services/role-guard.service';

const routes: Routes = [

  {
    path: 'admin',
    canActivate: [RoleGuard],
    data: {expectedRole: 'Admin'},
    loadChildren: () => import('./paths/admin/admin.module').then(m => m.AdminModule)  // Lazy load  modula
  },
  {
    path: 'employee',
    canActivate: [RoleGuard],
    data: {expectedRole: 'Admin, Employee'},
    loadChildren: () => import('./paths/admin/admin.module').then(m => m.AdminModule)  // Lazy load  modula
  },
  {
    path: 'user',
    loadChildren: () => import('./paths/user/user.module').then(m => m.UserModule)  // Lazy load  modula
  },
  {
    path: 'public',
    // canActivate: [RoleGuard],
    // data: {expectedRole: 'User'},
    loadChildren: () => import('./paths/public/public.module').then(m => m.PublicModule)  // Lazy load  modula
  },
  {
    path: 'auth', loadChildren: () => import('./paths/auth/auth.module').then(m => m.AuthModule)
  },
  {path: '**', redirectTo: 'public', pathMatch: 'full'},  // Default ruta koja vodi na public
  {path: '', redirectTo: 'public', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
