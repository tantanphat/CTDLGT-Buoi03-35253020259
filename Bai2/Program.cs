
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

public class KhachHang
{
    // Lưu số thứ tự của khách hàng.
    public int MaKhach { get; set; }

    // Lưu thời điểm khách hàng đến.
    public long ThoiDiemDen { get; set; }

    // Lưu thời gian cần thiết để phục vụ khách hàng.
    public long ThoiGianPhucVu { get; set; }

    // Khởi tạo một khách hàng với đầy đủ thông tin.
    public KhachHang(int maKhach, long thoiDiemDen, long thoiGianPhucVu)
    {
        MaKhach = maKhach;
        ThoiDiemDen = thoiDiemDen;
        ThoiGianPhucVu = thoiGianPhucVu;
    }
}

class Program
{
    private static void TaoCaKiemThuSo6(Queue<KhachHang> hangDoi)
    {
        // Khởi tạo 100.000 khách hàng và 10 quầy phục vụ.
        int soKhach = 100000;
        int soQuay = 10;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i <= soKhach; i++)
        {
            // Khách thứ i đến lúc i - 1 và cần 10 đơn vị thời gian phục vụ.
            KhachHang khach = new KhachHang(i, i - 1, 10);

            // Đưa khách hàng vào cuối hàng đợi để bảo đảm nguyên tắc FIFO.
            hangDoi.Enqueue(khach);
        }
        stopwatch.Stop();
        Console.WriteLine($"Thời gian tạo dữ liệu kiểm thử số 6: {stopwatch.ElapsedMilliseconds} ms");

    }

    static void Main()
    {
        // Tạo hàng đợi để đảm bảo khách đến trước được phục vụ trước.
        Queue<KhachHang> hangDoi = new Queue<KhachHang>();
        TaoCaKiemThuSo6(hangDoi);

        // Đọc số lượng khách hàng và số lượng quầy phục vụ.
        string[] duLieuDau = Console.ReadLine()!.Split();

        int soKhach = int.Parse(duLieuDau[0]);
        int soQuay = int.Parse(duLieuDau[1]);


        // Đọc thông tin từng khách hàng và đưa vào cuối hàng đợi.
        for (int i = 1; i <= soKhach; i++)
        {
            string[] duLieu = Console.ReadLine()!.Split();

            long thoiDiemDen = long.Parse(duLieu[0]);
            long thoiGianPhucVu = long.Parse(duLieu[1]);

            // Tạo khách hàng mới để lưu thông tin phục vụ.
            KhachHang khach = new KhachHang(
                i, thoiDiemDen, thoiGianPhucVu
            );

            hangDoi.Enqueue(khach);
        }

        // Lưu thời điểm mỗi quầy có thể tiếp nhận khách tiếp theo.
        // Ban đầu tất cả quầy đều rảnh tại thời điểm 0.
        long[] thoiDiemRanh = new long[soQuay];

        // Lưu tổng thời gian chờ của tất cả khách hàng.
        long tongThoiGianCho = 0;

        // Lưu thời gian chờ lớn nhất của một khách hàng.
        long choLauNhat = 0;

        // Lưu thời điểm hoàn thành muộn nhất của toàn bộ khách hàng.
        long hoanThanhLuc = 0;

        // Xử lý lần lượt từng khách hàng theo nguyên tắc FIFO.
        while (hangDoi.Count > 0)
        {
            // Lấy khách hàng đầu tiên ra khỏi hàng đợi.
            KhachHang khach = hangDoi.Dequeue();

            // Tạm chọn quầy đầu tiên làm quầy rảnh sớm nhất.
            int quayTotNhat = 0;

            // Duyệt các quầy còn lại để tìm quầy có thời điểm rảnh nhỏ nhất.
            for (int i = 1; i < soQuay; i++)
            {
                // Chỉ đổi quầy khi tìm thấy quầy rảnh sớm hơn.
                // Nếu thời điểm bằng nhau, giữ quầy có số thứ tự nhỏ hơn.
                if (thoiDiemRanh[i] < thoiDiemRanh[quayTotNhat])
                {
                    quayTotNhat = i;
                }
            }

            // Khách chỉ có thể bắt đầu khi vừa đến nơi vừa có quầy rảnh.
            long thoiDiemBatDau = Math.Max(
                thoiDiemRanh[quayTotNhat],
                khach.ThoiDiemDen
            );

            // Tính thời gian khách phải chờ trước khi được phục vụ.
            long thoiGianCho = thoiDiemBatDau - khach.ThoiDiemDen;

            // Tính thời điểm khách hoàn thành việc phục vụ.
            long thoiDiemHoanThanh =
                thoiDiemBatDau + khach.ThoiGianPhucVu;

            // Cập nhật thời điểm quầy vừa chọn có thể phục vụ khách tiếp theo.
            thoiDiemRanh[quayTotNhat] = thoiDiemHoanThanh;

            // Cộng thời gian chờ của khách hiện tại vào tổng thời gian chờ.
            tongThoiGianCho += thoiGianCho;

            // Cập nhật thời gian chờ lâu nhất nếu khách hiện tại chờ lâu hơn.
            choLauNhat = Math.Max(choLauNhat, thoiGianCho);

            // Cập nhật thời điểm hoàn thành muộn nhất.
            hoanThanhLuc = Math.Max(
                hoanThanhLuc,
                thoiDiemHoanThanh
            );

            // In thông tin phục vụ của khách hàng hiện tại.
            Console.WriteLine(
                $"KH {khach.MaKhach}: den {khach.ThoiDiemDen}, " +
                $"quay {quayTotNhat + 1}, bat dau {thoiDiemBatDau}, " +
                $"cho {thoiGianCho}, xong {thoiDiemHoanThanh}"
            );
        }

        // Tính thời gian chờ trung bình của tất cả khách hàng.
        double choTrungBinh = (double)tongThoiGianCho / soKhach;

        // In thời gian chờ trung bình với hai chữ số thập phân.
        Console.WriteLine(
            "Cho trung binh: " +
            choTrungBinh.ToString("F2", CultureInfo.InvariantCulture)
        );

        // In thời gian chờ lớn nhất.
        Console.WriteLine($"Cho lau nhat: {choLauNhat}");

        // In thời điểm hoàn thành phục vụ của toàn bộ khách hàng.
        Console.WriteLine($"Hoan thanh luc: {hoanThanhLuc}");
    }

}
