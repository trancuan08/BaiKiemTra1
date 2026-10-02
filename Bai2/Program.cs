
using System;
using System.Collections.Generic;

class Program
{
    static QuanLyPhuongTien ql = new QuanLyPhuongTien();

    static void Main(string[] args)
    {
        int chon;

        do
        {
            Console.WriteLine("\n========== QUAN LY PHUONG TIEN ==========");
            Console.WriteLine("1. TC01 - Kiem tra nam san xuat");
            Console.WriteLine("2. TC02 - Kiem tra gia lan banh O to");
            Console.WriteLine("3. TC03 - Kiem tra gia lan banh Xe may");
            Console.WriteLine("4. TC04 - Kiem tra da hinh");
            Console.WriteLine("5. TC05 - Tim gia lan banh cao nhat");
            Console.WriteLine("6. Tu nhap thong tin phuong tien");
            Console.WriteLine("7. Hien thi danh sach");
            Console.WriteLine("8. Tim kiem theo ten hang");
            Console.WriteLine("9. Chay tat ca Test Case");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("=========================================");
            Console.Write("Nhap lua chon: ");

            if (!int.TryParse(Console.ReadLine(), out chon))
            {
                Console.WriteLine("Vui long nhap so!");
                continue;
            }

            try
            {
                switch (chon)
                {
                    case 1:
                        TC01();
                        break;
                    case 2:
                        TC02();
                        break;
                    case 3:
                        TC03();
                        break;
                    case 4:
                        TC04();
                        break;
                    case 5:
                        TC05();
                        break;
                    case 6:
                        NhapPhuongTien();
                        break;
                    case 7:
                        ql.DisplayAll();
                        break;
                    case 8:
                        Console.Write("Nhap ten hang: ");
                        string ten = Console.ReadLine() ?? "";
                        ql.SearchByName(ten);
                        break;
                    case 9:
                        TC01();
                        TC02();
                        TC03();
                        TC04();
                        TC05();
                        break;
                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

        } while (chon != 0);
    }

    // TC01
    static void TC01()
    {
        Console.WriteLine("\n========== TC01 ==========");

        try
        {
            OTo oto = new OTo(
                "OTO01", "Toyota", 1850,
                1000000000, 5, 2.0
            );

            Console.WriteLine("FAIL: Khong chan nam san xuat!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("PASS: He thong nem ngoai le!");
            Console.WriteLine("Thong bao: " + ex.Message);
            Console.WriteLine("Khong cho tao doi tuong.");
        }
    }

    // TC02
    static void TC02()
    {
        Console.WriteLine("\n========== TC02 ==========");

        OTo oto = new OTo(
            "OTO02", "Toyota", 2024,
            1000000000, 5, 2.0
        );

        double gia = oto.TinhGiaLanBanh();

        Console.WriteLine("Gia lan banh = " + gia.ToString("N0") + " VND");

        if (gia == 1420000000)
            Console.WriteLine("PASS: Ket qua dung!");
        else
            Console.WriteLine("FAIL: Ket qua sai!");
    }

    // TC03
    static void TC03()
    {
        Console.WriteLine("\n========== TC03 ==========");

        XeMay xe = new XeMay(
            "XM03", "Honda", 2024,
            50000000, 150
        );

        double gia = xe.TinhGiaLanBanh();

        Console.WriteLine("Gia lan banh = " + gia.ToString("N0") + " VND");

        if (gia == 51000000)
            Console.WriteLine("PASS: Ket qua dung!");
        else
            Console.WriteLine("FAIL: Ket qua sai!");
    }

    // TC04
    static void TC04()
    {
        Console.WriteLine("\n========== TC04 ==========");

        List<PhuongTien> ds = new List<PhuongTien>();

        ds.Add(new OTo(
            "OTO04", "Toyota", 2024,
            1000000000, 5, 2.0
        ));

        ds.Add(new XeMay(
            "XM04", "Honda", 2024,
            50000000, 150
        ));

        foreach (PhuongTien pt in ds)
        {
            pt.GetInfo();
            Console.WriteLine("Gia lan banh: " +
                pt.TinhGiaLanBanh().ToString("N0") + " VND");
        }

        Console.WriteLine("PASS: Da hinh hoat dong!");
    }

    // TC05
    static void TC05()
    {
        Console.WriteLine("\n========== TC05 ==========");

        QuanLyPhuongTien test = new QuanLyPhuongTien();

        test.AddPhuongTien(new OTo(
            "OTO05", "Toyota", 2024,
            1000000000, 5, 2.0
        ));

        test.AddPhuongTien(new XeMay(
            "XM05", "Honda", 2024,
            50000000, 150
        ));

        test.FindMaxGiaLanBanh();
    }

    // Tu nhap phuong tien
    static void NhapPhuongTien()
    {
        Console.WriteLine("\n1. O To");
        Console.WriteLine("2. Xe May");
        Console.Write("Chon loai phuong tien: ");

        int loai = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("maPT: ");
        string ma = Console.ReadLine() ?? "";

        Console.Write("tenHang: ");
        string ten = Console.ReadLine() ?? "";

        Console.Write("namSanXuat: ");
        int nam = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("giaGoc: ");
        double gia = double.Parse(Console.ReadLine() ?? "0");

        if (loai == 1)
        {
            Console.Write("soChoNgoi: ");
            int soCho = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("dungTichDongCo: ");
            double dungTich = double.Parse(Console.ReadLine() ?? "0");

            OTo oto = new OTo(
                ma, ten, nam, gia, soCho, dungTich
            );

            ql.AddPhuongTien(oto);
        }
        else if (loai == 2)
        {
            Console.Write("dungTichXylanh: ");
            double xyLanh = double.Parse(Console.ReadLine() ?? "0");

            XeMay xe = new XeMay(
                ma, ten, nam, gia, xyLanh
            );

            ql.AddPhuongTien(xe);
        }
        else
        {
            Console.WriteLine("Loai phuong tien khong hop le!");
        }
    }
}