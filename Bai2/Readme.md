# BÀI 2: QUẢN LÝ PHƯƠNG TIỆN

## TC01: Kiểm tra Validation năm sản xuất

**Thao tác:** Khởi tạo ô tô có NamSanXuat = 1850.

**Kết quả mong đợi:** Hệ thống ném ArgumentException và không cho tạo đối tượng.

### Hình ảnh kết quả TC01

<img width="399" height="107" alt="TC1" src="https://github.com/user-attachments/assets/68d081dd-b78b-422d-bd01-e6eaa7706b73" />


---

## TC02: Kiểm tra tính giá lăn bánh ô tô

**Thao tác:** Ô tô 5 chỗ, GiaGoc = 1.000.000.000 VND.

**Kết quả mong đợi:** Giá lăn bánh = 1.420.000.000 VND.

### Hình ảnh kết quả TC02

<img width="384" height="91" alt="TC2" src="https://github.com/user-attachments/assets/ed05f2d6-fe2f-4977-883a-13ef551cf318" />


---

## TC03: Kiểm tra tính giá lăn bánh xe máy

**Thao tác:** Xe máy 150cc, GiaGoc = 50.000.000 VND.

**Kết quả mong đợi:** Giá lăn bánh = 51.000.000 VND.

### Hình ảnh kết quả TC03

<img width="320" height="89" alt="TC3" src="https://github.com/user-attachments/assets/995711a1-c4ca-4af9-b7ce-6d432954c49c" />


---

## TC04: Kiểm tra đa hình List<PhuongTien>

**Thao tác:** Nạp 1 ô tô và 1 xe máy vào List<PhuongTien>, gọi TinhGiaLanBanh() trong vòng lặp.

**Kết quả mong đợi:** C# tự động gọi đúng công thức tính giá lăn bánh tương ứng của ô tô và xe máy.

### Hình ảnh kết quả TC04

<img width="436" height="419" alt="TC4" src="https://github.com/user-attachments/assets/6187e556-d8a3-47bf-aa2c-365516ca761f" />


---

## TC05: Kiểm tra tìm giá lăn bánh cao nhất

**Thao tác:** Gọi hàm FindMaxGiaLanBanh().

**Kết quả mong đợi:** Trả về ô tô Toyota 5 chỗ có giá lăn bánh 1,42 tỷ VND.

### Hình ảnh kết quả TC05

<img width="407" height="272" alt="TC5" src="https://github.com/user-attachments/assets/8937dd41-53d8-41fa-a929-e33d58ad126c" />


---

## Kết luận

Chương trình đã thực hiện các chức năng quản lý phương tiện và kiểm thử các trường hợp TC01 đến TC05.


