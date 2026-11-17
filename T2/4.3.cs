using System;
using System.Xml.Linq;

namespace Bt4._3
{
    internal class Program
    {
        static int[,] NhapMaTran(out int n)
        {
            do
            {
                Console.Write("Nhập cấp ma trận vuông n (0 < n < 100): ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0 || n >= 100);
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return a;
        }

        static void XuatMaTran(int[,] a, int n)
        {
            Console.WriteLine("\nMa trận vừa nhập:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{a[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static int TongMaTran(int[,] a, int n)
        {
            int t = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    t += a[i, j];
            return t;
        }

        static int TimDuongNhoNhat(int[,] a, int n)
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] > 0 && a[i, j] < min)
                        min = a[i, j];
            return min;
        }

        static int TongCheoPhu(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (j == (n - 1) - i)
                        tong += a[i, j];
            return tong;
        }

        static bool KiemTraCheoChinhTangDan(int[,] a, int n)
        {
            int[] tg = new int[n];
            for (int i = 0; i < n; i++)
                tg[i] = a[i, i];

            for (int i = 0; i <= n - 2; i++)
                for (int j = i + 1; j <= n - 1; j++)
                    if (tg[i] >= tg[j])
                        return false;
            return true;
        }
        static void Main(string[] args)
        {
            int n;
            int[,] a = NhapMaTran(out n);
            XuatMaTran(a, n);
            Console.WriteLine($"\na. Tổng tất cả phần tử của ma trận: {TongMaTran(a, n)}");
            int minDuong = TimDuongNhoNhat(a, n);
            if (minDuong == int.MaxValue)
                Console.WriteLine("b. Ma trận không có phần tử dương nào.");
            else
                Console.WriteLine($"b. Giá trị dương nhỏ nhất của ma trận: {minDuong}");
            Console.WriteLine($"c. Tổng các phần tử trên đường chéo phụ: {TongCheoPhu(a, n)}");
            bool tangDan = KiemTraCheoChinhTangDan(a, n);
            if (tangDan)
                Console.WriteLine("d. Các phần tử trên đường chéo chính TĂNG DẦN.");
            else
                Console.WriteLine("d. Các phần tử trên đường chéo chính KHÔNG tăng dần.");
        }
    }
}
