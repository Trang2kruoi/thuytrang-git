(function ($) {
    var _reviewService = abp.services.app.review;
    var _$table = $('#ReviewsTable');
    var _$modal = $('#ReviewCreateModal');
    var _$form = _$modal.find('form');

    var _$reviewsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        processing: true,
        listAction: {
            ajaxFunction: _reviewService.getAll,
            inputFilter: function () {
                return {};
            }
        },
        columnDefs: [
            { targets: 0, data: 'content' },
            {
                targets: 1,
                data: 'rating',
                render: function (data) {
                    var stars = '';
                    for (var i = 0; i < 5; i++) {
                        stars += i < data
                            ? '<i class="fas fa-star text-warning"></i>'
                            : '<i class="far fa-star text-warning"></i>';
                    }
                    return stars;
                }
            },
            {
                targets: 2,
                data: 'isActive',
                render: data => data ? 'Hoạt động' : 'Khóa'
            },
            {
                targets: 3,
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    return `
                        <button class="btn btn-sm btn-secondary edit-review" data-id="${row.id}">
                            <i class="fas fa-pencil-alt"></i> Sửa
                        </button>
                        <button class="btn btn-sm btn-danger delete-review" data-id="${row.id}">
                            <i class="fas fa-trash"></i> Xóa
                        </button>
                    `;
                }
            }
        ]
    });

    // ========================
    // CREATE (ĐÃ THAY ĐOẠN RESET AN TOÀN)
    // ========================
    _$modal.find('.save-button').on('click', function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var review = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _reviewService.create(review).done(function () {
            _$modal.modal('hide');

            // --- ĐOẠN ĐÃ SỬA ---
            _$form.trigger('reset');
            // ------------------

            abp.notify.success('Thêm thành công!');
            _$reviewsTable.ajax.reload();

        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    // ========================
    // EDIT
    // ========================
    $(document).on('click', '.edit-review', function () {
        var reviewId = $(this).data('id');

        abp.ajax({
            url: abp.appPath + 'Review/EditModal?reviewId=' + reviewId,
            type: 'POST',
            dataType: 'html',
            beforeSend: function () {
                abp.ui.setBusy();
            },
            success: function (content) {
                $('#ReviewEditModalContainer').html(content);
                var _$editModal = $('#ReviewEditModal');
                var _$editForm = _$editModal.find('form');

                _$editModal.modal('show');

                _$editModal.find('.save-button').on('click', function (e) {
                    e.preventDefault();

                    if (!_$editForm.valid()) return;

                    var review = _$editForm.serializeFormToObject();

                    abp.ui.setBusy(_$editModal);

                    _reviewService.update(review).done(function () {
                        _$editModal.modal('hide');
                        abp.notify.success('Cập nhật thành công!');
                        _$reviewsTable.ajax.reload();
                    }).always(function () {
                        abp.ui.clearBusy(_$editModal);
                    });
                });
            },
            complete: function () {
                abp.ui.clearBusy();
            }
        });
    });

    // ========================
    // DELETE
    // ========================
    $(document).on('click', '.delete-review', function () {
        var reviewId = $(this).data('id');

        abp.message.confirm(
            'Bạn có chắc muốn xóa?',
            'Xác nhận',
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ui.setBusy();
                    _reviewService.delete({ id: reviewId }).done(function () {
                        abp.notify.success('Đã xóa!');
                        _$reviewsTable.ajax.reload();
                    }).always(function () {
                        abp.ui.clearBusy();
                    });
                }
            }
        );
    });

})(jQuery);
