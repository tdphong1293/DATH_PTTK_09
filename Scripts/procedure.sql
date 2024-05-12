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
    @idpdt INT,
	@idhd INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO HOADON (TongTien, DaTra, LoaiHinhThanhToan, NgayLap, TrangThaiHoanThanh, IDPhieuDangTuyen)
    VALUES (@tongtien, @datra, @lhtt, @ngaylap, @ttht, @idpdt);
	SET @idhd = SCOPE_IDENTITY();
END
GO

create or alter procedure ThemTT
	@httt nvarchar(10),
	@sotien float,
	@dot int,
	@idhd int
as
begin
	INSERT INTO THANHTOAN(NgayGiaoDich, HinhThucTT, SoTienCanThanhToan, Dot, IDHoaDon, IDNhanVien)
	VALUES(null, @httt, @sotien, @dot, @idhd, null);
end
go

------------------------------------------------------------------------------------------------

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

------------------------------------------------------------------------------------------------

--Phuc
CREATE OR ALTER PROCEDURE XoaPhieuDangTuyen 
    @ID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM PHIEUDANGTUYEN WHERE IDPhieuDangTuyen = @ID)
    BEGIN
        DELETE FROM YEUCAUCV WHERE IDPhieuDangTuyen = @ID;
        DELETE FROM PHIEUDANGTUYEN WHERE IDPhieuDangTuyen = @ID;
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy PHIEUDANGTUYEN';
    END
END;
GO


CREATE OR ALTER PROCEDURE LayDanhSachPhieuDangTuyen
AS
BEGIN
  SELECT 
    P.*,
	T.Ten AS TenDoanhNghiep, 
	T.Email AS EmailDoanhNghiep, 
	D.DiaChi AS DiaChiDoanhNghiep
  FROM 
    PhieuDangTuyen P
  INNER JOIN 
    DOANHNGHIEP D ON P.IDDoanhNghiep = D.IDDoanhNghiep
  INNER JOIN 
    THANHVIEN T ON D.IDDoanhNghiep = T.IDThanhVien
  INNER JOIN 
    HOADON HD ON HD.IDPhieuDangTuyen = P.IDPhieuDangTuyen
WHERE
	HD.TrangThaiHoanThanh = N'Đã hoàn thành'
END;
GO

CREATE OR ALTER PROCEDURE LayDanhSachPhieuDangTuyenTheoDoanhNghiep
  @ID INT
AS
BEGIN
  SELECT 
    P.*,
	T.Ten AS TenDoanhNghiep, 
	T.Email AS EmailDoanhNghiep, 
	D.DiaChi AS DiaChiDoanhNghiep
  FROM 
    PhieuDangTuyen P
  INNER JOIN 
    DOANHNGHIEP D ON P.IDDoanhNghiep = D.IDDoanhNghiep
  INNER JOIN 
    THANHVIEN T ON D.IDDoanhNghiep = T.IDThanhVien
  WHERE 
    D.IDDoanhNghiep = @ID
END;
GO

CREATE OR ALTER PROCEDURE LayTTPhieuDangTuyen
    @ID INT
AS
BEGIN
    SELECT *
    FROM PHIEUDANGTUYEN
    WHERE IDPhieuDangTuyen = @ID;
END;
GO

CREATE OR ALTER PROCEDURE LayTTDoanhNghiep
    @ID INT
AS
BEGIN
    SELECT *
    FROM THANHVIEN AS TV
    INNER JOIN DOANHNGHIEP AS DN ON TV.IDThanhVien = DN.IDDoanhNghiep
    WHERE DN.IDDoanhNghiep = @ID;
END;
GO

CREATE OR ALTER PROCEDURE TimIDDoanhNghiepTuIDPDT
    @IDPDT INT,
    @IDDoanhNghiep INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @IDDoanhNghiep = -1;

    SELECT @IDDoanhNghiep = IDDoanhNghiep
    FROM PHIEUDANGTUYEN
    WHERE IDPhieuDangTuyen = @IDPDT;

    RETURN;
