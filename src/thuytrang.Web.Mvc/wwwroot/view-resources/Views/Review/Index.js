(function ($) {
    var _reviewService = abp.services.app.review;
    var _$modal = $('#ReviewCreateModal');
    var _$form = _$modal.find('form');

    _$form.validate();

    // JS sẽ tìm nút có class 'save-button' để kích hoạt
    _$modal.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var review = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _reviewService.create(review).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info('Lưu đánh giá thành công!');

            // Reload trang để thấy dữ liệu mới (hoặc dùng ajax reload nếu đã setup DataTable)
            setTimeout(function () { location.reload(); }, 1000);

        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });
})(jQuery);