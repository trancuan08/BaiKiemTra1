
using System;

public class XeMay : PhuongTien
{
    public double DungTichXylanh { get; set; }

    public XeMay(string maPT, string tenHang,
                 int namSanXuat, double giaGoc,
                 double dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (dungTichXylanh <= 0)
            throw new ArgumentException("Dung tich xy-lanh phai lon hon 0!");

        DungTichXylanh = dungTichXylanh;
    }

    public override double TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
            return GiaGoc + GiaGoc * 0.02;

        return GiaGoc + GiaGoc * 0.05;
    }

    public override void GetInfo()
    {
        Console.WriteLine("\n===== THONG TIN XE MAY =====");
        base.GetInfo();
        Console.WriteLine("Dung tich xy-lanh: " + DungTichXylanh + " cc");
        Console.WriteLine("Gia lan banh: " +
            TinhGiaLanBanh().ToString("N0") + " VND");
    }
}