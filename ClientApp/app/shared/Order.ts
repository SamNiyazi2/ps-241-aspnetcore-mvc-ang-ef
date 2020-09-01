
// 09/01/2020 03:56 pm - SSN - [20200901-1547] - [003] - M12-07 - Sharing data across components


import { IOrderItem } from "./IOrderItem";
import { IOrder } from "./IOrder";
import { OrderItem } from "./OrderItem";



export class Order implements IOrder {
    orderId: number;
    orderDate: Date = new Date();
    orderNumber: string;
    items: Array<OrderItem> = new Array<OrderItem>();

    // 09/01/2020 05:29 pm - SSN - [20200901-1726] - [001] - M12-09 - Using calculated data

    get subtotal(): number {
        let _subtotal = 0
        return this.items.reduce( ( prev, curr ) => _subtotal += ( curr.quantity * curr.unitPrice ), _subtotal );
    }
}