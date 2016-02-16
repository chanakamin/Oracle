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

