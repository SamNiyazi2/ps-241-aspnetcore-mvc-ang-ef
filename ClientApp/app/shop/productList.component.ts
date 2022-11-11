// 08/31/2020 06:44 pm - SSN - [20200831-1843] - [001] - M11-08 - Your first Angular component
// 08/31/2020 10:00 pm - SSN - [20200831-2156] - [002] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:36 pm - SSN - [20200831-2314] - [003] - M12-03 - Calling the API
// 09/01/2020 02:34 am - SSN - [20200901-0108] - [002] - M12-04 - Using type safety
// 09/01/2020 04:27 pm - SSN - [20200901-1547] - [006] - M12-07 - Sharing data across components

import { Component, OnInit } from "@angular/core";

import { DataService } from "../shared/dataService";
import { IProduct } from "../shared/product";

import { ICred } from "../shared/ICred";
import { IToken } from "../shared/IToken";
import { pipe } from 'rxjs';
import { CONSTANTS } from '../shared/constants';
import { Router } from '@angular/router';
import { timeout } from 'rxjs/operators';



@Component({
    selector: "product-list",
    templateUrl: "./productList.component.html",
    styleUrls: ["productList.component.css"]
})
export class ProductList implements OnInit {

    // 11/10/2022 01:24 pm - SSN - Inject Router
    constructor(public data: DataService, private router: Router) {

        this.products = data.products;
    }

    public products: IProduct[] = [];

    ngOnInit(): void {

        let creds: ICred = {

            username: "john@doe.com",
            password: "P@ssw0rd!101!"
        };

        this.data.getToken(creds).subscribe(pipe((data1: IToken) => {

            console.log('%c ' + 'productList-20221110-0845', 'color:yellow;font-size:10pt;');
            console.log('%c ' + 'data1:', 'color:yellow;font-size:10pt;');

            console.dir(data1);

            this.loadData(data1);

        }), error => {

            console.log('%c ' + 'productList-20221110-1229', 'color:red;font-size:10pt;');
            console.log('%c ' + 'Faild to getToken:', 'color:yellow;font-size:10pt;');

            console.dir(error);


            if (error.error.errorMessage) {
                console.log('%c ' + 'productList-20221110-1246-C', 'color:yellow;font-size:12pt;');
                console.dir(error.error.errorMessage);
                console.dir(CONSTANTS);

                // Invalid logic
                if (CONSTANTS.ERROR_MESSAGES.INVALID_ACCESS_20221110_1159_A == error.error.errorMessage) {
                    console.log('%c ' + 'productList-20221110-1246-D - Route to login', 'color:yellow;font-size:10pt;');

                    this.router.navigate(['login']);
                }

                if (CONSTANTS.ERROR_MESSAGES.INVALID_ACCESS_20221110_1159_B == error.error.errorMessage) {
                    console.log('%c ' + 'productList-20221110-1246-E - Route to login', 'color:yellow;font-size:10pt;');

                    this.router.navigate(['login']);
                }
            }

        });



    }



    loadData(token: IToken): void {

        this.data.loadProducts(token).subscribe(success => {
            if (success) {
                this.products = this.data.products;
            }
        });

    }


    // 09/01/2020 04:27 pm - SSN - [20200901-1547] - [006] - M12-07 - Sharing data across components
    addProduct(product: IProduct, qty: number = 1): void {

        this.data.addToOrder(product, qty);
    }

}