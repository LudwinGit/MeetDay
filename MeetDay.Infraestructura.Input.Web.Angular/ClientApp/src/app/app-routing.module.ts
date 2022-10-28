import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/skeleton/pages/dashboard/dashboard.component';

const routes: Routes =[
  {
    path: 'auth',
    loadChildren: () => import('./components/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    loadChildren: () => import('./components/skeleton/skeleton.module').then(m=>m.SkeletonModule)
  },
  {
    path: '**',
    redirectTo: 'auth'
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
     
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
