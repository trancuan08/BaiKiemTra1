using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLySanPham
{
    public partial class Form1 : Form
    {
        private BindingList<Product> originalList = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        private string selectedImagePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitCategories();
            InitSampleData();

            bindingSource.DataSource = originalList;
            dgvProducts.DataSource = bindingSource;

            UpdateStatusCount();
        }

        private void InitCategories()
        {
            List<Category> categories = new List<Category>
            {
                new Category("CAT01", "Điện thoại"),
                new Category("CAT02", "Laptop"),
                new Category("CAT03", "Phụ kiện")
            };

            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
        }

        private void InitSampleData()
        {
            originalList.Add(new Product("SP01", "iPhone 15 Pro", "CAT01", "Điện thoại", 28000000, 10, ""));
            originalList.Add(new Product("SP02", "Laptop Dell XPS", "CAT02", "Laptop", 35000000, 5, ""));
            originalList.Add(new Product("SP03", "Tai nghe AirPods", "CAT03", "Phụ kiện", 4500000, 20, ""));
        }

        private void UpdateStatusCount()
        {
            lblStatus.Text = $"Tổng số sản phẩm: {bindingSource.Count}";
        }

        // --- XỬ LÝ NẠP DỮ LIỆU LÊN INPUT KHI CHỌN DÒNG ---
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product selectedProd)
            {
                txtProductId.Text = selectedProd.ProductId;
                txtProductName.Text = selectedProd.ProductName;
                cboCategory.SelectedValue = selectedProd.CategoryId;
                txtUnitPrice.Text = selectedProd.UnitPrice.ToString("0");
                txtQuantity.Text = selectedProd.Quantity.ToString();
                selectedImagePath = selectedProd.ImagePath;

                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    picAvatar.Image = Image.FromFile(selectedImagePath);
                }
                else
                {
                    picAvatar.Image = null;
                }
            }
        }

        // --- XỬ LÝ NÚT CHỌN Ảnh (TC04) ---
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picAvatar.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        // --- XỬ LÝ VALIDATION (TC02) ---
        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã SP không trống
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                errorProvider1.SetError(txtProductId, "Mã sản phẩm không được để trống!");
                isValid = false;
            }

            // 2. Kiểm tra Tên SP không trống
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Đơn giá > 0
            if (!decimal.TryParse(txtUnitPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider1.SetError(txtUnitPrice, "Đơn giá phải là số > 0!");
                isValid = false;
            }

            // 4. Kiểm tra Số lượng >= 0
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                errorProvider1.SetError(txtQuantity, "Số lượng phải là số nguyên ≥ 0!");
                isValid = false;
            }

            return isValid;
        }

        // --- HÀNH ĐỘNG THÊM MỚI (TC03) ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Kiểm tra trùng Mã SP
            if (originalList.Any(p => p.ProductId.Equals(txtProductId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtProductId, "Mã sản phẩm đã tồn tại!");
                return;
            }

            Product p = new Product(
                txtProductId.Text.Trim(),
                txtProductName.Text.Trim(),
                cboCategory.SelectedValue.ToString(),
                cboCategory.Text,
                decimal.Parse(txtUnitPrice.Text),
                int.Parse(txtQuantity.Text),
                selectedImagePath
            );

            originalList.Add(p);
            UpdateStatusCount();
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- HÀNH ĐỘNG CẬP NHẬT ---
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            if (!ValidateInput()) return;

            Product selectedProd = (Product)dgvProducts.CurrentRow.DataBoundItem;
            selectedProd.ProductName = txtProductName.Text.Trim();
            selectedProd.CategoryId = cboCategory.SelectedValue.ToString();
            selectedProd.CategoryName = cboCategory.Text;
            selectedProd.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            selectedProd.Quantity = int.Parse(txtQuantity.Text);
            selectedProd.ImagePath = selectedImagePath;

            bindingSource.ResetBindings(false);
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- HÀNH ĐỘNG XÓA (TC05) ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Product selectedProd = (Product)dgvProducts.CurrentRow.DataBoundItem;
                originalList.Remove(selectedProd);
                bindingSource.ResetBindings(false);
                UpdateStatusCount();
            }
        }

        // --- TÌM KIẾM THEO THỜI GIAN THỰC (LIVE SEARCH) ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                bindingSource.DataSource = originalList;
            }
            else
            {
                var filtered = originalList.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();
                bindingSource.DataSource = new BindingList<Product>(filtered);
            }
            UpdateStatusCount();
        }

        // --- XUẤT CSV ---
        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = "Products_Export.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng");

                        foreach (Product p in originalList)
                        {
                            sb.AppendLine($"\"{p.ProductId}\",\"{p.ProductName}\",\"{p.CategoryName}\",{p.UnitPrice},{p.Quantity}");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất danh sách ra file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- THOÁT ỨNG DỤNG ---
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}