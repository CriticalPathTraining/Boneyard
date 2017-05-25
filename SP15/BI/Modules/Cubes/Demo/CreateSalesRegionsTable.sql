USE [WingtipSales]
GO

DROP TABLE [dbo].[SalesRegions]
GO

CREATE TABLE [dbo].[SalesRegions](
	[State] [varchar](50) NOT NULL,
	[StateFullName] [varchar](50) NULL,
	[Region] [varchar](50) NULL,
 CONSTRAINT [PK_SalesRegions] PRIMARY KEY CLUSTERED ([State] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
 ON [PRIMARY]) ON [PRIMARY]

GO


INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('AL','Alabama','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('AK','Alaska','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('AZ','Arizona','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('AR','Arkansas','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('CA','California','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('CO','Colorado','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('CT','Connecticut','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('DE','Delaware','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('FL','Florida','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('GA','Georgia','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('HI','Hawaii','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('ID','Idaho','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('IL','Illinois','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('IN','Indiana','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('IA','Iowa','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('KS','Kansas','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('KY','Kentucky','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('LA','Louisiana','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('ME','Maine','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MD','Maryland','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MA','Massachusetts','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MI','Michigan','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MN','Minnesota','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MS','Mississippi','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MO','Missouri','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('MT','Montana','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NE','Nebraska','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NV','Nevada','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NH','New Hampshire','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NJ','New jersey','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NM','New Mexico','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NY','New York','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('NC','North Carolina','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('ND','North Dakota','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('OH','Ohio','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('OK','Oklahoma','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('OR','Oregon','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('PA','Pennsylvania','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('RI','Rhode island','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('SC','South Carolina','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('SD','South Dakota','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('TN','Tennessee','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('TX','Texas','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('UT','Utah','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('VT','Vermont','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('VA','Virginia','Eastern Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('WA','Washington','Western Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('WV','West Virginia','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('WI','Wisconsin','Central Region')
INSERT INTO SalesRegions ([State],[StateFullName],[Region])VALUES('WY','Wyoming','Central Region')

GO

