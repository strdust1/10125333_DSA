
using System;

namespace BT4._5
{
    class Nut
    {
        public int GiaTri;
        public Nut TiepTheo;

        public Nut(int giaTri)
        {
            GiaTri = giaTri;
            TiepTheo = null;
        }
    }

    internal class Program
    {
        static Nut dauDS = null;


        static void ChenCuoi(int giaTri)
        {
            Nut nutMoi = new Nut(giaTri);

            if (dauDS == null)
            {
                dauDS = nutMoi;
                return;
            }

            Nut hienTai = dauDS;

            while (hienTai.TiepTheo != null)
                hienTai = hienTai.TiepTheo;

            hienTai.TiepTheo = nutMoi;
        }


        static void NhapDuLieu()
        {
            Console.Write("Nhap so luong phan tu: ");
            int soLuong = int.Parse(Console.ReadLine());

            for (int i = 0; i < soLuong; i++)
            {
                Console.Write($"Nhap phan tu thu {i + 1}: ");
                int soNhap = int.Parse(Console.ReadLine());

                ChenCuoi(soNhap);
            }
        }


        static void HienThiDS()
        {
            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                Console.Write(hienTai.GiaTri + " ");
                hienTai = hienTai.TiepTheo;
            }

            Console.WriteLine();
        }


        static int LayGiaTriLonNhat()
        {
            int lonNhat = int.MinValue;
            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                if (hienTai.GiaTri > lonNhat)
                    lonNhat = hienTai.GiaTri;

                hienTai = hienTai.TiepTheo;
            }

            return lonNhat;
        }


        static int LayTongPhanTu()
        {
            int tongCong = 0;
            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                tongCong += hienTai.GiaTri;
                hienTai = hienTai.TiepTheo;
            }

            return tongCong;
        }


        static bool LaSoNguyenTo(int soCanKiemTra)
        {
            if (soCanKiemTra < 2)
                return false;

            for (int uoc = 2; uoc <= Math.Sqrt(soCanKiemTra); uoc++)
            {
                if (soCanKiemTra % uoc == 0)
                    return false;
            }

            return true;
        }


        static int DemSoNguyenTo()
        {
            int soLuongNT = 0;
            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                if (LaSoNguyenTo(hienTai.GiaTri))
                    soLuongNT++;

                hienTai = hienTai.TiepTheo;
            }

            return soLuongNT;
        }


        static void ThongKeAmDuongKhong()
        {
            int slAm = 0;
            int slDuong = 0;
            int slKhong = 0;

            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                if (hienTai.GiaTri < 0)
                    slAm++;
                else if (hienTai.GiaTri > 0)
                    slDuong++;
                else
                    slKhong++;

                hienTai = hienTai.TiepTheo;
            }

            Console.WriteLine("d. So am: " + slAm);
            Console.WriteLine("   So duong: " + slDuong);
            Console.WriteLine("   So bang 0: " + slKhong);
        }


        static int DemPhanTuBangX(int giaTriTim)
        {
            int ketQuaDem = 0;
            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                if (hienTai.GiaTri == giaTriTim)
                    ketQuaDem++;

                hienTai = hienTai.TiepTheo;
            }

            return ketQuaDem;
        }

        // f. Tim phan tu duong nho nhat
        static int LayDuongNhoNhat()
        {
            int duongNhoNhat = int.MaxValue;
            Nut hienTai = dauDS;

            while (hienTai != null)
            {
                if (hienTai.GiaTri > 0 &&
                    hienTai.GiaTri < duongNhoNhat)
                {
                    duongNhoNhat = hienTai.GiaTri;
                }

                hienTai = hienTai.TiepTheo;
            }

            return duongNhoNhat;
        }

        static void Main(string[] args)
        {
            dauDS = null;

            NhapDuLieu();

            Console.Write("\nDanh sach vua nhap: ");
            HienThiDS();


            if (dauDS != null)
                Console.WriteLine("a. Phan tu lon nhat: " + LayGiaTriLonNhat());
            else
                Console.WriteLine("a. Danh sach rong.");


            Console.WriteLine("b. Tong cac phan tu: " + LayTongPhanTu());


            Console.WriteLine("c. So luong so nguyen to: " + DemSoNguyenTo());


            ThongKeAmDuongKhong();


            Console.Write("\nNhap gia tri x can dem: ");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("e. So luong phan tu bang " + x + ": "
                + DemPhanTuBangX(x));


            int kqDuongMin = LayDuongNhoNhat();

            if (kqDuongMin == int.MaxValue)
                Console.WriteLine("f. Danh sach khong co so duong.");
            else
                Console.WriteLine("f. Phan tu duong nho nhat: " + kqDuongMin);
        }
    }
}
