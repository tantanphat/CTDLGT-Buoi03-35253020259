using System;
using System.Diagnostics;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kiểm thử ca 9
            // string input = new string('(', 500000)
            //  + new string(')', 500000);
            // Console.WriteLine($"Độ dài chuỗi: {input.Length}");

            // Kiểm thử ca 10
            string input = new string('(', 1000000);
            Console.WriteLine($"Độ dài chuỗi: {input.Length}");

            // string input = Console.ReadLine();

            Stack<(char ch, int pos)> stack = new Stack<(char ch, int pos)>();

            // Bắt đầu đo thời gian thực hiện
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < input.Length; i++)
            {
                // Lấy ký tự hiện tại
                char ch = input[i];
                // Nếu ký tự là dấu ngoặc mở, đẩy nó vào stack cùng với vị trí của nó
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    // Đẩy ký tự và vị trí vào stack
                    stack.Push((ch, i));
                    continue;
                }
                // Nếu ký tự là dấu ngoặc đóng, kiểm tra xem nó có khớp với dấu ngoặc mở trên đỉnh stack không
                else if (ch == ')' || ch == ']' || ch == '}')
                {

                    // Kiểm tra xem stack có rỗng không.
                    if (stack.Count == 0)
                    {
                        Console.WriteLine($"Sai tai vi tri {i}");
                        sw.Stop();
                        Console.WriteLine($"Thời gian thực hiện: {sw.ElapsedMilliseconds} ms");
                        return;
                    }
                    // Lấy phần tử trên đỉnh stack mà không loại bỏ nó
                    var top = stack.Peek();
                    if ((ch == ')' && top.ch == '(') ||
                        (ch == ']' && top.ch == '[') ||
                        (ch == '}' && top.ch == '{'))
                    {
                        // Nếu khớp, loại bỏ phần tử trên đỉnh stack
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine($"Sai tai vi tri {i}");
                        sw.Stop();
                        Console.WriteLine($"Thời gian thực hiện: {sw.ElapsedMilliseconds} ms");
                        return;
                    }
                }
            }

            // Nếu stack không rỗng, có nghĩa là còn dấu ngoặc chưa được đóng. Mục đích Mở chưa đóng
            if (stack.Count > 0)
            {
                // Lấy vị trí của phần tử đầu tiên trong stack (tức là dấu ngoặc mở chưa được đóng)
                int firstPos = int.MaxValue;
                // Duyệt qua tất cả các phần tử trong stack để tìm vị trí nhỏ nhất
                while (stack.Count > 0)
                {
                    // Lấy phần tử trên đỉnh stack và loại bỏ nó
                    var top = stack.Pop();
                    // Nếu vị trí của phần tử này nhỏ hơn vị trí nhỏ nhất hiện tại, cập nhật vị trí nhỏ nhất
                    if (top.pos < firstPos)
                    {
                        // Cập nhật vị trí nhỏ nhất
                        firstPos = top.pos;
                    }
                }
                Console.WriteLine($"Sai tai vi tri {firstPos}");
                sw.Stop();
                Console.WriteLine($"Thời gian thực hiện: {sw.ElapsedMilliseconds} ms");
            }
            else
            {
                Console.WriteLine("HOPLE");
                sw.Stop();
                Console.WriteLine($"Thời gian thực hiện: {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}