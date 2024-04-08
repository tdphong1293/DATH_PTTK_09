USE PTTK_ABC
GO

CREATE OR ALTER PROCEDURE checkLogin
    @username VARCHAR(30), 
    @password VARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT * FROM THANHVIEN WHERE @username = TenDangNhap AND @password = MatKhau)
        SELECT LoaiThanhVien FROM THANHVIEN WHERE @username = TenDangNhap AND @password = MatKhau
    ELSE 
        SELECT NULL AS LoaiThanhVien;
END

insert into THANHVIEN (TenDangNhap, MatKhau) values ('nv01', '123');
update THANHVIEN set LoaiThanhVien = 'NVCOBAN' where TenDangNhap = 'nv01';

insert into THANHVIEN (TenDangNhap, MatKhau, LoaiThanhVien) values ('dn01', '123', 'DOANHNGHIEP');

select* from THANHVIEN;