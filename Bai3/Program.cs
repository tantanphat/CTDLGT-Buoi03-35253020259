
using System;
using System.Diagnostics;

public class CircularQueue<T>
{
    // Mảng lưu trữ các phần tử của hàng đợi vòng.
    private T[] items;

    // Vị trí phần tử đầu tiên trong hàng đợi.
    private int front;

    // Vị trí tiếp theo sẽ thêm phần tử mới.
    private int rear;

    // Số lượng phần tử hiện đang có trong hàng đợi.
    private int count;

    // Khởi tạo hàng đợi với dung lượng ban đầu bằng 4.
    public CircularQueue()
    {
        items = new T[4];
        front = 0;
        rear = 0;
        count = 0;
    }

    // Trả về số lượng phần tử hiện có.
    public int Count => count;

    // Trả về dung lượng hiện tại của mảng.
    public int Capacity => items.Length;

    // Mở rộng mảng gấp đôi và sao chép theo thứ tự FIFO.
    private void Resize()
    {
        // Tạo mảng mới có dung lượng gấp đôi mảng cũ.
        T[] newItems = new T[items.Length * 2];

        // Sao chép các phần tử theo thứ tự logic bắt đầu từ front.
        for (int i = 0; i < count; i++)
        {
            newItems[i] = items[(front + i) % items.Length];
        }

        // Thay mảng cũ bằng mảng mới.
        items = newItems;

        // Đưa phần tử đầu tiên về vị trí 0 trong mảng mới.
        front = 0;

        // Vị trí thêm tiếp theo là ô ngay sau phần tử cuối.
        rear = count;
    }

    // Thêm phần tử vào cuối hàng đợi.
    public void Enqueue(T value)
    {
        // Nếu hàng đợi đầy, mở rộng mảng trước khi thêm.
        if (count == items.Length)
        {
            Resize();
        }

        // Đưa phần tử mới vào vị trí rear.
        items[rear] = value;

        // Di chuyển rear sang ô kế tiếp theo cơ chế vòng.
        rear = (rear + 1) % items.Length;

        // Tăng số lượng phần tử sau khi thêm thành công.
        count++;
    }

    // Lấy và xóa phần tử đầu tiên trong hàng đợi.
    public T Dequeue()
    {
        // Không thể lấy phần tử nếu hàng đợi đang rỗng.
        if (count == 0)
        {
            throw new InvalidOperationException(
                "Hang doi dang rong!");
        }

        // Lưu phần tử đầu tiên để trả về sau khi xóa.
        T value = items[front];

        // Xóa tham chiếu cũ để tránh giữ dữ liệu không cần thiết.
        items[front] = default;

        // Di chuyển front sang phần tử tiếp theo.
        front = (front + 1) % items.Length;

        // Giảm số lượng phần tử sau khi lấy ra.
        count--;

        return value;
    }

    // Xem phần tử đầu tiên mà không xóa khỏi hàng đợi.
    public T Peek()
    {
        // Không thể xem phần tử đầu nếu hàng đợi rỗng.
        if (count == 0)
        {
            throw new InvalidOperationException(
                "Hang rong!");
        }

        // Trả về phần tử tại front nhưng không thay đổi dữ liệu.
        return items[front];
    }
}

