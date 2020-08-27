// 08/27/2020 01:22 pm - SSN - [20200827-1321] - [001] - M10-02 - First TypeScript class
var StoreCustomer = /** @class */ (function () {
    //constructor(theName: string) {
    //    this.name = theName;
    //}
    function StoreCustomer(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        // private / protected / public
        this.visit = 0;
    }
    StoreCustomer.prototype.showName = function () {
        console.log('StoreCustomre - showName');
        console.log(this.firstName + ' ' + this.lastName);
        return true;
    };
    StoreCustomer.prototype.showName_withParam = function (name) {
        console.log('StoreCustomre - showName');
        console.log(name);
        return true;
    };
    Object.defineProperty(StoreCustomer.prototype, "name", {
        get: function () {
            return this.ourName;
        },
        set: function (name) {
            this.ourName = name;
        },
        enumerable: false,
        configurable: true
    });
    return StoreCustomer;
}());
//# sourceMappingURL=storecustomer.js.map