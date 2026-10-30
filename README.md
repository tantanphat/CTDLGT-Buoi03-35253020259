# BÀI TẬP THỰC HÀNH 03 – STACK & QUEUE

## 1. Thông tin sinh viên

| Nội dung | Thông tin |
|---|---|
| **Họ và tên** | Nguyễn Tấn Phát |
| **Mã số sinh viên** | 35253020259 |
| **Học phần** | 26C1INF50900706 |

---

## 2. Bài 1 – Kiểm tra dấu ngoặc cân bằng (Stack)

### 2.1. Hướng dẫn chạy chương trình

**Bước 1:** Mở thư mục `Bai1` bằng VS Code.

**Bước 2:** Mở Terminal và di chuyển đến thư mục dự án:

```bash
cd Bai1
```

**Bước 3:** Chạy chương trình:

```bash
dotnet run
```

### 2.2. Chọn ca kiểm thử

Mở file `Program.cs` và thay đổi biến `input` tương ứng với ca kiểm thử:

- **Ca 9:** Chuỗi gồm 500.000 dấu `(` và 500.000 dấu `)`.
- **Ca 10:** Chuỗi gồm 1.000.000 dấu `(`.
- **Nhập thủ công:** Sử dụng dòng lệnh:

```csharp
string input = Console.ReadLine() ?? "";
```

Sau khi thay đổi dữ liệu đầu vào, chạy lại `dotnet run` để xem kết quả và thời gian thực hiện.

---

## 3. Bài 2 – Mô phỏng quầy phục vụ (Queue)

### 3.1. Nhập dữ liệu

Chương trình nhận dữ liệu theo định dạng:

- **Dòng đầu tiên:** Nhập số lượng khách hàng `n` và số quầy phục vụ `k`.
- **n dòng tiếp theo:** Mỗi dòng nhập thời điểm đến `a` và thời gian phục vụ `s` của một khách hàng.

**Ví dụ:**

```text
3 2
0 5
1 3
2 4
```

### 3.2. Kết quả chương trình

Chương trình xuất thông tin từng khách hàng, bao gồm:

- Mã khách hàng.
- Thời điểm đến và quầy được phân công.
- Thời điểm bắt đầu phục vụ.
- Thời gian chờ.
- Thời điểm hoàn thành.

Cuối cùng, chương trình thống kê:

- Thời gian chờ trung bình.
- Thời gian chờ lâu nhất.
- Thời điểm hoàn thành toàn bộ khách hàng.

---

## 4. Bài 3 – Tự cài đặt hàng đợi vòng (Circular Queue)

### 4.1. Hướng dẫn chạy chương trình

**Bước 1:** Mở thư mục `Bai3` bằng VS Code.

**Bước 2:** Mở Terminal và di chuyển đến thư mục dự án:

```bash
cd Bai3
```

**Bước 3:** Chạy chương trình:

```bash
dotnet run
```

### 4.2. Hướng dẫn sử dụng

Sau khi chạy, chương trình hiển thị menu với các lựa chọn:

| Lựa chọn | Chức năng |
|---|---|
| **1** | Thêm phần tử vào hàng đợi (Enqueue). |
| **2** | Lấy và xóa phần tử đầu (Dequeue). |
| **3** | Xem phần tử đầu (Peek). |
| **4** | Hiển thị các phần tử, Count và Capacity. |
| **5** | Kiểm thử 1.000.000 lần Enqueue và Dequeue. |
| **6** | Kiểm thử thêm và lấy 100.000 phần tử, kiểm tra thứ tự FIFO. |
| **0** | Thoát chương trình. |

### 4.3. Cách kiểm thử

Nhập lựa chọn tương ứng trên menu và làm theo hướng dẫn nhập dữ liệu hiển thị trên màn hình.

**Lưu ý:** Nên chạy lựa chọn **5** và **6** khi hàng đợi đang rỗng để kết quả kiểm thử chính xác.
