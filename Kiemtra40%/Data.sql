CREATE DATABASE QuanLyQuanCaPhe
GO
 

USE QuanLyQuanCaPhe
GO



CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,	
	name NVARCHAR(100) NOT NULL,
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY not null,
	DisplayName NVARCHAR(100) not null,
	PassWord NVARCHAR(1000) not null ,
	Type INT not null DEFAULT 0 
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,	
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,	
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,	
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status int NOT NULL DEFAULT 0 

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,	
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO
--Tạo danh mục
INSERT dbo.FoodCategory
(name)
VALUES(N'Coffee')
INSERT dbo.FoodCategory
(name)
VALUES(N'Nước ép')
INSERT dbo.FoodCategory
(name)
VALUES(N'Trà')
INSERT dbo.FoodCategory
(name)
VALUES(N'Bánh')
INSERT dbo.FoodCategory
(name)
VALUES(N'Khác')
select * from FoodCategory
--tạo món ăn
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Cà phê đen',
		1,
		12000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Cà Phê Sữa',
		1,
		20000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Nước Cam',
		2,
		23000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Nước Ép Dưa Hấu',
		2,
		25000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Trà Đào',
		3,
		20000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Trà Tắc',
		3,
		18000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Bánh Dâu Tây',
		4,
		35000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Bánh Chanh Dây',
		4,
		40000
)
INSERT dbo.Food(name ,idCategory, price)
VALUES (N'Nước suối',
		5,
		5000
)
-- tạo tài khoản
INSERT INTO dbo.Account
		(UserName ,
		DisplayName,
		PassWord,
		Type	
		)
VALUES (N'Admin',
		N'Admin',
		N'123456',
		1			
		)
INSERT INTO dbo.Account
		(UserName ,
		DisplayName,
		PassWord,
		Type	
		)
VALUES (N'User',
		N'User',
		N'123456',
		0			
		)
-- tạo bill
INSERT dbo.Bill(DateCheckIn,DateCheckOut,idTable,status)

VALUES (GETDATE(),
		null,
		1,
		0
)
INSERT dbo.Bill(DateCheckIn,DateCheckOut,idTable,status)

VALUES (GETDATE(),
		null,
		2,
		0
)
INSERT dbo.Bill(DateCheckIn,DateCheckOut,idTable,status)

VALUES (GETDATE(),
		GETDATE(),
		3,
		1
)
--tạo bill info
INSERT dbo.BillInfo(idBill, idFood,count)
VALUES (1,2,3)
INSERT dbo.BillInfo(idBill, idFood,count)
VALUES (2,5,1)
INSERT dbo.BillInfo(idBill, idFood,count)
VALUES (1,2,1)
GO
SELECT * FROM dbo.Food
-- tạo bàn
DECLARE @i INT = 11

WHILE @i <=20
BEGIN
	INSERT dbo.TableFood(name) VALUES (N'Bàn' + CAST(@i AS nvarchar(100)))
	SET @i = @i +1
END
Go
--Proc gét danh sách các bàn được tạo
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO
UPDATE dbo.TableFood SET status = N'Có người' WHERE id = 13
EXEC dbo.USP_GetTableList
GO
--Get user
CREATE PROC USP_GetAccountUserName
@userName nvarchar(100)
as
begin
	SELECT *FROM dbo.Account Where UserName = @userName
END

EXEC dbo.USP_GetAccountUserName @userName = N'Admin'
GO
--Set tai khoản đăng nhập
CREATE PROCEDURE USP_Login 
@userName nvarchar(100), @passWord nvarchar(100)
as
begin
	select * from Account where UserName = @userName and PassWord = @passWord
end
go

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN

	INSERT dbo.Bill
	(DateCheckIn,
	DateCheckOut,
	idTable,
	status,
	discount)
VALUES (GETDATE(),
		null,
		@idTable,
		0,
		0
)
END

