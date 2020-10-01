/****** Object:  StoredProcedure [dbo].[FetchTaxesDetails]    Script Date: 10/1/2020 6:14:36 PM ******/
DROP PROCEDURE [dbo].[FetchTaxesDetails]
GO
/****** Object:  Table [dbo].[MunicipalityTaxes]    Script Date: 10/1/2020 6:14:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MunicipalityTaxes]') AND type in (N'U'))
DROP TABLE [dbo].[MunicipalityTaxes]
GO
/****** Object:  Table [dbo].[MunicipalityTaxes]    Script Date: 10/1/2020 6:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MunicipalityTaxes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MunicipalityName] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[TaxAmount] [decimal](18, 1) NOT NULL,
	[Type] [varchar](50) NULL
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[FetchTaxesDetails]    Script Date: 10/1/2020 6:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FetchTaxesDetails]
(  
	 @Action_Type Varchar(2),
     @Munc_Name Varchar(50),
     @Date Date = null,
	 @Start_Date Date = null,
	 @End_Date Date = null,
	 @Tax_Amt Decimal(18,1) = null,
	 @Tax_Type Varchar(10) = null
)  
AS  
BEGIN  
IF(@Action_Type ='G')
	BEGIN
		IF ( select count(*) from MunicipalityTaxes where MunicipalityName = @Munc_Name and ((StartDate = @date or EndDate = @date)) and [Type]='Daily' )  > 0
			BEGIN  
				 select TaxAmount from MunicipalityTaxes where MunicipalityName='xyz' and ((StartDate = @date or EndDate = @date)) and [Type]='Daily';
			END  
		ELSE  IF ( select count(*) from MunicipalityTaxes where MunicipalityName = @Munc_Name and ((StartDate <= @date AND EndDate >= @date)) and [Type]='Monthly' )  > 0
			BEGIN  
				select TaxAmount from MunicipalityTaxes where MunicipalityName='xyz' and ((StartDate <= @date AND EndDate >= @date)) and [Type]='Monthly';
			END  
		ELSE  IF ( select count(*) from MunicipalityTaxes where MunicipalityName = @Munc_Name and ((StartDate <= @date AND EndDate >= @date)) and [Type]='Yearly' )  > 0
			BEGIN  
				select  TaxAmount from MunicipalityTaxes where MunicipalityName=@Munc_Name and ((StartDate <= @date AND EndDate >= @date)) and [Type]='Yearly';
			END 
	END
IF(@Action_Type ='I')
	BEGIN
		insert into MunicipalityTaxes(MunicipalityName,StartDate,EndDate,TaxAmount,[Type])
		values (@Munc_Name,@Start_Date,@End_Date,@Tax_Amt,@Tax_Type);

	END
end	
GO
