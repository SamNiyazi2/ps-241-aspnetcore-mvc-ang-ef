import { Component, OnInit } from '@angular/core';
import { DataService } from '../../shared/dataService';
import { Router } from '@angular/router';

@Component( {
  selector: 'app-confirmation',
  template: `
    <p>
      Your order has been submitted.
    </p>
    
    <p *ngIf="this.data.order_Confirmed" >Your order numbers is {{ this.data.order_Confirmed.orderNumber }}.</p>
    <p>Thank you.</p>

<br/>

    <button class="btm btn-primary"  (click)="confirmed()">Home page</button>
  `,
  styles: [
  ]
} )
export class ConfirmationComponent implements OnInit {


  constructor( public data: DataService, private router: Router ) { }



  ngOnInit(): void {

    if ( this.data.order_Confirmed == null ) {
      this.router.navigate( [ '/' ] );
    }

  }

  confirmed() {

    this.router.navigate( [ '/' ] );
    this.data.order_Confirmed = null;

  }



}
