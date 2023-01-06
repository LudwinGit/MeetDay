import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ManagementRoutingModule } from './management-routing.module';
import { CreateComponent } from './pages/create/create.component';
import { EditComponent } from './pages/edit/edit.component';
import { ListComponent } from './pages/list/list.component';
import { SkeletonModule } from "../skeleton/skeleton.module";


@NgModule({
    declarations: [
        CreateComponent,
        EditComponent,
        ListComponent
    ],
    imports: [
        CommonModule,
        ManagementRoutingModule,
        SkeletonModule
    ]
})
export class ManagementModule { }
