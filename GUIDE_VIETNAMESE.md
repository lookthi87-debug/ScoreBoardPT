# Hướng dẫn vận hành ScoreBoardPT (VI)

Tài liệu này hướng dẫn cách **cài đặt, cấu hình, chạy và triển khai** project **ScoreBoardPT** trên Windows.

---

## 1) Tổng quan

- **Loại ứng dụng**: Windows Desktop (WinForms), .NET Framework.
- **Database**: PostgreSQL (kết nối qua `Npgsql`).
- **Lưu cấu hình DB**: Windows Registry tại `HKEY_CURRENT_USER\Software\Scoreboard\DatabaseConfig`.
- **Solution chính**:
  - `Scoreboard/Scoreboard.sln` (ứng dụng Scoreboard)
  - `Scoreboard_Toggle/ScoreboardToggle.sln` (module Toggle – nếu dùng)

---

## 2) Yêu cầu hệ thống

- **Windows**: Windows 10+.
- **.NET Framework**: 4.8.
- **Visual Studio**: 2019 hoặc 2022 (khuyến nghị).
- **PostgreSQL**: khuyến nghị 13+ (hoặc phiên bản tương thích nội bộ).

---

## 3) Chuẩn bị PostgreSQL

### 3.1 Cài PostgreSQL

- Tải và cài từ trang chính thức: `https://www.postgresql.org/download/`
- Ghi nhớ các thông tin:
  - **Host**: `127.0.0.1` (hoặc IP/hostname server DB)
  - **Port**: `5432` (mặc định)
  - **User/Password**: tài khoản PostgreSQL

### 3.2 Tạo database

Tạo DB theo tên bạn dùng cho hệ thống (mặc định code fallback là `DB_Scoreboard`).

Ví dụ:

```sql
CREATE DATABASE "DB_Scoreboard"
    WITH ENCODING 'UTF8'
    TEMPLATE template0;
```

### 3.3 Import cấu trúc/dữ liệu (nếu có)

Nếu repo có script SQL, ví dụ `DB/Import_Export.sql`, hãy chạy script đó trên database vừa tạo để có bảng/dữ liệu cần thiết.

---

## 4) Cấu hình kết nối DB (Registry)

Ứng dụng dùng `PostgresHelper` để đọc/ghi cấu hình DB vào Registry:

- **Registry path**: `  \Software\Scoreboard\DatabaseConfig`
- **Keys**:
  - `Host`
  - `Port`
  - `User`
  - `Password`
  - `Database`

### 4.1 Cấu hình qua giao diện ứng dụng (khuyến nghị)

Trong ứng dụng có form cấu hình DB (tham chiếu từ code: `Scoreboard/Scoreboard/Forms/ConfigDatabase.cs`).

- Mở ứng dụng
- Vào màn hình cấu hình Database
- Nhập `Host/Port/Database/User/Password`
- Lưu lại để ứng dụng ghi vào Registry và dùng cho các lần chạy sau

### 4.2 Giá trị mặc định khi chưa có cấu hình

Nếu Registry chưa tồn tại, code sẽ dùng mặc định:

- Host: `127.0.0.1`
- Port: `5432`
- User: `postgres`
- Password: `Abc12345`
- Database: `DB_Scoreboard`

Bạn nên **cấu hình lại** theo môi trường thực tế (đặc biệt là password).

---

## 5) Chạy ứng dụng (Dev/Local)

### 5.1 Mở solution

1. Mở Visual Studio
2. Open solution: `Scoreboard/Scoreboard.sln`

### 5.2 Restore NuGet packages

Trong project có ghi chú “restore NuGet packages”. Bạn có thể làm theo 1 trong các cách:

- Chuột phải Solution → **Restore NuGet Packages**
- Hoặc mở NuGet Package Manager Console và chạy:

```powershell
Update-Package -reinstall
```

### 5.3 Build & chạy

- **Build**: `Build > Build Solution`
- **Run**:
  - `F5` (Debug) hoặc
  - `Ctrl+F5` (Run without debugging)

Ứng dụng sẽ khởi chạy form chính `MainMDIForm` (xem `Scoreboard/Scoreboard/Program.cs`).

---

## 6) Đăng nhập & tài khoản mặc định

Theo `README.txt` trong module Scoreboard:

- **Admin mặc định**:
  - Username: `admin`
  - Password: `admin123`

Khuyến nghị: đổi mật khẩu admin ngay khi triển khai thật.

---

## 7) Quy trình vận hành cơ bản (Ops)

- **Bước 1 – Kiểm tra dịch vụ DB**
  - Đảm bảo PostgreSQL đang chạy
  - Đảm bảo firewall/network cho phép ứng dụng truy cập DB (nếu DB nằm trên server)

- **Bước 2 – Mở ứng dụng & kiểm tra kết nối**
  - Nếu lỗi kết nối, vào cấu hình DB để cập nhật

- **Bước 3 – Đăng nhập**
  - Dùng admin hoặc user được cấp

- **Bước 4 – Cấu hình nghiệp vụ (tùy nhu cầu)**
  - Giải đấu / đội / trận / set / người dùng / phân quyền…
  - Các form trong code gợi ý: `TeamsForm`, `MatchsForm`, `AddUpdateMatch`, `AddUpdateTournaments`, `AddUpdateMatchsets`…

- **Bước 5 – Trong khi vận hành**
  - Cập nhật điểm số / thời gian / trạng thái trận theo UI
  - Dữ liệu lưu vào DB để các màn hình hiển thị đồng bộ

- **Bước 6 – Thoát ứng dụng**
  - Khi đóng app, hệ thống sẽ dọn trạng thái hoạt động user (tham chiếu `ApplicationExit` trong `Program.cs`).

---

## 8) Module Toggle (nếu sử dụng)

Repo có solution:

- `Scoreboard_Toggle/ScoreboardToggle.sln`

Cách chạy tương tự:

1. Mở solution Toggle trong Visual Studio
2. Restore NuGet
3. Build & Run
4. Cấu hình DB giống Scoreboard (cũng dùng `PostgresHelper`/Registry)

---

## 9) Đóng gói & triển khai sang máy khác

### 9.1 Chuẩn bị máy đích

- Cài **.NET Framework 4.8**
- Cài PostgreSQL **hoặc** đảm bảo máy đích truy cập được DB server

### 9.2 Build bản Release

- Chọn cấu hình `Release`
- Build solution
- Lấy output trong `bin/Release` của project tương ứng (Scoreboard/Toggle)

### 9.3 Chạy lần đầu trên máy đích

- Chạy file `.exe`
- Vào cấu hình DB và lưu (để ghi Registry theo user Windows đang chạy)
- Đăng nhập và vận hành

---

## 10) Sự cố thường gặp

- **Không kết nối được DB**
  - Kiểm tra PostgreSQL service
  - Kiểm tra Host/Port/User/Password/Database
  - Nếu DB remote: kiểm tra `pg_hba.conf`, firewall, network route

- **Máy khác chạy nhưng không nhận cấu hình DB**
  - Cấu hình DB được lưu theo **HKEY_CURRENT_USER** → mỗi user Windows có cấu hình riêng
  - Hãy cấu hình lại trên user Windows đang chạy ứng dụng