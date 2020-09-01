// 08/31/2020 06:44 pm - SSN - [20200831-1843] - [001] - M11-08 - Your first Angular component
// 08/31/2020 10:00 pm - SSN - [20200831-2156] - [002] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:36 pm - SSN - [20200831-2314] - [003] - M12-03 - Calling the API
// 09/01/2020 02:34 am - SSN - [20200901-0108] - [002] - M12-04 - Using type safety

import { Component, OnInit } from "@angular/core";

import { DataService } from "../shared/dataService";
import { IProduct } from "../shared/product";

import { ICred } from "../shared/ICred";
import { IToken } from '../shared/IToken';

@Component( {
    selector: "product-list",
    templateUrl: "./productList.component.html",
    styleUrls: []
} )
export class ProductList implements OnInit {

    constructor( private data: DataService ) {

        this.products = data.products;
    }

    public products: IProduct[] = [];

    ngOnInit(): void {

        let creds: ICred = {

            username: "john@doe.com",
            password: "P@ssw0rd!101!"
        };

        this.data.getToken( creds ).subscribe( ( data1: IToken ) => {

            this.loadData( data1 );

        } );



    }



    loadData( token: IToken ): void {

        this.data.loadProducts( token ).subscribe( success => {
            if ( success ) {
                this.products = this.data.products;
            }
        } );

    }


}