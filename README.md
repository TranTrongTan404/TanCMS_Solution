# 🖨️ Tan3D Printing Lab

Website thương mại điện tử chuyên về **Máy in 3D**, **Vật liệu in 3D** và **Phụ kiện** được xây dựng bằng **ASP.NET Core MVC**, **ASP.NET Core Web API**, **ReactJS** và **SQL Server**.

Dự án được phát triển theo mô hình **Hybrid Architecture**, kết hợp giữa hệ thống quản trị (Admin) bằng ASP.NET Core MVC và giao diện khách hàng (Frontend) bằng ReactJS.

---

# 📖 Giới thiệu

Tan3D Printing Lab được xây dựng với mục tiêu mô phỏng một website bán hàng thực tế trong lĩnh vực in 3D, bao gồm:

- Quản lý sản phẩm
- Quản lý danh mục sản phẩm
- Quản lý bài viết
- Quản lý danh mục bài viết
- Cung cấp Web API cho Frontend ReactJS
- Giao diện người dùng hiện đại

Dự án được thực hiện trong môn học **ASP.NET Core MVC + ReactJS**.

---

# ✨ Chức năng hiện tại

## 🔐 Hệ thống quản trị (Admin)

- Đăng nhập quản trị
- Quản lý danh mục sản phẩm (CRUD)
- Quản lý sản phẩm (CRUD)
- Upload hình ảnh sản phẩm
- Quản lý danh mục bài viết (CRUD)
- Quản lý bài viết (CRUD)
- Upload hình ảnh bài viết
- Dashboard quản trị
- Swagger API

---

## 🌐 Web API

### Danh mục sản phẩm

- Lấy toàn bộ danh mục

### Sản phẩm

- Lấy toàn bộ sản phẩm
- Lấy sản phẩm theo danh mục
- Lấy chi tiết sản phẩm

### Bài viết

- Lấy danh sách bài viết
- Lấy bài viết mới nhất
- Lấy chi tiết bài viết

---

## 💻 Giao diện người dùng (ReactJS)

- Trang chủ
- Header hiện đại
- Hero Slider
- Danh mục sản phẩm
- Danh sách sản phẩm nổi bật
- Danh sách bài viết mới
- Footer
- Trang "Đang phát triển"
- Kết nối dữ liệu bằng Axios

---

# 🛠 Công nghệ sử dụng

| Công nghệ | Phiên bản |
|-----------|-----------|
| ASP.NET Core MVC | .NET 8 |
| ASP.NET Core Web API | .NET 8 |
| Entity Framework Core | 8 |
| SQL Server | 2022 |
| ReactJS | 18 |
| Axios | Latest |
| Bootstrap | 5 |
| Font Awesome | 6 |

---

# 📂 Cấu trúc Solution

```
TanCMS_Solution
│
├── CMS.Backend
│   ├── Controllers
│   ├── Views
│   ├── wwwroot
│   ├── Program.cs
│   └── appsettings.json
│
├── CMS.Data
│   ├── Entities
│   ├── Migrations
│   └── ApplicationDbContext.cs
│
└── cms.frontend
    ├── api
    ├── components
    ├── pages
    ├── services
    ├── public
    └── src
```

---

# 🚀 Hướng dẫn cài đặt

## 1. Clone dự án

```bash
git clone https://github.com/your-username/TanCMS.git
```

---

## 2. Chạy Backend

Khôi phục thư viện

```bash
dotnet restore
```

Cập nhật Database

```bash
dotnet ef database update
```

Chạy Backend

```bash
dotnet run
```

---

## 3. Chạy Frontend

Di chuyển vào thư mục

```bash
cd cms.frontend
```

Cài đặt thư viện

```bash
npm install
```

Chạy ReactJS

```bash
npm start
```

---

# 📚 Swagger API

Sau khi chạy Backend có thể truy cập:

```
https://localhost:7009/swagger
```

> Lưu ý: Port có thể thay đổi tùy theo cấu hình `launchSettings.json`.

---

# 🗄️ Cơ sở dữ liệu

Các bảng chính:

- CategoryProduct
- Product
- Category
- Post

Các bảng sẽ phát triển trong tương lai:

- User
- Cart
- CartItem
- Order
- OrderDetail
- Payment
- Wishlist

---

# 🏗️ Kiến trúc hệ thống

```
ReactJS
    │
Axios
    │
ASP.NET Core Web API
    │
Entity Framework Core
    │
SQL Server
```

Khu vực quản trị

```
ASP.NET Core MVC
        │
Entity Framework Core
        │
SQL Server
```

---

# 📋 Các trang hiện có

### Frontend

- Trang chủ
- Trang đang phát triển

### Backend

- Đăng nhập
- Dashboard
- Quản lý danh mục sản phẩm
- Quản lý sản phẩm
- Quản lý danh mục bài viết
- Quản lý bài viết

---

# 🎯 Định hướng phát triển

## Giai đoạn 1 ✅

- Quản lý sản phẩm
- Quản lý bài viết
- Upload hình ảnh
- Web API
- ReactJS Homepage
- Hero Slider
- Danh mục sản phẩm
- Danh sách sản phẩm
- Danh sách bài viết

---

## Giai đoạn 2 🚧

### Tài khoản

- Đăng ký
- Đăng nhập
- Đăng xuất
- Quên mật khẩu
- Hồ sơ người dùng
- Phân quyền

---

## Giai đoạn 3 🚧

### Giỏ hàng

- Thêm vào giỏ hàng
- Cập nhật số lượng
- Xóa khỏi giỏ hàng
- Lưu giỏ hàng
- Tính tổng tiền

---

## Giai đoạn 4 🚧

### Thanh toán

- Đặt hàng
- Quản lý đơn hàng
- Lịch sử mua hàng
- Thanh toán trực tuyến
- Theo dõi trạng thái đơn hàng

---

## Giai đoạn 5 🚧

### Mở rộng

- Tìm kiếm sản phẩm
- Lọc sản phẩm
- Chi tiết sản phẩm
- Đánh giá sản phẩm
- Yêu thích sản phẩm
- Phân trang
- Dashboard thống kê
- Báo cáo doanh thu
- Gửi Email
- Responsive hoàn chỉnh

---

# 👨‍💻 Tác giả

**Trần Trọng Tân**

**MSSV:** 2123110006

Đồ án môn học **ASP.NET Core MVC + ReactJS**

---

# 📄 Giấy phép

Dự án được phát triển phục vụ mục đích học tập và nghiên cứu.

Mọi ý kiến đóng góp hoặc đề xuất cải tiến đều được chào đón.
