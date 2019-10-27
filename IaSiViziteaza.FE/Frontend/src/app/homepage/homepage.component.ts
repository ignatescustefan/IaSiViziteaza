import { Component, OnInit } from '@angular/core';
import { ATypeService } from '../atype/atype.service';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {

  public attractiontypes = [];

constructor(private atypeService: ATypeService) {}

  ngOnInit() {
    this.atypeService.getAType().subscribe((data) => {
      this.attractiontypes = data;
      console.log(data);
    });
  }
}


