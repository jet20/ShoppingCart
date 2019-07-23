ko.extenders.subTotal = function(target, multiplier) {
    target.subTotal = ko.observable();
    target.subscribe(function(newValue) {
        target.subTotal((newValue * multiplier).toFixed(2));
    });
    return target;
}

ko.observableArray.fn.total = function() {
    return ko.pureComputed(function() {
        var sum = 0;

        for (var i = 0; i < this().length; i++) {
            sum += parseFloat(this()[i].quantity.subTotal());
        }

        return sum.toFixed(2);
    }, this);
}