END;
GO

CREATE OR ALTER PROCEDURE LayTTUngVien
    @ID INT
AS
BEGIN
    SELECT *
    FROM THANHVIEN AS TV
    INNER JOIN UNGVIEN AS UV ON TV.IDThanhVien = UV.IDUngVien
    WHERE UV.IDUngVien = @ID;
END;
GO

CREATE OR ALTER PROCEDURE LayViTriDangTuyen
    @ID INT
AS
BEGIN
    SELECT ViTriDangTuyen
    FROM PHIEUDANGTUYEN
    WHERE IDPhieuDangTuyen = @ID;
END;
GO

CREATE OR ALTER PROCEDURE ThemHoSoUngTuyen
    @IDDoanhNghiep INT,
    @IDUngVien INT,
    @NgayUngTuyen DATE,
    @ViTriUngTuyen NVARCHAR(50)
AS
BEGIN
    INSERT INTO HOSOUNGTUYEN (IDDoanhNghiep, IDUngVien, NgayUngTuyen, ViTriUngTuyen)
    VALUES (@IDDoanhNghiep, @IDUngVien, @NgayUngTuyen, @ViTriUngTuyen);
END;
GO

CREATE OR ALTER PROCEDURE LayYeuCauCongViec
    @ID INT
AS
BEGIN
    SELECT yc.MoTa AS MoTaYeuCau
    FROM YEUCAUCV yc
    INNER JOIN PHIEUDANGTUYEN pdt ON yc.IDPhieuDangTuyen = pdt.IDPhieuDangTuyen
    WHERE pdt.IDPhieuDangTuyen = @ID;
END;
GO

CREATE OR ALTER PROCEDURE TimKiemPhieuDangTuyen
    @Ten NVARCHAR(50) = NULL,
    @ViTri NVARCHAR(50) = NULL,
    @ID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @ID IS NOT NULL
    BEGIN
        SELECT PDT.*
        FROM PHIEUDANGTUYEN PDT
        WHERE PDT.IDDoanhNghiep = @ID
        AND (@ViTri IS NULL OR PDT.ViTriDangTuyen LIKE '%' + @ViTri + '%');
    END
    ELSE
    BEGIN
        IF @Ten IS NOT NULL AND @ViTri IS NOT NULL
        BEGIN
            SELECT PDT.*
            FROM PHIEUDANGTUYEN PDT
            WHERE PDT.ViTriDangTuyen LIKE '%' + @ViTri + '%'
            AND EXISTS (
                SELECT 1
                FROM DOANHNGHIEP DN
                INNER JOIN THANHVIEN TV ON DN.IDDoanhNghiep = TV.IDThanhVien
                WHERE TV.Ten LIKE '%' + @Ten + '%'
                AND PDT.IDDoanhNghiep = DN.IDDoanhNghiep
            );
        END
        ELSE IF @Ten IS NOT NULL
        BEGIN
            SELECT PDT.*
            FROM PHIEUDANGTUYEN PDT
            WHERE EXISTS (
                SELECT 1
                FROM DOANHNGHIEP DN
                INNER JOIN THANHVIEN TV ON DN.IDDoanhNghiep = TV.IDThanhVien
                WHERE TV.Ten LIKE '%' + @Ten + '%'
                AND PDT.IDDoanhNghiep = DN.IDDoanhNghiep
            );
        END
        ELSE IF @ViTri IS NOT NULL
        BEGIN
            SELECT *
            FROM PHIEUDANGTUYEN
            WHERE ViTriDangTuyen LIKE '%' + @ViTri + '%';
        END
        ELSE
        BEGIN
            SELECT *
            FROM PHIEUDANGTUYEN;
        END
    END
END;
go

------------------------------------------------------------------------------------------------
-- Phu

