ALTER TABLE [dbo].[Exit]
	ADD CONSTRAINT [FKExitXLocation] 
	FOREIGN KEY (LocationId)
	REFERENCES Location (Id)	

