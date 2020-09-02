import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component( {
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
} )
export class LoginComponent implements OnInit {

  // 09/01/2020 09:17 pm - SSN - [20200901-2107] - [001] - M13-04 - Use form binding

  constructor( private data: DataService, private router: Router ) { }

  ngOnInit(): void {
  }

  errorMessage: string = "";

  public creds = {
    username: "",
    password: ""
  }


  onLogin() {
    console.log( 'login.component.ts - 20200901-2124' );
    console.log( this.creds );

    this.errorMessage = "";


    this.data.login( this.creds ).subscribe( success => {
      if ( success ) {
        if ( this.data.order.items.length === 0 ) {
          this.router.navigate( [ '/' ] );
        }
        else {
          this.router.navigate( [ '/chcekout' ] );

        }
      } else {
        this.errorMessage = "Failed to login";

      }
    }, error => {
      this.errorMessage = "Failed to login";
    } );

  }
}
