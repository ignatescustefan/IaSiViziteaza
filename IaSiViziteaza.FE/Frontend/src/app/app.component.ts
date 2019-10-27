
import { Component, OnInit } from '@angular/core';
import { ATypeService } from './atype/atype.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
public userEmail = localStorage.getItem('userEmail');
public isAdmin = localStorage.getItem('isAdmin');
public isLoggedin = localStorage.getItem('authenticate');

public background = 'url(\'../../assets/images/teatruv2ps.jpg\')';

public userData = [];
public firstName = '';
public lastName = '';
public phoneNumber = '';


constructor(private atypeService: ATypeService) {}

  public logout() {
    localStorage.setItem('isAdmin', 'false');
    localStorage.setItem('authenticate', 'false');
    localStorage.setItem('userEmail', '');
    window.location.reload();
  }
  ngOnInit() {

    if (this.userEmail.length !== 0) {
      this.atypeService.getUserByemail(this.userEmail).subscribe((data) => {
        this.userData = data;
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.phoneNumber = data.phoneNumber;
        console.log(data);
      });
    }
  }
}
