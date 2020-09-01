// 08/31/2020 06:44 pm - SSN - [20200831-1843] - [001] - M11-08 - Your first Angular component

import { Component } from '@angular/core';

@Component({
    selector: "product-list",
    templateUrl: "./productList.component.html",
    styleUrls:[]
})
export class ProductList {

    public products = [
        {
            title: 'First product',
            price: 19.99
        },
        {
            title: 'Second product',
            price: 9.99
        },
        {
            title: 'Third product',
            price: 14.99
        },
    ]
}