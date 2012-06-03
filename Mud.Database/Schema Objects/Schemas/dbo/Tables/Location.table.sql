CREATE TABLE [dbo].[Location]
(
	Id int not null identity(1,1),
	RegionId int not null,
	Title varchar(50) not null,
	[Desc] varchar(max) null
)