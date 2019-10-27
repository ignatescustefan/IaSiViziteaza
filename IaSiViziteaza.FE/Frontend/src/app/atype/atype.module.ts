import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ATypeRoutingModule } from './atype-routing.module';
import { AddAtypeComponent } from './add-atype/add-atype.component';
import { ListComponent } from './list/list.component';
import { FormsModule } from '@angular/forms';
import { AttrByTitleComponent } from './attr-by-title/attr-by-title.component';


@NgModule({
  declarations: [AddAtypeComponent, ListComponent, AttrByTitleComponent],
  imports: [
    CommonModule,
    ATypeRoutingModule,
    FormsModule
  ]
})
export class ATypeModule { }
