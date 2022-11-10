
// 09/01/2020 06:44 pm - SSN - [20200901-1826] - [002] - M13-02 Add routing to the project


import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'the-shop',
    templateUrl: './shop.component.html',
    styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

    // 11/09/2022 11:37 pm - SSN - Added
    cartIsVisible: boolean = false;

    constructor() {
    }

    ngOnInit(): void {
    }


    // 11/09/2022 11:37 pm - SSN - Added

    onToggleCartDisplay() {

        this.cartIsVisible = !this.cartIsVisible;
    }


}
