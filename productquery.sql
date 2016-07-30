

select c.*,p.* from Product p join Catalog c on p.Id = c.ProductId where RetailerId = 1 and (ImageId = 1 or WeightId = 2) and (ManufacturerId = 1 or ManufacturerId = 4)