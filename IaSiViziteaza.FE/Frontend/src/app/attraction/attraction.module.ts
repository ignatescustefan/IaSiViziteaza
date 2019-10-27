import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AttractionRoutingModule } from './attraction-routing.module';
import { GetlistComponent } from './getlist/getlist.component';
import { AddAttractionComponent } from './add-attraction/add-attraction.component';
import { FormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';


@NgModule({
  declarations: [GetlistComponent, AddAttractionComponent, DetailsComponent],
  imports: [
    CommonModule,
    AttractionRoutingModule,
    FormsModule
  ]
})
export class AttractionModule { }
