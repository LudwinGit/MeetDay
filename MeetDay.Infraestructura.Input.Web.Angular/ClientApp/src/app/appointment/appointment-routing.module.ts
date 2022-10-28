import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditComponent } from './pages/edit/edit.component';
import { ListComponent } from './pages/list/list.component';
import { NewComponent } from './pages/new/new.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {path:'new', component: NewComponent},
      {path:'edit', component: EditComponent},
      {path:'list', component: ListComponent},
      {path:'**',redirectTo: 'list'}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppointmentRoutingModule { }
