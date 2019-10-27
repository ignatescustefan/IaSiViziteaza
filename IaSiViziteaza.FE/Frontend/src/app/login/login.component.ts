import { Component, OnInit } from '@angular/core';
import { ATypeService } from '../atype/atype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public email = '';
  public password = '';
  public status = false;
  htmlToAdd: string;
  constructor(private atypeService: ATypeService, private router: Router) { }

  Login() {
    this.atypeService.postLogin({ email: this.email, password: this.password })
      .subscribe((data) => {
        console.log('Login status : ' + data);
        localStorage.setItem('authenticate', data);
        if (localStorage.getItem('authenticate') === 'true') {
          this.status = true;
          this.atypeService.checkUserPriority(this.email).subscribe((data2) => {
           localStorage.setItem('userEmail', this.email);
           localStorage.setItem('isAdmin', data2.adminStatus);
          });
          this.router.navigateByUrl('/');
        } else {
          this.htmlToAdd = '<div class="alert alert-danger text-center"><strong>Wrong pass or email</strong> </div>';
        }
      });
  }

  ngOnInit() {
  }

}
