using System;

struct NhanVien
{
    public string MaNV;
    public string HoTen;
    public int NamSinh;
    public string PhongBan;
    public int LuongCB;
    public int Thuong;

    public int ThucLinh()
    {
        return LuongCB + Thuong;
    }
}

class VD
{
    static NhanVien[] DS =
    {
        new NhanVien { MaNV = "NV01", HoTen = "Nguyễn Vũ", LuongCB = 10000000, NamSinh = 1985, PhongBan = "Kinh Doanh", Thuong = 2000000 },
        new NhanVien { MaNV = "NV02", HoTen = "Vũ Tuấn Anh", LuongCB = 8000000, NamSinh = 1992, PhongBan = "Kinh Doanh", Thuong = 1000000 },
        new NhanVien { MaNV = "NV03", HoTen = "Quách Văn Bằng", LuongCB = 1200, NamSinh = 1988, PhongBan = "Hành chính", Thuong = 300 }
    };

    static void TinhThucLinh()
    {
        for (int i = 0; i < DS.Length; i++)
        {
            Console.WriteLine(DS[i].HoTen + ": " + DS[i].ThucLinh());
        }
    }
    static void LuongCBMin()
    {
        int minLuongCB = DS[0].LuongCB;
        for (int i = 1; i < DS.Length; i++)
        {
            if (DS[i].LuongCB < minLuongCB)
            {
                minLuongCB = DS[i].LuongCB;
            }
        }
        Console.WriteLine("Luong CB thap nhat: " + minLuongCB);
    }
    static void DemNV()
    {
        int count = 0;
        for (int i = 0; i < DS.Length; i++)
        {
            if (DS[i].LuongCB < 1200000)
            {
                count++;
            }
        }
        Console.WriteLine("So luong nhan vien co luong co ban thap hon 1200000: " + count);
    }
    static void InNV()
    {
        Array.Sort(DS, (a, b) =>
        {
            int kq = string.Compare(a.PhongBan, b.PhongBan);

            if (kq == 0)
            {
                return string.Compare(b.MaNV, a.MaNV);
            }

            return kq;
        });
        foreach (NhanVien nv in DS)
        {
            Console.WriteLine(nv.MaNV + " | " + nv.HoTen + " | " + nv.PhongBan);
        }
    }
    static void Main(string[] args)
    {
        TinhThucLinh();
        LuongCBMin();
        DemNV();
        InNV();
        while (true)
        {
            Console.WriteLine("Tăng lương 5%. (Press 1)");
            Console.WriteLine("Thoát (Press 2)");
            int irr  = int.Parse(Console.ReadLine());
            switch (irr)
            {
                case 1:
                    for (int i = 0; i < DS.Length; i++)
                    {
                        DS[i].LuongCB = DS[i].LuongCB * 105 / 100;
                    }
                    TinhThucLinh();
                    break;
                case 2:
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    break;
            }
        }
    }
}