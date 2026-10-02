using System;

namespace QuanLySanPham
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        public Product() { }

        public Product(string id, string name, string catId, string catName, decimal price, int qty, string imgPath)
        {
            ProductId = id;
            ProductName = name;
            CategoryId = catId;
            CategoryName = catName;
            UnitPrice = price;
            Quantity = qty;
            ImagePath = imgPath;
        }
    }

    public class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category(string id, string name)
        {
            CategoryId = id;
            CategoryName = name;
        }
    }
}