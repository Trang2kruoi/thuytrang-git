using Abp.Application.Services.Dto;

namespace thuytrang.Reviews.Dto
{
    // Class này dùng để nhận các tham số từ giao diện khi load bảng (Trang số mấy, tìm kiếm chữ gì...)
    public class PagedReviewResultRequestDto : PagedResultRequestDto
    {
        // Thêm trường này để sau này bạn có thể tìm kiếm đánh giá theo từ khóa
        public string Keyword { get; set; }

        // Có thể thêm lọc theo trạng thái nếu cần
        public bool? IsActive { get; set; }
    }
}
