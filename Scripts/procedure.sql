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
    SELECT *
    FROM PHIEUDANGTUYEN;
END;
GO

CREATE OR ALTER PROCEDURE LayDanhSachPhieuDangTuyenTheoDoanhNghiep
    @ID INT
AS
BEGIN
    SELECT *
    FROM PHIEUDANGTUYEN
    WHERE IDDoanhNghiep = @ID;
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
    DECLARE @DanhSachViTri NVARCHAR(MAX);
    SELECT @DanhSachViTri = COALESCE(@DanhSachViTri + ', ', '') + ViTriDangTuyen
    FROM PHIEUDANGTUYEN
    WHERE IDPhieuDangTuyen = @ID;

    SELECT @DanhSachViTri AS DanhSachViTriDangTuyen;
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

------------------------------------------------------------------------------------------------