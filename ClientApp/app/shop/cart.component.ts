
// 09/01/2020 03:29 pm - SSN - [20200901-1439] - [001] - M12-06 - Creating another component

// ng g c app/shop/cart --flat --inlineTemplate=false

import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";

@Component( {
  selector: "the-cart",
  templateUrl: "./cart.component.html",
  styles: [
  ]
} )
export class CartComponent implements OnInit {

  constructor( public data: DataService ) {


  }

  ngOnInit(): void { }



}
