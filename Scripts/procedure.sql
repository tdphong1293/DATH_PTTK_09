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

create or alter proc checkNhanVien 
	@id varchar(30)
AS
BEGIN
	select nv.VaiTro from THANHVIEN tv, NHANVIEN nv where tv.IDThanhVien = nv.IDNhanVien and tv.IDThanhVien = @id;
END
go

create or alter proc ThemPDT 
	@vtdt varchar(50),
	@sltd int,
	@iddn int,
	@pqc int,
	@idpdt int output
as
begin
	SET NOCOUNT ON;
	insert into PHIEUDANGTUYEN values(@vtdt, @sltd, @iddn, @pqc);
	SET @idpdt = SCOPE_IDENTITY();
end
go

CREATE OR ALTER PROCEDURE ThemPQC
    @NBD DATE,
    @NKT DATE,
    @htdt NVARCHAR(50),
    @tongtien FLOAT,
    @IDPhieuQuangCao INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO PHIEUQUANGCAO (NgayBatDau, NgayKetThuc, HinhThucDangTuyen, TongTienQuangCao)
    VALUES (@NBD, @NKT, @htdt, @tongtien);
    SET @IDPhieuQuangCao = SCOPE_IDENTITY();
END
go

create or alter proc ThemYC 
	@pdt int,
	@mota nvarchar(1000)
as
begin
	insert into YEUCAUCV values(@pdt, @mota);
end

go
CREATE OR ALTER PROCEDURE ThemHD
    @tongtien FLOAT,
    @datra FLOAT,
    @lhtt NVARCHAR(50),
    @ngaylap DATE,
    @ttht NVARCHAR(50),
    @iddn INT
AS
BEGIN
    INSERT INTO HOADON (TongTien, DaTra, LoaiHinhThanhToan, NgayLap, TrangThaiHoanThanh, IDDoanhNghiep)
    VALUES (@tongtien, @datra, @lhtt, @ngaylap, @ttht, @iddn);
END
GO



--Phong
create or alter procedure ThemUV
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
    insert into UNGVIEN values (@returnid, @birth);
end;
go

create or alter procedure ThemDN
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

create or alter procedure LayKetQuaUngTuyen
    @timkiem nvarchar(100)
as
begin
    if (@timkiem is NULL)
	begin
        select * from HOSOUNGTUYEN
	end
	else
	begin
		select HS.IDUngVien, TVUngVien.Ten as N'Tên ứng viên',  HS.IDDoanhNghiep, TVDoanhNghiep.Ten as N'Tên công ty', HS.NgayUngTuyen, HS.ViTriUngTuyen, HS.DiemDanhGia
		from HOSOUNGTUYEN HS
		left join UNGVIEN UV on HS.IDUngVien = UV.IDUngVien
		left join THANHVIEN TVUngVien on UV.IDUngVien = TVUngVien.IDThanhVien
		left join DOANHNGHIEP DN on HS.IDDoanhNghiep = DN.IDDoanhNghiep
		left join THANHVIEN TVDoanhNghiep on DN.IDDoanhNghiep = TVDoanhNghiep.IDThanhVien
		WHERE TinhTrangUngTuyen = N'Đủ điều kiện' and (TVUngVien.Ten like '%' + @timkiem + '%' or TVDoanhNghiep.Ten like '%' + @timkiem + '%')
	end
end;
go