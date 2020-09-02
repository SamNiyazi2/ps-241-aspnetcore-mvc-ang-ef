// 08/31/2020 10:32 pm - SSN - [20200831-2156] - [004] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:27 pm - SSN - [20200831-2314] - [002] - M12-03 - Calling the API
// 09/01/2020 06:37 pm - SSN - [20200901-1826] - [001] - M13-02 Add routing to the project

import { BrowserModule } from "@angular/platform-browser";
import { NgModule, Component } from '@angular/core';

import { AppComponent } from "./app.component";
import { ProductList } from "./shop/productList.component";
import { DataService } from "./shared/dataService";
import { HttpClientModule } from "@angular/common/http";
import { CartComponent } from './shop/cart.component';

import { RouterModule } from "@angular/router";
import { ShopComponent } from './shop/shop.component';
import { Checkout } from './checkout/checkout.component';


let routes = [

    { path: "", component: ShopComponent },
    { path: "checkout", component: Checkout }
];


@NgModule( {
    declarations: [ AppComponent, ProductList, CartComponent, ShopComponent, Checkout ],
    imports: [
        BrowserModule,
        HttpClientModule,
        RouterModule.forRoot( routes, {
            useHash: true,
            enableTracing: false  // for debugging 
        } )
    ],

    providers: [ DataService ],
    bootstrap: [ AppComponent ],
} )
export class AppModule { }
