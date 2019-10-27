import { Component, OnInit } from '@angular/core';
import { ATypeService } from '../atype.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  public attractiontypes = [];
  public isAdmin = localStorage.getItem('isAdmin');
  constructor(private atypeService: ATypeService) {}

  ngOnInit() {
    this.atypeService.getAType().subscribe((data) => {
      this.attractiontypes = data;
    });
  }
  delete(idAttrType) {
    this.atypeService.deletedAttractionType(idAttrType)
    .subscribe((data) => {
      console.log('Attraction type deleted : ' + data);
      window.location.reload();
    });
  }
}
