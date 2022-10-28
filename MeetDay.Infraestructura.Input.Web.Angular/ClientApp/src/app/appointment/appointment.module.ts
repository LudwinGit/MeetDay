import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppointmentRoutingModule } from './appointment-routing.module';
import { NewComponent } from './pages/new/new.component';
import { EditComponent } from './pages/edit/edit.component';
import { ListComponent } from './pages/list/list.component';


@NgModule({
  declarations: [
    NewComponent,
    EditComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    AppointmentRoutingModule
  ]
})
export class AppointmentModule { }
