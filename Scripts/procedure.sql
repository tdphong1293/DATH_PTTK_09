USE PTTK_ABC
GO

--Trong
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

create or alter proc ThemPDT 
	@vtdt varchar(50),
	@sltd int,
	@iddn int,
	@pqc int
as
begin
	insert into PHIEUDANGTUYEN values(@vtdt, @sltd, @iddn, @pqc);
end

go

create or alter proc ThemPQC
	@NBD date,
	@NKT date,
	@htdt varchar(50),
	@tongtien float
as
begin
	insert into PHIEUQUANGCAO values (@NBD, @NKT, @htdt, @tongtien);
end

go

create or alter proc ThemYC 
	@pdt int,
	@mota nvarchar(1000)
as
begin
	insert into YEUCAUCV values(@pdt, @mota);
end

go
create or alter proc ThemHD
	@tongtien float,
	@datra float,
	@lhtt nvarchar(50),
	@ngaylap date,
	@ttht nvarchar(50),
	@iddn int
as
begin
	insert into HOADON values(@tongtien, @datra, @lhtt, @ngaylap, @ttht, @iddn);
end
go


--Phong
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
        values (@username, @password, @name, @email, 'UNGVIEN');    
    set @returnid = scope_identity();
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
        values (@username, @password, @name, @email, 'DOANHNGHIEP');
    set @returnid = scope_identity();
    insert into DOANHNGHIEP values (@returnid, @masothue, @nguoidaidien, @diachi, 0);
end;
go

create or alter procedure KetQuaTuyenDung
    @timkiem nvarchar(100)
as
begin
    if (@timkiem is NULL)
        select * from HOSOUNGTUYEN
    begin
        select HS.*, TVUngVien.Ten as N'Tên ứng viên', TVDoanhNghiep.Ten as N'Tên công ty', DN.IDDoanhNghiep
        from HOSOUNGTUYEN HS
        left join UNGVIEN UV on HS.IDUngVien = UV.IDUngVien
        left join THANHVIEN TVUngVien on UV.IDUngVien = TVUngVien.IDThanhVien
        left join DOANHNGHIEP DN on HS.IDDoanhNghiep = DN.IDDoanhNghiep
        left join THANHVIEN TVDoanhNghiep on DN.IDDoanhNghiep = TVDoanhNghiep.IDThanhVien
        WHERE (TVUngVien.Ten like '%' + @timkiem + '%' or TVDoanhNghiep.Ten like '%' + @timkiem + '%')
    end
end;
go