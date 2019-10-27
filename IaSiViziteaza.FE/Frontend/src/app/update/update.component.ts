import { Component, OnInit } from '@angular/core';
import { ATypeService } from '../atype/atype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  public newEmail = '';
  public newPass = '';
  public phoneNr = '';
  public status = false;
  htmlToAdd: string;
  constructor(private atypeService: ATypeService, private router: Router) { }
  Update() {
    this.atypeService.UpdateUser({ currentEmail: localStorage.getItem('userEmail') ,
     newEmail: this.newEmail, newPassword: this.newPass, phoneNumber: this.phoneNr })
      .subscribe((data) => {
        console.log('Status user : ' + data);
        if (data === true) {
          this.router.navigateByUrl('/login');
        } else {
          this.status = true;
        }
      });
  }
  ngOnInit() {
  }
}
