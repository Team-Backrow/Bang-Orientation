/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [OrderId]
      ,[DuckettsId]
      ,[CustomerId]
  FROM [BangDatabase].[dbo].[Order]