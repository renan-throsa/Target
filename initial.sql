SELECT TOP (1000) [Id]
      ,[PurchasePrice]
      ,[SalePrice]
      ,[Description]
      ,[Code]
      ,[Quantity]
      ,[MinimumQuantity]
  FROM [TARGET].[dbo].[Products]

  -- Insert rows into table 'TableName' in schema '[dbo]'
  INSERT INTO [dbo].[Products]

  ( -- Columns to insert data into
   [PurchasePrice], [SalePrice], [Description],[Code],[Quantity],[MinimumQuantity]
  )
  VALUES
  ( 
   1.99, 2.50, 'ARROZ PARBOILIZADO TIPO 1 1KG CAMIL','7896006718543',20,5
  )
  GO