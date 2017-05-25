USE [WingtipSales]
GO

DROP VIEW [view_CustomerDimension]
DROP VIEW [view_ProductDimension]
DROP VIEW [view_PurchaseDimension]
DROP VIEW [view_ProductSalesFacts]
GO

CREATE VIEW [view_CustomerDimension]
AS
SELECT        
  Customers.Id, 
  SalesRegions.Region, 
  SalesRegions.StateFullName AS State, 
  Customers.City, 
  Customers.ZipCode AS [Zip Code], 
  Customers.Gender
FROM            
  Customers INNER JOIN SalesRegions ON Customers.State = SalesRegions.State

GO

CREATE VIEW [view_ProductDimension]
AS
SELECT        
  Id, 
  LEFT(ProductCategory, CHARINDEX(' >', ProductCategory) - 1) AS Category, 
  RIGHT(ProductCategory, LEN(ProductCategory) - CHARINDEX('>', ProductCategory)) AS Subcategory, 
  Title AS Product
FROM            
  Products

GO


CREATE VIEW [view_PurchaseDimension]
AS
SELECT        
  Id, InvoiceType AS [Purchase Type]
FROM            
  Invoices

GO

CREATE VIEW [view_ProductSalesFacts]
AS
SELECT        
  InvoiceDetails.Id, 
  InvoiceDetails.InvoiceId, 
  InvoiceDetails.ProductId, 
  Invoices.CustomerId, 
  InvoiceDate AS [Purchase Date], 
  InvoiceDetails.Quantity AS [Units Sold], 
  InvoiceDetails.Price AS [Sales Amount], 
  Products.UnitCost * InvoiceDetails.Quantity AS [Product Cost]
FROM            
  Invoices 
    INNER JOIN InvoiceDetails ON Invoices.Id = InvoiceDetails.InvoiceId 
    INNER JOIN Products ON InvoiceDetails.ProductId = Products.Id

GO

