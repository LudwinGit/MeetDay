import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { EditComponent } from './pages/edit/edit.component';
import { ListComponent } from './pages/list/list.component';
import { CreateComponent } from './pages/create/create.component';
import { SkeletonModule } from '../skeleton/skeleton.module';


@NgModule({
  declarations: [
    EditComponent,
    ListComponent,
    CreateComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    SkeletonModule
  ]
})
export class UsersModule { }
