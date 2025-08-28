
# Todolist Project (C# ASP.NET Core + Angular)

## 📌 Giới thiệu
Dự án Todolist gồm 2 phần chính:
- **Backend (TodoApi)**: API viết bằng ASP.NET Core Web API.
- **Frontend (todo-app)**: Ứng dụng Angular để giao tiếp với API.

---

## ⚙️ Yêu cầu hệ thống
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js (khuyến nghị LTS)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- Visual Studio hoặc VS Code

---

## 🚀 Hướng dẫn chạy Backend (TodoApi)
1. Mở terminal trong thư mục **TodoApi**.
2. Chạy lệnh để khôi phục và build:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Chạy ứng dụng:
   ```bash
   dotnet run
   ```
4. API mặc định chạy tại:
   - `https://localhost:5003`
  

---

## 🌐 Hướng dẫn chạy Frontend (todo-app)
1. Mở terminal trong thư mục **todo-app**.
2. Cài đặt dependencies:
   ```bash
   npm install
   ```
3. Chạy ứng dụng Angular:
   ```bash
   ng serve --open
   ```
4. Ứng dụng sẽ mở tại: [http://localhost:4200](http://localhost:4200)

---

## 📂 Cấu trúc thư mục
```
Todolist-C-/
│── TodoApi/        # Backend ASP.NET Core Web API
│── todo-app/       # Frontend Angular
│── README.md       # Tài liệu hướng dẫn
```

---

## ✅ Kiểm tra
- Chạy backend trước để API hoạt động.
- Sau đó chạy frontend và test chức năng CRUD Todo.

---

## 📝 Ghi chú
- Nếu backend không chạy được, kiểm tra lại `launchSettings.json` trong **TodoApi/Properties** để chắc chắn cổng đúng `5003`.
- Nếu gặp lỗi CORS khi gọi API từ Angular, cần bật CORS trong `Program.cs`.

---

💡 Tác giả: NVT-21  
📌 Link GitHub: [https://github.com/NVT-21/Todolist-C-](https://github.com/NVT-21/Todolist-C-)
