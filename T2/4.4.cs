using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BT4._4
{
    internal class Program
    {
        static Node pHead = null;
        class Node
        {
            public int Data;
            public Node Next;

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        static void ThemCuoi(int data)
        {
            Node newNode = new Node(data);
            if (pHead == null)
            {
                pHead = newNode;
                return;
            }
            Node p = pHead;
            while (p.Next != null)
                p = p.Next;
            p.Next = newNode;
        }

        static void NhapDanhSach()
        {
            Console.Write("Nhập số lượng phần tử n: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int val;
                do
                {
                    Console.Write($"Nhập phần tử dương thứ {i + 1}: ");
                    val = int.Parse(Console.ReadLine());
                } while (val <= 0);
                ThemCuoi(val);
            }
        }

        static void XuatDanhSach()
        {
            Node p = pHead;
            while (p != null)
            {
                Console.Write(p.Data + " ");
                p = p.Next;
            }
            Console.WriteLine();
        }

        static int DemSoBangX(int x)
        {
            int d = 0;
            Node p = pHead;
            while (p != null)
            {
                if (p.Data == x) d = d + 1;
                p = p.Next;
            }
            return d;
        }

        static int TimDuongNhoNhat4()
        {
            int minduong = int.MaxValue;
            Node p = pHead;
            while (p != null)
            {
                if (p.Data > 0 && p.Data < minduong)
                    minduong = p.Data;
                p = p.Next;
            }
            return minduong;
        }

        static void XoaPhanTuXDauTien(int x)
        {
            Node p = pHead;
            Node t = null;
            while (p != null && p.Data != x)
            {
                t = p;
                p = p.Next;
            }
            if (p == null)
            {
                Console.WriteLine($"Không tìm thấy phần tử {x} trong danh sách!");
                return;
            }
            if (p == pHead)
                pHead = pHead.Next;
            else
                t.Next = p.Next;
            Console.WriteLine($"Đã xóa phần tử {x} xuất hiện đầu tiên.");
        }
        static void Main(string[] args)
        {
            pHead = null;
            NhapDanhSach();
            Console.Write("\nDanh sách vừa nhập: ");
            XuatDanhSach();

            Console.Write("\nNhập giá trị x cần đếm: ");
            int xDem = int.Parse(Console.ReadLine());
            Console.WriteLine($"a. Số lượng phần tử bằng {xDem} là: {DemSoBangX(xDem)}");

            int minDuong = TimDuongNhoNhat4();
            if (minDuong == int.MaxValue)
                Console.WriteLine("\nb. Danh sách không có phần tử dương.");
            else
                Console.WriteLine($"\nb. Phần tử dương nhỏ nhất trong danh sách là: {minDuong}");

            Console.Write("\nNhập giá trị x cần xóa (lần xuất hiện đầu tiên): ");
            int xXoa = int.Parse(Console.ReadLine());
            XoaPhanTuXDauTien(xXoa);
            Console.Write("Danh sách sau khi xóa: ");
            XuatDanhSach();
        }
    }
}
