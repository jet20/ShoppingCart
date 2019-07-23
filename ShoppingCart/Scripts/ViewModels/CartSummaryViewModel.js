function CartSummaryViewModel(model) {
    var self = this;

    self.cart = model;

    for (var i = 0; i < self.cart.cartItems.length; i++) {
        var cartItem = self.cart.cartItems[i];
        cartItem.quantity = ko.observable(cartItem.quantity)
            .extend({ subTotal: cartItem.book.salePrice });
    }
    self.cart.cartItems = ko.observableArray(self.cart.cartItems);
    self.cart.total = self.cart.cartItems.total();

    self.showCart = function(element) {
        $('#cart').popover('toggle');
    }

    self.fadeIn = function() {
        setTimeout(function() {
            $('#cart').popover('show');

            $(element).slideDown(function() {
                $('#cart').popover('hide');
            }, 2000);

        }, 100);
    }

    $('#cart').popover({
        html: true,
        content: function() {
            return $('#cart-summary').html();
        },
        title: '购物车详情',
        placement: 'bottom',
        animation: true,
        trigger: 'manual'
    });
}

if (cartSummaryData != undefined) {
    var cartSummaryViewModel = new CartSummaryViewModel(cartSummaryData);
    ko.applyBindings(cartSummaryViewModel, document.getElementById('cart-details'));
} else {
    alert('没找到购物车');
}