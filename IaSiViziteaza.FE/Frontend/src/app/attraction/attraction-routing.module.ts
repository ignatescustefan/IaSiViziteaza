import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetlistComponent } from './getlist/getlist.component';
import { AddAttractionComponent } from './add-attraction/add-attraction.component';
import { DetailsComponent } from './details/details.component';


const routes: Routes = [
  {
    path: '',
    component: GetlistComponent
  },
{
  path: 'add',
  component: AddAttractionComponent
},
{
  path: ':id',
  component: DetailsComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AttractionRoutingModule { }
