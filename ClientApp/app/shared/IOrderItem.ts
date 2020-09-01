
// 09/01/2020 03:53 pm - SSN - [20200901-1547] - [002] - M12-07 - Sharing data across components

export interface IOrderItem {
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