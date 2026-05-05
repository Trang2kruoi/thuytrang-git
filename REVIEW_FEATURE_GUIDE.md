# 📋 HƯỚNG DẪN CHỨC NĂNG REVIEWS (ĐÁNH GIÁ)

## ✅ Các chức năng đã được xây dựng

### 1. **Đánh giá sao (Rating) từ 1-5 ⭐**
- User chọn từ 1 đến 5 sao
- Hiển thị trên bảng dưới dạng icon sao vàng/xám
- Lưu trong database với kiểm tra phạm vi (1-5)

### 2. **Viết đánh giá (Create) ✍️**
- **Modal tạo mới**: Nhấn "Thêm Đánh Giá"
- **Các trường cần điền**:
  - Tiêu đề (Title) - bắt buộc, tối đa 255 ký tự
  - Nội dung (Content) - textarea, bắt buộc, tối đa 1000 ký tự
  - Xếp hạng (Rating) - dropdown 1-5 sao
  - Kích hoạt (IsActive) - checkbox, mặc định ON
- **Xử lý**: Gửi AJAX đến `IReviewAppService.CreateOrEdit()`
- **Kết quả**: Tự động refresh bảng danh sách

### 3. **Chỉnh sửa đánh giá (Edit) ✏️**
- **Nhấn nút "Sửa"** trên mỗi dòng trong bảng
- **Modal edit hiển thị**:
  - Tiêu đề hiện tại (editable)
  - Nội dung hiện tại (editable)
  - Xếp hạng hiện tại (pre-selected)
  - Trạng thái Kích hoạt (pre-checked nếu active)
- **Xử lý**: Gửi AJAX cập nhật qua `IReviewAppService.CreateOrEdit()`
- **Kết quả**: Refresh bảng ngay lập tức

### 4. **Xóa đánh giá (Delete) 🗑️**
- **Nhấn nút "Xóa"** trên mỗi dòng
- **Xác nhận**: Hộp thoại confirm
- **Xử lý**: Gọi `IReviewAppService.Delete()`
- **Kết quả**: Xóa khỏi database và bảng

### 5. **Hiển thị danh sách đánh giá 📊**
- **DataTable** với các cột:
  - Tiêu đề
  - Nội dung
  - Xếp hạng (hiển thị ⭐ icon)
  - Trạng thái (Badge "Hoạt động" hoặc "Khóa")
  - Thao tác (Nút Sửa/Xóa)
- **Sắp xếp**: Theo ngày tạo mới nhất trước
- **Phân trang**: Server-side (AJAX)

---

## 📁 Cấu trúc thư mục

```
src/
├── thuytrang.Core/
│   └── Reviews/
│       └── Review.cs (Entity Model)
│
├── thuytrang.Application/
│   ├── Reviews/
│   │   ├── IReviewAppService.cs (Interface)
│   │   ├── ReviewAppService.cs (Logic)
│   │   └── Dto/
│   │       ├── ReviewDto.cs (Response DTO)
│   │       ├── CreateReviewDto.cs (Input DTO)
│   │       ├── ReviewMapProfile.cs (AutoMapper)
│   │       └── PagedReviewResultRequestDto.cs (Paging)
│
└── thuytrang.Web.Mvc/
	├── Controllers/
	│   └── ReviewController.cs
	├── Views/
	│   └── Review/
	│       ├── Index.cshtml (Main view)
	│       ├── _CreateModal.cshtml (Create form modal)
	│       └── _EditModal.cshtml (Edit form modal)
	└── wwwroot/
		└── view-resources/Views/Review/
			└── Index.js (Frontend logic)
```

---

## 🔧 Thông tin kỹ thuật

### **Database Entity (Review.cs)**
```csharp
public class Review : FullAuditedEntity<Guid>
{
	public string Title { get; set; }      // Tiêu đề
	public string Content { get; set; }    // Nội dung
	public int Rating { get; set; }        // Sao (1-5)
	public bool IsActive { get; set; }     // Trạng thái
	// Tự động có: Id, CreationTime, CreatorUserId, etc.
}
```

### **API Endpoints (via AppService)**
- `CreateOrEdit(CreateReviewDto)` - Tạo hoặc cập nhật
- `GetAsync(EntityDto<Guid>)` - Lấy chi tiết 1 review
- `GetAll(PagedReviewResultRequestDto)` - Lấy danh sách
- `Delete(EntityDto<Guid>)` - Xóa

