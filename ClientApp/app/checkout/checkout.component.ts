import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';
import { IOrderItem } from '../shared/IOrderItem';
import { IOrder } from '../shared/IOrder';

@Component( {
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: [ 'checkout.component.css' ]
} )

export class Checkout implements OnInit {

  constructor( public data: DataService, public router: Router ) {
  }
  ngOnInit(): void {
    if ( this.data.order.items.length === 0 ) {
      this.router.navigate( [ "/" ] );
    }
  }

  errorMessages: Array<string> = new Array<string>();

  onCheckout() {

    this.data.checkout().subscribe( response => {


      this.data.order_Confirmed = response as IOrder;


      if ( this.data.order_Confirmed.orderId && this.data.order_Confirmed.orderId > 0 ) {

        this.router.navigate( [ 'confirmation' ], { replaceUrl: true } )
      }
      else {
        this.errorMessages.push( "System Error: (1) " );
      }
    }, error => {

      this.errorMessages.push( "System Error: (2)" );

      console.log( error );
      console.log( error.error.errorMessage );
      console.log( error.error.errorNo );


      for ( let e in error.error.errorList ) {

        for ( let i2 = 0; i2 < error.error.errorList[ e ].length; i2++ ) {
          this.errorMessages.push( error.error.errorList[ e ][ i2 ] );

        }
      }

      this.errorMessages.push( "Error: " + error.error.errorMessage );
      this.errorMessages.push( "Error Number: " + error.error.errorNo );


    } );

  }

  addQty( orderItem: IOrderItem, qty: number ) {

    let item = this.data.order.items.find( oi => oi.productId == orderItem.productId );

    if ( item ) {

      item.quantity = item.quantity + qty;

      if ( item.quantity <= 0 ) {
        this.data.order.items = this.data.order.items.filter( oi => oi.productId != orderItem.productId );
      }

    }
  }
}