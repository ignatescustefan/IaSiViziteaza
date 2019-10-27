import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddAtypeComponent } from './add-atype/add-atype.component';
import { ListComponent } from './list/list.component';
import { AttrByTitleComponent } from './attr-by-title/attr-by-title.component';


const routes: Routes = [
  {
    path: '',
    component: ListComponent
  },
  {
  path: 'add',
  component: AddAtypeComponent
  },
  {
  path: ':title',
  component: AttrByTitleComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ATypeRoutingModule { }
