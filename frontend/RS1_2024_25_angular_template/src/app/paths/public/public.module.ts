import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {PublicRoutingModule} from './public-routing.module';
import {PublicHomeComponent} from './public-home/public-home.component';
import {PublicLayoutComponent} from './public-layout/public-layout.component';
import {FormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';


@NgModule({
  declarations: [
    PublicHomeComponent,
    PublicLayoutComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    FormsModule,
    RouterModule
  ]
})
export class PublicModule {


}
