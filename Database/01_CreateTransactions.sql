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
GO

INSERT INTO dbo.Transactions
	(Amount, Description, CreatedAt, BalanceAfter)
VALUES
	(1000.00, 'Deposit', '2026-10-23T11:40:00', 1000.00);
GO



INSERT INTO dbo.Transactions
	(Amount, Description, CreatedAt, BalanceAfter)
VALUES
	(-200.00, 'Withdraw', '2026-10-23T11:44:00', 800.00);
GO
	
SELECT *
FROM dbo.Transactions;

