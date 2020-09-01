import { IOrderItem } from "./IOrderItem";

// 09/01/2020 03:58 pm - SSN - [20200901-1547] - [004] - M12-07 - Sharing data across components

export class OrderItem implements IOrderItem {

    id: number;
    quantity: number;
    unitPrice: number;
    productId: number;
    productCategory: string;
    productSize: string;
    productTitle: string;
    productArtist: string;
    productArtId: string;

}
