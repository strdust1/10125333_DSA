using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BT4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = null;
            int n = 0;
            while (true)
            {
                Console.WriteLine("1. Thêm và hiển thị mảng");
                Console.WriteLine("2. Chèn phần tử vào mảng");
                Console.WriteLine("3. Thoát");
                Console.Write("Chọn chức năng: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhập số phần tử n: ");
                        n = int.Parse(Console.ReadLine());

                        a = new int[n];

                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Nhập a[" + i + "]: ");
                            a[i] = int.Parse(Console.ReadLine());
                        }
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write(" " + a[i]);
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        if (a == null)
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước!");
                            break;
                        }

                        Console.Write("Nhập vị trí cần chèn: ");
                        int k = int.Parse(Console.ReadLine());

                        Console.Write("Nhập giá trị cần chèn: ");
                        int x = int.Parse(Console.ReadLine());

                        if (k < 0 || k > n)
                        {
                            Console.WriteLine("Vị trí không hợp lệ!");
                            break;
                        }

                        int[] tmp = new int[n + 1];

                        for (int i = 0; i < k; i++)
                        {
                            tmp[i] = a[i];
                        }

                        tmp[k] = x;

                        for (int i = k; i < n; i++)
                        {
                            tmp[i + 1] = a[i];
                        }

                        for (int i = 0; i < tmp.Length; i++)
                        {
                            Console.Write(" " + tmp[i]);
                        }
                        Console.WriteLine();
                        a = tmp;
                        n++;
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }
    }
}
