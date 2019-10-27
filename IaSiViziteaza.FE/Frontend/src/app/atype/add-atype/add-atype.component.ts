import { Component, OnInit } from '@angular/core';
import { ATypeService } from '../atype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-atype',
  templateUrl: './add-atype.component.html',
  styleUrls: ['./add-atype.component.scss']
})
export class AddAtypeComponent implements OnInit {
  public title = '';
  public description = '';
  public Useremail = '';

  localUrl: any[];
  htmlToAdd: string;
  constructor(private atypeService: ATypeService, private router: Router) { }
  save() {
    this.atypeService.postAttrtype({ title: this.title, description: this.description,
      image: this.localUrl, Useremail: localStorage.getItem('userEmail') })
      .subscribe((data) => {
        console.log(data);
        if (data === true) {
          this.router.navigateByUrl('/');
        } else {
          this.htmlToAdd = '<div class="alert alert-danger text-center"><strong>Title not available</strong> </div>';
        }
      });
  }
  showPreviewImage(event: any) {
    if (event.target.files && event.target.files[0]) {
        const reader = new FileReader();
        // tslint:disable-next-line: no-shadowed-variable
        reader.onload = (event: any) => {
            this.localUrl = event.target.result;
        };
        reader.readAsDataURL(event.target.files[0]);
    }
  }
  ngOnInit() {
  }

}
