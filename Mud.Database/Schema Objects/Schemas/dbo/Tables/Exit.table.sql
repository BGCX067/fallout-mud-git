CREATE TABLE [dbo].[Exit]
(
	Id int not null identity(1,1),
	Direction tinyint not null,
	LocationId int not null,
	DestLocationId int not null
)
