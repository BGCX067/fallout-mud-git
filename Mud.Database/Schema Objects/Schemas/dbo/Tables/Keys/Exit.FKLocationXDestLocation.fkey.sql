ALTER TABLE [dbo].[Exit]
	ADD CONSTRAINT [FKLocationXDestLocation] 
	FOREIGN KEY (DestLocationId)
	REFERENCES Location (Id)	

