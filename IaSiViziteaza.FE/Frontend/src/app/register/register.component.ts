import { Component, OnInit } from '@angular/core';
import { ATypeService } from '../atype/atype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public email = '';
  public nume = '';
  public prenume = '';
  public nrtelefon = '';
  public password = '';
  htmlToAdd: string;
  constructor(private atypeService: ATypeService, private router: Router ) { }
  Register() {
    this.atypeService.postUser({ email: this.email, firstName: this.nume, lastName: this.prenume ,
      phoneNumber: this.nrtelefon , password: this.password })
      .subscribe((data) => {
        console.log('Status user : ' + data);
        if (data === true) {
          this.router.navigateByUrl('/login');
        } else {
          this.htmlToAdd = '<div class="alert alert-danger text-center"><strong>Wrong pass or email</strong> </div>';
        }
      });
  }
  ngOnInit() {
  }

}
