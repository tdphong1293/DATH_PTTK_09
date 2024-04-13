USE PTTK_ABC
GO

CREATE OR ALTER PROCEDURE checkLogin
    @username VARCHAR(30), 
    @password VARCHAR(30)
AS
BEGIN
    IF EXISTS (SELECT * FROM THANHVIEN WHERE @username = TenDangNhap AND @password = MatKhau)
        SELECT LoaiThanhVien FROM THANHVIEN WHERE @username = TenDangNhap AND @password = MatKhau
    ELSE 
        SELECT NULL AS LoaiThanhVien;
END
go

create or alter procedure CreateUngVien
    @username varchar(30),
    @password varchar(30),
    @name nvarchar(50),
    @email varchar(50),
    @birth date
as
    declare @returnid int;
begin
    insert into THANHVIEN (TenDangNhap, MatKhau, Ten, Email, LoaiThanhVien) 
        values (@username, @password, @name, @email, 'DOANHNGHIEP') return @returnid;
    insert into UNGVIEN (ID) values (@returnid, @birth);
end;
go

create or alter procedure CreateDoanhNghiep
    @username varchar(30),
    @password varchar(30),
    @name nvarchar(50),
    @email varchar(50),
    @masothue char(10),
    @nguoidaidien nvarchar(50),
    @diachi nvarchar(100)
as
    declare @returnid int;
begin
    insert into THANHVIEN (TenDangNhap, MatKhau, Ten, Email, LoaiThanhVien) 
        values (@username, @password, @name, @email, 'UNGVIEN') return @returnid;
    insert into UNGVIEN values (@returnid, @masothue, @nguoidaidien, @diachi, 0);
end;
go

