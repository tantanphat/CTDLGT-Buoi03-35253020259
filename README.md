Thông tin sinh viên

Họ và tên: Nguyễn Tấn Phát

Mã số sinh viên: 35253020259

Học phần: 26C1INF50900706

Bài 1 – Kiểm tra dấu ngoặc cân bằng (Stack)

Hướng dẫn chạy chương trình

Bước 1: Mở thư mục Bai1 bằng VS Code.

Bước 2: Mở Terminal và di chuyển đến thư mục dự án:

cd Bai1

Bước 3: Chạy chương trình:

dotnet run

Chọn ca kiểm thử

Mở Program.cs, thay đổi biến input tương ứng:

Ca 9: Chuỗi gồm 500.000 dấu ( và 500.000 dấu ).

Ca 10: Chuỗi gồm 1.000.000 dấu (.

Nhập thủ công: Sử dụng string input = Console.ReadLine() ?? "";.

Sau khi thay đổi dữ liệu đầu vào, chạy lại dotnet run để xem kết quả và thời gian thực hiện.

Bài 2 – Mô phỏng quầy phục vụ (Queue)

Nhập dữ liệu

Dòng đầu tiên: Nhập số lượng khách hàng n và số quầy k.

n dòng tiếp theo: Mỗi dòng nhập thời điểm đến a và thời gian phục vụ s của một khách hàng.

Ví dụ:
3 2
0 5
1 3
2 4
Kết quả

Chương trình xuất thông tin từng khách hàng gồm:

Mã khách hàng.

Thời điểm đến và quầy được phân công.

Thời điểm bắt đầu phục vụ.

Thời gian chờ.

Thời điểm hoàn thành.

Cuối cùng, chương trình thống kê:

Thời gian chờ trung bình.

Thời gian chờ lâu nhất.

Thời điểm hoàn thành toàn bộ khách hàng.
