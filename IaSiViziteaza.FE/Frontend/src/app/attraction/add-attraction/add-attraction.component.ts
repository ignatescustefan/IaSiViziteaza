import { Component, OnInit } from '@angular/core';
import { ATypeService } from 'src/app/atype/atype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-attraction',
  templateUrl: './add-attraction.component.html',
  styleUrls: ['./add-attraction.component.scss']
})
export class AddAttractionComponent implements OnInit {
  constructor(private atypeService: ATypeService, private router: Router) { }
  public title: '';
  public name: '';
  public description: '';
  public phoneNumber: '';
  public address: '';
  public postalCode: '';
  public image: '';
  public openTime: '';
  public closeTime: '';
  public attractiontypes = [];
  public htmlToAdd: string;
localUrl: any[];
  save() {
    this.atypeService.postAttraction({
      title: this.title, name: this.name, description: this.description, emailUser: localStorage.getItem('userEmail'),
      phoneNumber: this.phoneNumber, address: this.address, postalCode: this.postalCode,
      image: this.localUrl, openTime: this.openTime, closeTime: this.closeTime
    })
      .subscribe((data) => {
        console.log('Attraction-ul a fost salvat', data);
        if (data === true) {
          this.router.navigateByUrl('/');
        } else {
        this.htmlToAdd = '<div class="alert alert-danger text-center"><strong>Attraction saving error.</strong> </div>';
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
      this.atypeService.getAType().subscribe((data) => {
        this.attractiontypes = data;
      });
    }

}