create or alter procedure TimIDDoanhNghiep @TenDoanhNghiep VARCHAR(30), @IDDoanhNghiep int output
as
begin
	select @IDDoanhNghiep = dn.IDDoanhNghiep
	from DOANHNGHIEP dn, THANHVIEN tv
	where tv.Ten = @TenDoanhNghiep and dn.IDDoanhNghiep = tv.IDThanhVien
end;
go

create or alter procedure LayDSIDPDT @IDDoanhNghiep int
as
begin
	select pdt.IDPhieuDangTuyen
	from PHIEUDANGTUYEN pdt
	where pdt.IDDoanhNghiep = @IDDoanhNghiep
end;
go

create or alter procedure LayEmailNgSinh_UV @IDUngVien int
as
begin
	select tv.Email, uv.NgaySinh
	from THANHVIEN tv, UNGVIEN uv 
	where tv.IDThanhVien = @IDUngVien and tv.IDThanhVien = uv.IDUngVien
end;
go


create or alter procedure LayTTBangCap_UV @id_uv int
as
begin
	select bc.TenBang as N'Tên bằng', bc.CapBac as N'Cấp bậc', bc.NgayCap as N'Ngày cấp', bc.DonViCap as N'Đơn vị cấp'
	from BANGCAP bc
	where bc.IDUngVien = @id_uv
end;
go

create or alter procedure LayDSHSUTChoDuyet @tendn nvarchar(50)
as
begin
	if @tendn = ''
	begin
		select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen, hsut.DiemDanhGia, hsut.IDUngVien, hsut.IDDoanhNghiep
		from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn
		where hsut.IDDoanhNghiep = tv_dn.IDThanhVien and
			hsut.IDUngVien = tv_uv.IDThanhVien and
			(hsut.TinhTrangUngTuyen = N'Chưa đủ điều kiện' or hsut.TinhTrangUngTuyen is Null)
	end
	else
	begin
		select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen, hsut.DiemDanhGia, hsut.IDUngVien, hsut.IDDoanhNghiep
		from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn
		where hsut.IDDoanhNghiep = tv_dn.IDThanhVien and
			hsut.IDUngVien = tv_uv.IDThanhVien and
			(hsut.TinhTrangUngTuyen = N'Chưa đủ điều kiện' or hsut.TinhTrangUngTuyen is Null) and
			UPPER(tv_dn.Ten) LIKE UPPER('%' + @tendn + '%')
	end
end;
go

create or alter procedure LayDSHSUTDaDuyet @tendn nvarchar(50)
as
begin
	if @tendn = ''
	begin
		select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen, hsut.DiemDanhGia, hsut.IDUngVien, hsut.IDDoanhNghiep
		from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn
		where hsut.IDDoanhNghiep = tv_dn.IDThanhVien and
			hsut.IDUngVien = tv_uv.IDThanhVien and
			(hsut.TinhTrangUngTuyen = N'Đủ điều kiện' or hsut.TinhTrangUngTuyen = N'Đang xử lý')
	end
	else
	begin
		select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen, hsut.DiemDanhGia, hsut.IDUngVien, hsut.IDDoanhNghiep
		from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn
		where hsut.IDDoanhNghiep = tv_dn.IDThanhVien and
			hsut.IDUngVien = tv_uv.IDThanhVien and
			(hsut.TinhTrangUngTuyen = N'Đủ điều kiện' or hsut.TinhTrangUngTuyen = N'Đang xử lý') and
			UPPER(tv_dn.Ten) LIKE UPPER('%' + @tendn + '%')
	end
end;
go

create or alter procedure ThemBangCap @tenbang NVARCHAR(100), @capbac VARCHAR(50), @ngaycap DATE, @dvcap NVARCHAR(100), @idungvien int, @idbangcap int output
as
begin
	SET NOCOUNT ON;
    INSERT INTO BANGCAP(TenBang, CapBac, NgayCap, DonViCap, IDUngVien)
    VALUES (@tenbang, @capbac, @ngaycap, @dvcap, @idungvien);
	SET @idbangcap = SCOPE_IDENTITY();
