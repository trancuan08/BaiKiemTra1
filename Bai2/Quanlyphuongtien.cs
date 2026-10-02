
using System;
using System.Collections.Generic;

public class QuanLyPhuongTien
{
    private List<PhuongTien> danhSach = new List<PhuongTien>();

    public void AddPhuongTien(PhuongTien pt)
    {
        danhSach.Add(pt);
        Console.WriteLine("Them phuong tien thanh cong!");
    }

    public void DisplayAll()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        foreach (PhuongTien pt in danhSach)
        {
            pt.GetInfo();
            Console.WriteLine("--------------------------");
        }
    }

    public void FindMaxGiaLanBanh()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        PhuongTien max = danhSach[0];

        foreach (PhuongTien pt in danhSach)
        {
            if (pt.TinhGiaLanBanh() > max.TinhGiaLanBanh())
                max = pt;
        }

        Console.WriteLine("Phuong tien co gia lan banh cao nhat:");
        max.GetInfo();
    }

    public void SearchByName(string ten)
    {
        bool timThay = false;

        foreach (PhuongTien pt in danhSach)
        {
            if (pt.TenHang.Contains(
                ten, StringComparison.OrdinalIgnoreCase))
            {
                pt.GetInfo();
                timThay = true;
            }
        }

        if (!timThay)
            Console.WriteLine("Khong tim thay phuong tien!");
    }
}