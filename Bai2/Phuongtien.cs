
using System;

public abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private double _giaGoc;

    public string MaPT
    {
        get { return _maPT; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ma phuong tien khong duoc rong!");

            _maPT = value;
        }
    }

    public string TenHang
    {
        get { return _tenHang; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ten hang khong duoc rong!");

            _tenHang = value;
        }
    }

    public int NamSanXuat
    {
        get { return _namSanXuat; }
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException("Nam san xuat khong hop le!");

            _namSanXuat = value;
        }
    }

    public double GiaGoc
    {
        get { return _giaGoc; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Gia goc phai lon hon 0!");

            _giaGoc = value;
        }
    }

    public PhuongTien(string maPT, string tenHang,
                      int namSanXuat, double giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc = giaGoc;
    }

    public abstract double TinhGiaLanBanh();

    public virtual void GetInfo()
    {
        Console.WriteLine("Ma phuong tien: " + MaPT);
        Console.WriteLine("Ten hang: " + TenHang);
        Console.WriteLine("Nam san xuat: " + NamSanXuat);
        Console.WriteLine("Gia goc: " + GiaGoc.ToString("N0") + " VND");
    }
}