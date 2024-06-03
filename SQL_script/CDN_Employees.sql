CREATE TABLE [dbo].[CDN_Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[mail] [nvarchar](50) NULL,
	[phone_no] [nvarchar](50) NULL,
	[skill_set] [nvarchar](max) NULL,
	[hobby] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


INSERT INTO CDN_Employees (username, mail, phone_no,skill_set,hobby)
VALUES ('Danial', 'danial123@example.com', '01234556', 'expertise in business', 'swimming');
INSERT INTO CDN_Employees (username, mail, phone_no,skill_set,hobby)
VALUES ('Shila', 'shila123@example.com', '012368906', 'expertise in cooking', 'jogging');