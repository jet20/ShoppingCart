function CartItemViewModel(params) {
    var self = this;
    self.sending = ko.observable(false);

    self.cartItem = params.cartItem;
    self.showButton = params.showButton;

    self.isAdding = function () {
        return self.cartItem.id != undefined;
    }

    self.upsertCartItem = function (form) {
        if (!$(form).valid()) {
            return false;
        }

        self.sending(true);

        var data = {
            id: self.cartItem.id,
            cartId: self.cartItem.cartId,
            bookId: self.cartItem.book.id,
            quantity: self.cartItem.quantity()
        };

        $.ajax({
            url: '/api/cartItems',
            type: self.isAdding() ? 'put' : 'post',
            contentType: 'application/json',
            data: ko.toJSON(data)
        })
        .done(self.saveSuccess)
        .fail(self.errorSave)
        .always(function () { self.sending(false); });
    };

    self.successfulSave = function (data) {
        var msg = '<div class="alert alert-success"><strong>成功!</strong>本书已成功添加到购物车</div>';
        $('.body-content').prepend(msg);

        self.itemCart.id = data.id;

        cartSummaryViewModel.updateCartItem(ko.toJS(self.cartItem));
    }

    self.errorSave = function () {
        var msg = '<div class="alert alert-danger"><strong>错误!</strong>添加到购物车失败</div>';
        $('.body-content').prepend(msg);
    }

}

ko.components.register('upsert-cart-item', {
    viewModel: CartItemViewModel,
    template: { element: 'cart-item-form' }
});