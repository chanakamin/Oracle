Function.prototype.method = function (name, func) {
    this.prototype[name] = func;
    return this;
}

Array.method('getCopy',function () {
    var arr = [];
    this.forEach(function (o) {
        arr.push(o);
    });
    return arr;
});

Function.method('Call', function (method,obj,values) {
    return this.prototype[method].apply(obj, values);
});

//Object.method('getCopy', function () {
//    var a = {};
//    if (typeof this === 'object') {
//        for (var k in this) {
//            if (typeof this[k] === 'object')
//                a[k] = this[k].getCopy();
//            else if(typeof a[k] !== 'function')
//                a[k] = this[k];
//        }
//    }
//    a.constructor(this);
//    return a;
//});

