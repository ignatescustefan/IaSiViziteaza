import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ATypeService } from 'src/app/atype/atype.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  public guid: any;
  public comments: [];
  public commentContent = '';
  public isAdmin = localStorage.getItem('isAdmin');
  public isAuthenticate = localStorage.getItem('authenticate');
  public hasLiked: boolean[] = [] ;
  public attrTitle = '';
  public attrImage: any;
  constructor(private activatedRoute: ActivatedRoute, private atypeService: ATypeService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((data) => {
      this.guid = data.id;
      this.getComment(data.id);
    });

    this.atypeService.getAttractionsById(this.guid).subscribe((data) => {
      this.attrTitle = data.name;
      this.attrImage = data.image;
      console.log('Status', data);
    });
  }

  getComment(id) {
    this.atypeService.getComment(id).subscribe((data) => {
      this.comments = data;
      console.log(data);
    });
  }

  save() {
    this.atypeService.postComment({attractionId: this.guid,
      commentContent: this.commentContent, userEmail: localStorage.getItem('userEmail') })
      .subscribe((data) => {
        console.log('Comment save : ' + data);
      });
    window.location.reload();
  }
  delete(idComment) {
    this.atypeService.deleteComment(idComment)
    .subscribe((data) => {
      console.log('Comment deleted : ' + data);
      window.location.reload();
    });
  }
  addLike(num: number, idComm: any) {
    this.hasLiked[num] = ! this.hasLiked[num];
    this.atypeService.UpdateComment({id: idComm, status: this.hasLiked[num]})
    .subscribe((data) => {
      console.log(data);
    });
    window.location.reload();
    console.log(this.comments[num]);
 }
}
