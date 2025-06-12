IF OBJECT_ID(N'User',N'U') IS NULL
BEGIN
	CREATE TABLE [User] (
		ID INT IDENTITY(1,1) PRIMARY KEY,
		UserName NVARCHAR(20) UNIQUE NOT NULL,
		Age INT NOT NULL,
		UserPassword NVARCHAR(30) NOT NULL,
		DateJoin DATETIME2 DEFAULT GETDATE()
	);
	ALTER TABLE [User]
	ADD 
		CONSTRAINT UserName_Check_Length CHECK (LEN(UserName) >= 5 AND LEN(UserName) <= 20),
		CONSTRAINT Age_Check_Length CHECK (Age >= 0 AND Age <= 120),
		CONSTRAINT Password_Check_Length CHECK (LEN(UserPassword) >= 8 AND LEN(UserPassword) <= 30);
END


IF OBJECT_ID(N'Profile',N'U') IS NULL
BEGIN
	CREATE TABLE [Profile] (
		ID INT PRIMARY KEY,
		FOREIGN KEY (ID) REFERENCES [dbo].[User](ID) ON DELETE CASCADE,
		QuizCount INT,
		PostCount INT,
		CardCount INT,
		CollectionCount INT
	);
END

