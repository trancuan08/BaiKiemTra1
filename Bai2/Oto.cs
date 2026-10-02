
using System;

public class OTo : PhuongTien
{
    public int SoChoNgoi { get; set; }
    public double DungTichDongCo { get; set; }

    public OTo(string maPT, string tenHang,
                int namSanXuat, double giaGoc,
                int soChoNgoi, double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (soChoNgoi <= 0)
            throw new ArgumentException("So cho ngoi phai lon hon 0!");

        if (dungTichDongCo <= 0)
            throw new ArgumentException("Dung tich dong co phai lon hon 0!");

        SoChoNgoi = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }

    public override double TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
            return GiaGoc + GiaGoc * 0.12 + GiaGoc * 0.30;

        return GiaGoc + GiaGoc * 0.10;
    }

    public override void GetInfo()
    {
        Console.WriteLine("\n===== THONG TIN O TO =====");
        base.GetInfo();
        Console.WriteLine("So cho ngoi: " + SoChoNgoi);
        Console.WriteLine("Dung tich dong co: " + DungTichDongCo);
        Console.WriteLine("Gia lan banh: " +
            TinhGiaLanBanh().ToString("N0") + " VND");
    }
}