// 08/31/2020 10:32 pm - SSN - [20200831-2156] - [004] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:27 pm - SSN - [20200831-2314] - [002] - M12-03 - Calling the API

import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { ProductList } from "./shop/productList.component";
import { DataService } from "./shared/dataService";
import { HttpClientModule } from "@angular/common/http";
import { CartComponent } from './shop/cart.component';

@NgModule( {
    declarations: [ AppComponent, ProductList, CartComponent ],
    imports: [
        BrowserModule,
        HttpClientModule
    ],

    providers: [ DataService ],
    bootstrap: [ AppComponent ],
} )
export class AppModule { }
