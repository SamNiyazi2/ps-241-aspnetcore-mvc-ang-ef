
// 09/01/2020 03:56 pm - SSN - [20200901-1547] - [003] - M12-07 - Sharing data across components


import { IOrderItem } from "./IOrderItem";
import { IOrder } from "./IOrder";
import { OrderItem } from "./OrderItem";



export class Order implements IOrder {
    orderId: number;
    orderDate: Date = new Date();
    orderNumber: string;
    items: Array<OrderItem> = new Array<OrderItem>();

}