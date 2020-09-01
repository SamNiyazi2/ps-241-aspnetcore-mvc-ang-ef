// 08/31/2020 06:44 pm - SSN - [20200831-1843] - [001] - M11-08 - Your first Angular component
// 08/31/2020 10:00 pm - SSN - [20200831-2156] - [002] - M12-02 - Creating a service (Angular)

import { Component } from '@angular/core';

import { DataService }from '../shared/dataService';

@Component({
    selector: "product-list",
    templateUrl: "./productList.component.html",
    styleUrls:[]
})
export class ProductList {

    constructor(data: DataService) {

        this.products = data.products;
    }

    public products = [];


}