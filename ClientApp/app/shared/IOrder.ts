
// 09/01/2020 03:52 pm - SSN - [20200901-1547] - [001] - M12-07 - Sharing data across components

import { IOrderItem } from "./IOrderItem";


export interface IOrder {

    orderId: number;
    orderDate: Date;
    orderNumber: string;
    items: IOrderItem[];

}