import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {SharedRoutingModule} from './shared-routing.module';
import {NavMenuComponent} from './nav-menu/nav-menu.component';


@NgModule({
  declarations: [
    NavMenuComponent
  ],
  exports: [
    NavMenuComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule
  ]
})
export class SharedModule {
}