GO
-- tạo proc billinfo
CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	INSERT dbo.BillInfo(idBill, idFood,count)
VALUES (@idBill, @idFood, @count)
END
GO
-- sửa proc bill info
ALTER PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	
	DECLARE @ExitBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT @ExitBillInfo = id, @foodCount = COUNT FROM BillInfo WHERE idBill =@idBill AND idFood =@idFood
	IF(@ExitBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF(@newCount > 0)
			UPDATE BillInfo SET count = @foodCount + @count WHERE idFood =@idFood
		ElSE
			DELETE BillInfo WHERE idBill =@idBill AND idFood =@idFood
	END
	ELSE
	BEGIN
		INSERT dbo.BillInfo(idBill, idFood,count)
		VALUES (@idBill, @idFood, @count)
	END
	

END
GO


ALTER TRIGGER UTG_BillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT 
	SELECT @idBill = idBill FROM Inserted
	DECLARE @idTable INT 
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	DECLARE @count INT
	SELECT @count =COUNT(*) FROM dbo.BillInfo WHERE idBill =@idBill
	IF(@count > 0)
		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
	ELSE
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

DELETE BillInfo
DELETE Bill
GO

CREATE TRIGGER UTG_UpdateTable
ON dbo.TableFood for update
AS
BEGIN
	DECLARE @idTable INT
	DECLARE @status NVARCHAR(100)

	SELECT @idTable = id, @status = Inserted.status FROM Inserted

	DECLARE @idBill INT
	SELECT @idBill = id FROM dbo.Bill WHERE idTable =@idTable AND status = 0

	DECLARE @countBillInfo INT
	SELECT @countBillInfo = COUNT(*) FROM DBO.BillInfo WHERE idBill = @idBill

	IF(@countBillInfo > 0 AND @status <> N'Có người')
		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
	ELSE IF(@countBillInfo <= 0 AND @status <> N'Trống')
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END 
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE 
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = id FROM inserted
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	DECLARE @count INT = 0
	SELECT @count =COUNT(*) FROM dbo.Bill WHERE idTable =@idTable AND status = 0
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

ALTER TABLE dbo.Bill
ADD Discount INT 
GO

UPDATE dbo.Bill SET discount = 0
select * FROM Bill
GO

ALTER PROC USP_SwitchTable
@idTable1 INT, @idTable2 INT
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSecondBill INT

	DECLARE @isFirstTableEmty INT = 1
	DECLARE @isSecondTableEmty INT =1

	SELECT @idSecondBill  = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0	
	SELECT @idFirstBill  = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

	IF(@idFirstBill IS NULL)
	BEGIN
				INSERT dbo.Bill
				(DateCheckIn,
				DateCheckOut,
				idTable,
				status
				)
			VALUES (GETDATE(),
					null,
					@idTable1,
					0)
			SELECT @idFirstBill =MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
			SET @isFirstTableEmty = 1
	END 

	SELECT @isFirstTableEmty = count(*) FROM BillInfo WHERE idBill =@idFirstBill

	IF(@idSecondBill IS NULL)
	BEGIN
				INSERT dbo.Bill
				(DateCheckIn,
				DateCheckOut,
				idTable,
				status
				)
			VALUES (GETDATE(),
					null,
					@idTable2,
					0)
			SELECT @idSecondBill =MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
			
	END 
	SELECT @isSecondTableEmty = count(*) FROM BillInfo WHERE idBill = @idSecondBill

	SELECT id INTO idBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM idBillInfoTable)
	DROP TABLE idBillInfoTable
	IF (@isFirstTableEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
	IF (@isSecondTableEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END

EXEC USP_SwitchTable @idTable1 = 5, @idTable2 =6
SELECT *  FROM Bill
SELECT *  FROM BillInfo
UPDATE dbo.TableFood set status = N'Trống'
GO

ALTER TABLE Bill  ADD totalPrice DECIMAL(10,3)
go


ALTER PROC USP_GetListBillDate	
@CheckIn date, @CheckOut date
as
BEGIN
	SELECT t.name as [Số bàn],CAST(b.totalPrice AS DECIMAL(10,3)) as [Thành tiền], DateCheckIn as [Ngày vào], DateCheckOut as [Ngày ra], Discount as [Giảm giá]
	FROM dbo.Bill as b, dbo.TableFood as t 
	WHERE DateCheckIn >=@CheckIn and DateCheckOut <= @CheckIn AND b.status =1 AND t.id = b.idTable
END 
GO
SELECT f.name as [Tên món],fc.name , f.price as [Giá] FROM Food as f join FoodCategory as fc on f.idCategory = fc.id
GO

SELECT name, idCategory, price from Food



ALTER PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @passWord NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT (*) FROM dbo.Account WHERE UserName =@userName AND PassWord = @passWord
	IF(@isRightPass =1)
	BEGIN
		IF(@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE Account SET DisplayName =@displayName WHERE UserName =@userName
		END
		ELSE
			UPDATE Account SET DisplayName =@displayName, PassWord = @newPassword WHERE UserName =@userName
	END
		
END
GO
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo Int 
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill  = deleted.idBill FROM deleted
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM Bill WHERE id =@idBill
	DECLARE @count INT =0
	SELECT @count = COUNT(*) FROM BillInfo as bi, Bill as b WHERE b.id = bi.idBill and b.id =@idBill and b.status = 0
	IF(@count = 0)
		UPDATE TableFood SET status  = N'Trống' WHERE id =@idTable
END
GO

SELECT *FROM Food WHERE LOWER(name) COLLATE Latin1_General_CI_AI LIKE '%' + LOWER(N'nuoc') + '%';

SELECT *  FROM FoodCategory
Go
CREATE TRIGGER trg_SetDefaultPassword
ON Account
AFTER INSERT
AS
BEGIN
    UPDATE Account
    SET password = 0
    WHERE UserName IN (SELECT UserName FROM inserted)
END

ALTER TABLE Account
ADD CONSTRAINT password
DEFAULT 0 FOR password

INSERT dbo.FoodCategory (name) VALUES(N'')

SELECT * FROM TableFood

INSERT TableFood (name) VALUES (N'Bàn Test')


DELETE TableFood WHERE id = 1023