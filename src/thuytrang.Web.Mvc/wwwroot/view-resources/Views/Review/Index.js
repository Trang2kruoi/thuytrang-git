(function ($) {
    var _reviewService = abp.services.app.review;
    var _$modal = $('#ReviewCreateModal');
    var _$form = _$modal.find('form');
    var _$table = $('#ReviewsTable');

    // 1. KHỞI TẠO BẢNG DATATABLE (HIỂN THỊ DỮ LIỆU)
    var _$reviewsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        // THÊM DÒNG NÀY ĐỂ FIX LỖI "Unknown button type: print"
        buttons: [],
        ajax: function (data, callback, settings) {
            var filter = {
                maxResultCount: data.length,
                skipCount: data.start
            };

            abp.ui.setBusy(_$table);
            _reviewService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        columns: [
            { data: 'title', defaultContent: '' },
            { data: 'content', defaultContent: '' },
            {
                data: 'rating',
                defaultContent: '0',
                render: function (data) {
                    var rating = data || 0;
                    var stars = '';
                    // Vẽ sao vàng
                    for (var i = 0; i < rating; i++) {
                        stars += '<i class="fas fa-star text-warning"></i>';
                    }
                    // Vẽ sao xám (cho đủ 5 sao)
                    for (var j = rating; j < 5; j++) {
                        stars += '<i class="far fa-star text-warning"></i>';
                    }
                    return stars;
                }
            },
            {
                data: 'isActive',
                render: function (data) {
                    return data
                        ? '<span class="badge badge-success">Hoạt động</span>'
                        : '<span class="badge badge-secondary">Khóa</span>';
                }
            },
            {
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: function (data, type, row) {
                    return `<button class="btn btn-sm btn-secondary edit-review" data-id="${row.id}"><i class="fas fa-pencil-alt"></i> Sửa</button> 
                            <button class="btn btn-sm btn-danger delete-review" data-id="${row.id}"><i class="fas fa-trash"></i> Xóa</button>`;
                }
            }
        ]
    });

    _$form.validate();

    // 2. XỬ LÝ NÚT LƯU LẠI (TẠO MỚI)
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

            // Tải lại bảng ngay lập tức
            _$reviewsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    // 3. XỬ LÝ NÚT XÓA
    _$table.on('click', '.delete-review', function () {
        var reviewId = $(this).attr("data-id");

        abp.message.confirm(
            "Bạn có chắc chắn muốn xóa đánh giá này không?",
            "Xác nhận xóa",
            function (isConfirmed) {
                if (isConfirmed) {
                    _reviewService.delete({ id: reviewId }).done(function () {
                        abp.notify.success('Đã xóa thành công!');
                        _$reviewsTable.ajax.reload();
                    });
                }
            }
        );
    });

    // 4. XỬ LÝ NÚT SỬA (MỞ MODAL EDIT)
    _$table.on('click', '.edit-review', function (e) {
        var reviewId = $(this).attr("data-id");
        e.preventDefault();

        abp.ajax({
            url: abp.appPath + 'Review/EditModal?reviewId=' + reviewId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ReviewEditModalContainer').html(content);
                $('#ReviewEditModal').modal('show');
            }
        });
    });
})(jQuery);