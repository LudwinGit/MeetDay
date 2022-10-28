import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes =[
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'appointments',
    loadChildren: () => import('./appointment/appointment.module').then(m=>m.AppointmentModule)
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
