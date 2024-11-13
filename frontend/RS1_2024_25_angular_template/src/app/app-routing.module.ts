import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuardService} from './services/auth-services/auth-guard.service';

const routes: Routes = [

  {
    path: 'admin',
    canActivate: [AuthGuardService],
    data: {expectedRole: 'Admin'},
    loadChildren: () => import('./paths/admin/admin.module').then(m => m.AdminModule)  // Lazy load  modula
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
