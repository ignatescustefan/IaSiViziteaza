import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ATypeService } from '../atype.service';

@Component({
  selector: 'app-attr-by-title',
  templateUrl: './attr-by-title.component.html',
  styleUrls: ['./attr-by-title.component.scss']
})
export class AttrByTitleComponent implements OnInit {

public title = '';
public attractions = [];
public hasLiked: boolean[] = [] ;
public isAdmin = localStorage.getItem('isAdmin');
public isAuthenticate = localStorage.getItem('authenticate');

  constructor(private activatedRoute: ActivatedRoute, private atypeService: ATypeService) { }


  ngOnInit() {
    this.activatedRoute.params.subscribe((data) => {
      this.title = data.title;
      this.getAttractionsByTitle(data.title);
    });
  }
  getAttractionsByTitle(title) {
    this.atypeService.getAttractionsByTitle(title).subscribe((data) => {
      this.attractions = data;
    });
  }
  addLike(num: number) {
    this.hasLiked[num] = ! this.hasLiked[num];
    this.atypeService.LikeCount({id: this.attractions[num].attractionId, status: this.hasLiked[num]})
    .subscribe((data) => {
      console.log(data);
    });
    window.location.reload();
    console.log(this.attractions[num]);
 }
 delete(idAttraction) {
  this.atypeService.deletedAttraction(idAttraction)
  .subscribe((data) => {
    console.log('Attraction deleted : ' + data);
    window.location.reload();
  });
}
}
