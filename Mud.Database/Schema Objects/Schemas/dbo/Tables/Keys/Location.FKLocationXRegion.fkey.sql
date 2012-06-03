ALTER TABLE [dbo].[Location]
	ADD CONSTRAINT [FKLocationXRegion] 
	FOREIGN KEY (RegionId)
	REFERENCES Region (Id)	