### **Frontend Events (Index.js)**
1. **DataTable initialization** - Load danh sách từ server
2. **Create button** - Mở modal tạo mới
3. **Save in Create modal** - POST dữ liệu tạo mới
4. **Edit button** - Load modal chỉnh sửa
5. **Save in Edit modal** - POST dữ liệu cập nhật
6. **Delete button** - Xóa với confirm

---

## 🚀 Cách sử dụng

### **Từ giao diện web:**

#### 1️⃣ **Tạo đánh giá mới**
```
1. Vào trang Review
2. Nhấn nút "Thêm Đánh Giá"
3. Điền:
   - Tiêu đề: "Sản phẩm tuyệt vời"
   - Nội dung: "Chất lượng rất tốt, giao hàng nhanh"
   - Xếp hạng: Chọn "5 Sao - Rất tốt"
   - Kích hoạt: Bỏ dấu (nếu muốn ẩn)
4. Nhấn "Lưu lại"
5. Bảng tự động refresh
```

#### 2️⃣ **Sửa đánh giá**
```
1. Tìm dòng cần sửa
2. Nhấn nút "Sửa" (biểu tượng bút chì)
3. Modal edit hiện lên với dữ liệu cũ
4. Chỉnh sửa các trường
5. Nhấn "Cập nhật"
6. Bảng refresh ngay
```

#### 3️⃣ **Xóa đánh giá**
```
1. Tìm dòng cần xóa
2. Nhấn nút "Xóa" (biểu tượng thùng rác)
3. Xác nhận trong hộp thoại
4. Bản ghi bị xóa khỏi bảng
```

#### 4️⃣ **Xem danh sách**
```
- Bảng hiển thị tất cả đánh giá
- Sắp xếp theo ngày tạo (mới nhất trước)
- Hiển thị sao dưới dạng icon ⭐
- Trạng thái "Hoạt động" hay "Khóa"
- Có phân trang (tùy config)
```

---

## 🔒 Bảo mật & Validations

### **Backend Validations (DTO)**
- `Title`: Required, Max 255 chars
- `Content`: Required, Max 1000 chars
- `Rating`: Required, Range 1-5
- `IsActive`: Có thể null (default = true)

### **Frontend Validations (JS)**
- Kiểm tra form.valid() trước khi submit
- Hiển thị error nếu validation thất bại

### **Authorization**
- Tất cả methods đều có `[AbpAuthorize]`
- Chỉ user đăng nhập mới có thể truy cập

---

## 🐛 Troubleshooting

### **Vấn đề: Nút "Thêm Đánh Giá" không mở modal**
**Giải pháp**: 
- Kiểm tra file `Index.js` có được load không (F12 → Sources)
- Kiểm tra console có error không (F12 → Console)

### **Vấn đề: Nút "Sửa" mở modal nhưng không hiển thị dữ liệu**
**Giải pháp**:
- Kiểm tra `ReviewController.EditModal()` có trả về partial view không
- Xem Network tab (F12) xem API call có thành công không

### **Vấn đề: Nút "Lưu" không hoạt động**
**Giải pháp**:
- Kiểm tra form validation (có required fields trống không)
- Xem console có lỗi JavaScript không
- Xem Network tab (F12) xem API response (status 200 hay error?)

### **Vấn đề: Dữ liệu không lưu vào database**
**Giải pháp**:
- Kiểm tra migration đã chạy không (`Update-Database`)
- Kiểm tra Review table có trong SQL không
- Xem AppService có `await _reviewRepository.UpdateAsync(review)` không (khi edit)

---

## 📝 Các file đã chỉnh sửa

✅ `CreateReviewDto.cs` - Thêm Title, Content, IsActive
✅ `ReviewAppService.cs` - Thêm UpdateAsync() cho edit
✅ `ReviewMapProfile.cs` - Tạo mới (AutoMapper config)
✅ `_CreateModal.cshtml` - Sửa Content từ input → textarea
✅ `_EditModal.cshtml` - Thêm Title field + proper binding
✅ `Index.js` - Thêm handler save cho edit modal
✅ `ReviewController.cs` - EditModal action (đã có)

---

## ✨ Tính năng mở rộng có thể thêm

1. **Filter/Search**: Tìm kiếm theo tiêu đề hoặc rating
2. **Sort by Rating**: Sắp xếp theo số sao (descending)
3. **Average Rating**: Hiển thị trung bình cộng sao
4. **User Profile**: Lưu user ID của người review
5. **Comment Replies**: Cho phép trả lời review
6. **Image Upload**: Upload ảnh trong review
7. **Helpful Votes**: Nút "Hữu ích" / "Không hữu ích"
8. **Admin Moderation**: Duyệt review trước khi công khai

---

**Build Status**: ✅ Build Successful
**Last Updated**: 2024