end
go

create or alter procedure DuyetHSUTChoDuyet @IDUngVien int, @IDDoanhNghiep int, @diem int, @kq varchar(10)
as
begin
	if @kq = 'succeed'
	begin
		update HOSOUNGTUYEN 
		set TinhTrangUngTuyen = N'Đang xử lý', DiemDanhGia = @diem 
		where IDDoanhNghiep = @IDDoanhNghiep and IDUngVien = @IDUngVien		
	end
	else
	begin
		update HOSOUNGTUYEN 
		set TinhTrangUngTuyen = N'Chưa đủ điều kiện', DiemDanhGia = @diem 
		where IDDoanhNghiep = @IDDoanhNghiep and IDUngVien = @IDUngVien		
	end
end;
go


create or alter procedure DocTTPhieuDangTuyen @IDPhieuDangTuyen int
as
begin
	select *
	from PHIEUDANGTUYEN
	where IDPhieuDangTuyen = @IDPhieuDangTuyen
end;
go

create or alter procedure DocTTPhieuQuangCao @IDPhieuQC int
as
begin
	select * 
	from PHIEUQUANGCAO
	where IDPhieuQuangCao = @IDPhieuQC
end
go

create or alter procedure DocTTHoaDon @IDPhieuDT int
as
begin
	select * 
	from HOADON
	where IDPhieuDangTuyen = @IDPhieuDT
end;
go

create or alter procedure LayDSDotThanhToan @IDHoaDon int
as
begin
	select *
	from THANHTOAN 
	where IDHoaDon = @IDHoaDon
end;
go


create or alter procedure DocTTThanhToan @IDHoaDon int, @dot int
as
begin
	select * 
	from THANHTOAN
	where IDHoaDon = @IDHoaDon and Dot = @dot
end;
go

create or alter procedure KTThanhToan @IDHoaDon int, @dot int, @kq int output
as
begin
	declare @sodot int
	declare @ngaygiaodich date
	declare @ngaygiaodichtruoc date

	select @sodot = COUNT(*) from THANHTOAN where IDHoaDon = @IDHoaDon
	select @ngaygiaodich = NgayGiaoDich from THANHTOAN where IDHoaDon = @IDHoaDon and Dot = @dot

	if @sodot = 1
	begin
		if @ngaygiaodich is null
			set @kq = 1
		else
			set @kq = 0
	end
	else
	begin
		if @dot = 1
		begin
			if @ngaygiaodich is null
				set @kq = 1
			else
				set @kq = 0
		end
		else
		begin
			if @ngaygiaodich is null
			begin
				select @ngaygiaodichtruoc = NgayGiaoDich from THANHTOAN where IDHoaDon = @IDHoaDon and Dot = @dot - 1
				if @ngaygiaodichtruoc is null
					set @kq = 0
				else
					set @kq = 1
			end
			else
				set @kq = 0
		end
	end
end;
go

create or alter procedure ThucHienThanhToan @IDHoaDon int, @dot int
as
begin
	declare @sotientra float
	select @sotientra = SoTienCanThanhToan from THANHTOAN where IDHoaDon = @IDHoaDon and Dot = @dot
	update THANHTOAN set NgayGiaoDich = CONVERT(DATE, GETDATE()) where IDHoaDon = @IDHoaDon and Dot = @dot
	update HOADON set DaTra = DaTra + @sotientra where IDHoaDon = @IDHoaDon

	declare @tongtien float
	declare @tiendatra float
	select @tongtien = TongTien, @tiendatra = DaTra
	from HOADON
	where IDHoaDon = @IDHoaDon
	if @tongtien = @tiendatra
		update HOADON set TrangThaiHoanThanh = N'Đã hoàn thành' where IDHoaDon = @IDHoaDon

end;
go