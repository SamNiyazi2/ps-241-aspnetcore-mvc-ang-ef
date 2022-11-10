
// 09/01/2020 03:29 pm - SSN - [20200901-1439] - [001] - M12-06 - Creating another component

// ng g c app/shop/cart --flat --inlineTemplate=false

// 09/01/2020 07:50 pm - SSN - [20200901-1940] - [003] - M13-03 - Support login

import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Router } from '@angular/router';
import { IProduct } from '../shared/product';

@Component( {
  selector: "the-cart",
  templateUrl: "./cart.component.html",
  styleUrls: [ "cart.component.css" ]
} )
export class CartComponent implements OnInit {

  constructor( public data: DataService, private router: Router ) {


  }

  ngOnInit(): void { }



  onCheckout(): void {

    if ( this.data.loginRequired ) {
      this.router.navigate( [ 'login' ] );
    } else {
      this.router.navigate( [ 'checkout' ] );
    }
  }


    // 11/10/2022 01:12 am - SSN - Copied from productList.component.ts
    addProduct(product: IProduct, qty: number = 1): void {

        this.data.addToOrder(product, qty);
    }



}
