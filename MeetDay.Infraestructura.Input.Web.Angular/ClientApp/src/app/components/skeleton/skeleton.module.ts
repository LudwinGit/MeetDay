import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SkeletonRoutingModule } from './skeleton-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { NavMenuTopComponent } from './pages/nav-menu-top/nav-menu-top.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    DashboardComponent,
    NavMenuTopComponent
  ],
  imports: [
    FormsModule,CommonModule,SkeletonRoutingModule
  ]
  , exports:[
    NavMenuTopComponent
  ]
})
export class SkeletonModule { }
