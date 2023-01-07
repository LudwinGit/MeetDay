import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SkeletonRoutingModule } from './skeleton-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { NavMenuTopComponent } from './pages/nav-menu-top/nav-menu-top.component';
import { FormsModule } from '@angular/forms';
import { FooterComponent } from './pages/footer/footer.component';



@NgModule({
  declarations: [
    DashboardComponent,
    NavMenuTopComponent,
    FooterComponent
  ],
  imports: [
    FormsModule,CommonModule,SkeletonRoutingModule
  ]
  , exports:[
    NavMenuTopComponent, FooterComponent
  ]
})
export class SkeletonModule { }
