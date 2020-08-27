
// 08/27/2020 01:22 pm - SSN - [20200827-1321] - [001] - M10-02 - First TypeScript class



class StoreCustomer {


    //constructor(theName: string) {
    //    this.name = theName;
    //}

    constructor(private firstName: string, private lastName: string) {

    }


    // private / protected / public
    public visit: number = 0;
    private ourName: string;

    public showName() {

        console.log('StoreCustomre - showName');
        console.log(this.firstName + ' ' + this.lastName);

        return true;
    }

    public showName_withParam(name: string) {

        console.log('StoreCustomre - showName');
        console.log(name);

        return true;
    }

    set name(name: string) {
        this.ourName = name;
    }

    get name() {
        return this.ourName;
    }


}


let cust = new StoreCustomer();

