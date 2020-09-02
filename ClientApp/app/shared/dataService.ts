import { IOrderItem } from "./IOrderItem";

// 08/31/2020 09:58 pm - SSN - [20200831-2156] - [001] - M12-02 - Creating a service (Angular)
// 08/31/2020 11:19 pm - SSN - [20200831-2314] - [001] - M12-03 - Calling the API
// 09/01/2020 02:34 am - SSN - [20200901-0108] - [003] - M12-04 - Using type safety
// 09/01/2020 04:01 pm - SSN - [20200901-1547] - [005] - M12-07 - Sharing data across components

// 09/01/2020 07:42 pm - SSN - [20200901-1940] - [001] - M13-03 - Support login

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

    private token: string = "";
    private tokenExpiration: Date;

    public products: IProduct[] = [];

    public order: IOrder = new Order();
    public order_Confirmed: IOrder;


    public get loginRequired(): boolean {

        return this.token.length === 0 || this.tokenExpiration > new Date();
    }

    // 09/01/2020 10:24 pm - SSN - [20200901-2220] - [001] - M13-06 - Use token authentication
    login( creds: ICred ): Observable<boolean> {

        return this.http.post<IToken>( "/account/createtoken", creds )
            .pipe( map( ( data: IToken ) => {

                this.token = data.token
                this.tokenExpiration = new Date( data.expiration );
                return true;
            } ) );

    }


    // 09/01/2020 11:58 pm - SSN - [20200901-2354] - [001] - M13-07 - implement server-side checkout

    pad( x1: number, spaces: number ): string {
        return x1.toString().padStart( spaces, '0' );
    }

    public checkout(): Observable<object> {

        let options = this.getRequestHeaderOptions();
        if ( !this.order.orderNumber ) {
            let d = new Date();
            this.order.orderNumber = this.pad( d.getFullYear(), 4 )
                + this.pad( d.getMonth() + 1, 2 ) + this.pad( d.getDate(), 2 ) + "-"
                + this.pad( d.getHours(), 2 ) + this.pad( d.getMinutes(), 2 ) + '-' +
                this.pad( d.getMilliseconds(), 4 );

        }

        return this.http.post( "/api/orders", this.order, options ).pipe( map( response => {
            this.order = new Order();
            return response;
        } ) );
    }


    getToken( creds: ICred ): Observable<IToken> {
        return this.http.post<IToken>( "/account/createtoken", creds ).pipe(
            catchError( this.handleError )
        );
    }

    getRequestHeaderOptions( token: IToken = null ) {

        let _token = "";
        if ( token ) {
            _token = token.token;
        } else {
            _token = this.token;
        }

        return {
            // withCredentials: true,
            headers: new HttpHeaders( { "Authorization": "bearer " + _token } ),
        };
    }


    loadProducts( token: IToken ): Observable<boolean> {

        let options = this.getRequestHeaderOptions( token );

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


    public addToOrder( newProduct: IProduct, qty: number = 1 ): void {

        var item: IOrderItem = this.order.items.find( i => i.productId == newProduct.id );

        if ( item != null ) {

            item.quantity = item.quantity + qty;
            if ( item.quantity <= 0 ) {
                this.order.items = this.order.items.filter( i => i.productId != newProduct.id );
            }
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
