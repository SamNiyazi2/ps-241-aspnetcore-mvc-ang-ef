
// 08/31/2020 09:58 pm - SSN - [20200831-2156] - [001] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:19 pm - SSN - [20200831-2314] - [001] - M12-03 - Calling the API


import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { Observable } from 'rxjs';

@Injectable()
export class DataService {

    constructor( private http: HttpClient ) { }

    public products = [];

    loadProducts(): Observable<boolean> {
        return this.http.get( "/api/products" )
            .pipe(
                map( ( data: any[] ) => {
                    this.products = data;
                    return true;
                } )
            );
    }
}