public class Program
{
    public static void Main()
    {
        // Tạo một hàng đợi vòng chứa các chuỗi.
        CircularQueue<string> queue = new CircularQueue<string>();

        int choice;

        do
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("================================");
            Console.WriteLine("1. Them phan tu (Enqueue)");
            Console.WriteLine("2. Lay phan tu (Dequeue)");
            Console.WriteLine("3. Xem phan tu dau (Peek)");
            Console.WriteLine("4. Xem thông tin");
            Console.WriteLine("5: Lặp 1 000 000 lần: Enqueue rồi Dequeue");
            Console.WriteLine("6: Enqueue 100 000 phần tử rồi Dequeue hết");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("================================");
            Console.Write("Nhap lua chon: ");

            // Đọc lựa chọn của người dùng và kiểm tra dữ liệu nhập.
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Nhap lua chon");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Thêm phần tử vào hàng đợi.
                    Console.Write("Nhap so luong phan tu can them: ");
                    int n1 = int.Parse(Console.ReadLine());
                    string[] str = Console.ReadLine().Split(' ');

                    for (int i = 0; i < n1; i++)
                    {
                        string value = str[i];
                        queue.Enqueue(value);
                    }
                    if (queue.Count == 0)
                    {
                        Console.WriteLine("Hang doi dang rong!");
                    }
                    else
                    {
                        // Tạm lấy các phần tử ra để hiển thị.
                        int n = queue.Count;

                        for (int i = 0; i < n; i++)
                        {
                            string item = queue.Dequeue();

                            Console.Write(item + " ");

                            // Thêm lại phần tử để khôi phục hàng đợi.
                            queue.Enqueue(item);
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine($"Count: {queue.Count}");
                    Console.WriteLine($"Capacity: {queue.Capacity}");
                    break;

                case 2:
                    Console.Write("Nhap so luong phan tu can xoa: ");
                    int n2 = int.Parse(Console.ReadLine());

                    if (n2 > queue.Count)
                    {
                        Console.WriteLine("So luong can xoa vuot qua so phan tu hien co!");
                        break;
                    }

                    for (int i = 0; i < n2; i++)
                    {
                        string value = queue.Dequeue();
                        Console.WriteLine($"Da xoa phan tu: {value}");
                    }

                    Console.WriteLine($"Da xoa {n2} phan tu thanh cong!");
                    if (queue.Count == 0)
                    {
                        Console.WriteLine("Hang doi dang rong!");
                    }
                    else
                    {
                        // Tạm lấy các phần tử ra để hiển thị.
                        int n = queue.Count;

                        for (int i = 0; i < n; i++)
                        {
                            string item = queue.Dequeue();

                            Console.Write(item + " ");

                            // Thêm lại phần tử để khôi phục hàng đợi.
                            queue.Enqueue(item);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine($"Count: {queue.Count}");
                    Console.WriteLine($"Capacity: {queue.Capacity}");
                    break;

                case 3:
                    // Xem phần tử đầu nhưng không xóa.
                    try
                    {
                        Console.WriteLine($"Phan tu dau: {queue.Peek()}");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Hang doi dang rong!");
                    }
                    break;

                case 4:
                    // Hiển thị trạng thái hàng đợi theo thứ tự FIFO.
                    Console.WriteLine("\n--- Thông tin ---");

                    if (queue.Count == 0)
                    {
                        Console.WriteLine("Hang doi dang rong!");
                    }
                    else
                    {
                        // Tạm lấy các phần tử ra để hiển thị.
                        int n = queue.Count;

                        for (int i = 0; i < n; i++)
                        {
                            string item = queue.Dequeue();

                            Console.Write(item + " ");

                            // Thêm lại phần tử để khôi phục hàng đợi.
                            queue.Enqueue(item);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine($"Count: {queue.Count}");
                    Console.WriteLine($"Capacity: {queue.Capacity}");
                    break;

                case 5:
                    // Lặp 1 000 000 lần: Enqueue rồi Dequeue.  
                    {
                        // Lặp 1 000 000 lần: Enqueue rồi Dequeue.
                        for (int i = 0; i < 1_000_000; i++)
                        {
                            queue.Enqueue("Test");
                            queue.Dequeue();
                        }

                        Console.WriteLine($"Count: {queue.Count}");
                        Console.WriteLine($"Capacity: {queue.Capacity}");
                    }
                    break;
                case 6:
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    // Thêm 100.000 phần tử vào hàng đợi.
                    for (int i = 0; i < 100_000; i++)
                    {
                        queue.Enqueue(i.ToString());
                    }

                    // Xóa và kiểm tra thứ tự FIFO.
                    bool dungThuTu = true;

                    for (int i = 0; i < 100_000; i++)
                    {
                        string value = queue.Dequeue();

                        if (value != i.ToString())
                        {
                            dungThuTu = false;
                            Console.WriteLine($"Sai thu tu tai vi tri {i}!");
                            break;
                        }
                    }

                    sw.Stop();

                    Console.WriteLine(dungThuTu
                        ? "Kiem thu FIFO thanh cong!"
                        : "Kiem thu FIFO that bai!");

                    Console.WriteLine($"Count: {queue.Count}");
                    Console.WriteLine($"Capacity: {queue.Capacity}");
                    Console.WriteLine($"Thoi gian thuc thi: {sw.ElapsedMilliseconds} ms");
                    break;

                case 0:
                    // Kết thúc chương trình.
                    Console.WriteLine("Ket thuc chuong trinh!");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }

        } while (choice != 0);
    }
}
