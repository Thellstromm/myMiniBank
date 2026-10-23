CREATE DATABASE MyMiniBank;
GO

USE MyMiniBank;
GO

CREATE TABLE dbo.Transactions (
	TransactionId INT IDENTITY(1,1) PRIMARY KEY,
	Amount DECIMAL(18,2) NOT NULL,
	Description nvarchar(50) NOT NULL,
	CreatedAt DATETIME2 NOT NULL,
	BalanceAfter DECIMAL(18,2) NOT NULL
	);