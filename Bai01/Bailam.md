Câu 1: Phân biệt Value Types và Reference Types trong C#

Value Types (Kiểu giá trị): Lưu trực tiếp giá trị của biến, thường nằm trên Stack nếu là biến cục bộ. Khi sao chép, mỗi biến có một bản giá trị riêng.

Reference Types (Kiểu tham chiếu): Biến lưu tham chiếu đến đối tượng thường nằm trên Heap. Khi sao chép, hai biến có thể cùng tham chiếu đến một đối tượng.

Câu 2: Sự khác nhau giữa init và set trong C#

set: Cho phép thay đổi giá trị thuộc tính bất cứ lúc nào.

init: Chỉ cho phép gán giá trị khi khởi tạo đối tượng hoặc trong constructor, sau đó không thể gán lại thông thường.

Ứng dụng thực tế: Dùng init cho các thông tin cần cố định sau khi khởi tạo như mã sinh viên, mã đơn hàng hoặc thông tin định danh.

Câu 3: Phân biệt virtual và override trong tính đa hình

virtual: Khai báo ở lớp cha, cho phép phương thức được ghi đè ở lớp con.

override: Khai báo ở lớp con, dùng để thay đổi cách thực hiện phương thức của lớp cha.

Ý nghĩa: Giúp cùng một phương thức có thể thực hiện các hành vi khác nhau tùy theo kiểu đối tượng thực tế, thể hiện tính đa hình.

Câu 4: Tại sao static không thể truy xuất thông qua Object Instance?

Thành phần static thuộc về lớp (Class), không thuộc về từng đối tượng được tạo bằng new.

Vì vậy, thành phần static được truy cập thông qua tên lớp thay vì đối tượng. Điều này giúp phân biệt dữ liệu dùng chung của lớp với dữ liệu riêng của từng đối tượng.
