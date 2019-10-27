import { Component, OnInit } from '@angular/core';
import { ATypeService } from 'src/app/atype/atype.service';

@Component({
  selector: 'app-getlist',
  templateUrl: './getlist.component.html',
  styleUrls: ['./getlist.component.scss']
})
export class GetlistComponent implements OnInit {
  public attractions = [];
  public hasLiked: boolean[] = [] ;
  public isAdmin = localStorage.getItem('isAdmin');
  public isAuthenticate = localStorage.getItem('authenticate');

  constructor(private atypeService: ATypeService) { }

  ngOnInit() {
    this.atypeService.getAttractions().subscribe((data) => {
      this.attractions = data;
      console.log(data);
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
