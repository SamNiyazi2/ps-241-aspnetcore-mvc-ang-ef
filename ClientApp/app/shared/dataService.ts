import { IOrderItem } from "./IOrderItem";

// 08/31/2020 09:58 pm - SSN - [20200831-2156] - [001] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:19 pm - SSN - [20200831-2314] - [001] - M12-03 - Calling the API
// 09/01/2020 02:34 am - SSN - [20200901-0108] - [003] - M12-04 - Using type safety
// 09/01/2020 04:01 pm - SSN - [20200901-1547] - [005] - M12-07 - Sharing data across components


import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";
import { IProduct } from "./product";
import { ICred } from "./ICred";
import { IToken } from "./IToken";
import { IOrder } from "./IOrder";
import { Order } from "./Order";
import { OrderItem } from "./OrderItem";

@Injectable()
export class DataService {

    constructor( private http: HttpClient ) { }

    public products: IProduct[] = [];

    public order: IOrder = new Order();

    getToken( creds: ICred ): Observable<IToken> {
        return this.http.post<IToken>( "/account/createtoken", creds ).pipe(
            catchError( this.handleError )
        );
    }

    loadProducts( token: IToken ): Observable<boolean> {

        let options = {
            // withCredentials: true,
            headers: new HttpHeaders( { "Authorization": "bearer " + token.token } ),
        };

        return this.http.get( "/api/products", options )
            .pipe(
                map( ( data: any[] ) => {
                    this.products = data;
                    return true;
                } )
            );
    }



    handleError( error: HttpErrorResponse ): Observable<never> {

        if ( error.error instanceof ErrorEvent ) {

            // a client-side or network error occurred. Handle it accordingly.

            console.error( "An error occurred:", error.error.message );

        } else {
            // the backend returned an unsuccessful response code.
            // the response body may contain clues as to what went wrong.
            console.error(
                `Backend returned code ${error.status}, ` +
                `body was: ${error.error}` );
        }
        // return an observable with a user-facing error message.
        return throwError(
            "Something bad happened; please try again later." );
    }


    public currentItemOrderQtyu( newProduct: IProduct ): number {

        var item: IOrderItem = this.order.items.find( i => i.productId == newProduct.id );
        if ( !item ) return -1;

        return item.quantity;
    }


    public addToOrder( newProduct: IProduct ): void {


        var item: IOrderItem = this.order.items.find( i => i.productId == newProduct.id );

        if ( item != null ) {

            item.quantity++;
            return;
        }


        item = new OrderItem();

        item.productId = newProduct.id;
        item.productArtist = newProduct.artist;
        item.productArtId = newProduct.artId;
        item.productCategory = newProduct.category;
        item.productSize = newProduct.size;
        item.productTitle = newProduct.title;
        item.unitPrice = newProduct.price;
        item.quantity = 1

        this.order.items.push( item );

    }


}
