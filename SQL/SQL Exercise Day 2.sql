Use AdventureWorks2019;
-- 1.      How many products can you find in the Production.Product table?
Select count(ProductId) as "Number of Products" from Production.Product;
-- 2.      Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
-- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
Select count(ProductId) as "Number of Products that are Included in a Subcategory" from Production.Product where ProductSubcategoryID is not null;
-- 3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts
Select ProductSubcategoryID, count(ProductID) as CountedProducts from Production.Product  GROUP BY ProductSubcategoryID;
-- 4.      How many products that do not have a product subcategory.
Select count(ProductId) as "Number of Products that do not have a Product Subcategory" from Production.Product where ProductSubcategoryID is null;
-- 5.      Write a query to list the sum of products quantity of each product in the Production.ProductInventory table.
Select ProductID, sum(Quantity) as Sum from Production.ProductInventory group by ProductID;
-- 6.    Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 
-- and limit the result to include just summarized quantities less than 100.
            --   ProductID    TheSum
Select ProductID, sum(Quantity) as TheSum
from Production.ProductInventory
where locationId = 40
GROUP BY ProductID
Having sum(Quantity) < 100;
-- 7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 
-- and limit the result to include just summarized quantities less than 100
    -- Shelf      ProductID    TheSum
SELECT Shelf, ProductID, sum(Quantity) as TheSum
FROM Production.ProductInventory
where locationId = 40 and Shelf != 'N/A'
GROUP BY ProductID, Shelf
Having sum(Quantity) < 100;
-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
Select AVG(Quantity) as AvgQuantity
FROM Production.ProductInventory
Where LocationID = 10;
-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
    -- ProductID   Shelf      TheAvg
Select ProductID, Shelf, AVG(quantity) as TheAvg
FROM Production.ProductInventory
Group by ProductID, Shelf;
-- 10.  Write query  to see the average quantity  of  products by shelf 
-- excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
    -- ProductID   Shelf      TheAvg
Select ProductID, Shelf, AVG(Quantity) as TheAvg
From Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf;
-- 11.  List the members (rows) and average list price in the Production.Product table. 
-- This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
    -- Color                        Class              TheCount          AvgPrice
SELECT Color, Class, count(Color) as TheCount, AVG(ListPrice) as AvgPrice
From Production.Product
WHERE Color is not null and Class is not null
GROUP BY Color, Class;
-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. 
-- Join them and produce a result set similar to the following.
    -- Country                        Province
Select cr.name as Country, sp.name as Province
From Person.CountryRegion cr JOIN Person.StateProvince sp on cr.countryRegionCode = sp.countryRegionCode
ORDER BY cr.name;
-- 13.  Write a query that lists the country and province names from person. CountryRegion and person. 
-- StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
--     Country                        Province
Select cr.name as Country, sp.name as Province
From Person.CountryRegion cr JOIN Person.StateProvince sp on cr.countryRegionCode = sp.countryRegionCode
WHERE cr.Name in ('Germany', 'Canada')
ORDER BY cr.name;

-- Northwind database for the following questions
Use Northwind;
-- 14.  List all Products that has been sold at least once in last 27 years.
Select distinct p.ProductID, p.ProductName FROM 
Products p JOIN [Order Details] od on p.ProductID = od.ProductID
Join Orders o on od.OrderID = o.OrderID
Where o.OrderDate >= DATEADD(YEAR, -27, GETDATE());
-- 15.  List top 5 locations (Zip Code) where the products sold most.
Select TOP 5 ShipPostalCode, SUM(od.Quantity) as TotalProductsSold
from Orders o JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY ShipPostalCode
ORDER BY TotalProductsSold DESC;
-- 16.  List top 5 locations (Zip Code) where the products sold most in last 27 years.
Select TOP 5 ShipPostalCode, SUM(od.Quantity) as TotalProductsSold
from Orders o JOIN [Order Details] od on o.OrderID = od.OrderID
Where o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY ShipPostalCode
ORDER BY TotalProductsSold DESC;
-- 17.   List all city names and number of customers in that city. 
Select City, count(City) as NumberOfCustomers
FROM Customers
GROUP BY City
ORDER BY NumberOfCustomers, City;
-- 18.  List city names which have more than 2 customers, and number of customers in that city
Select City, count(City) as NumberOfCustomers
FROM Orders o JOIN CUSTOMERS c ON o.CustomerID = c.CustomerID
GROUP BY City
HAVING count(City) > 2;
-- 19.  List the names of customers who placed orders after 1/1/98 with order date.
Select distinct ContactName
FROM Customers c JOIN ORDERS o on c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998/01/01';
-- 20.  List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
ORDER BY c.ContactName;
-- 21.  Display the names of all customers  along with the  count of products they bought
Select c.ContactName, sum(od.Quantity) as NumberOfProductsBought
From Customers c JOIN Orders o on c.CustomerID = o.CustomerID
JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.ContactName
ORDER BY c.ContactName;
-- 22.  Display the customer ids who bought more than 100 Products with count of products.
Select c.CustomerID, sum(od.Quantity) as NumberOfProductsBought
From Customers c JOIN Orders o on c.CustomerID = o.CustomerID
JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.CustomerID
Having sum(od.Quantity) > 100
;
-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below
    -- Supplier Company Name                Shipping Company Name
Select distinct sup.CompanyName as "Supplier Company Name", s.CompanyName as "Shipping Company Name" from 
Suppliers sup JOIN Products p on sup.SupplierID = p.ProductID
JOIN [Order Details] od on p.ProductID = od.ProductID
JOIN ORDERS o on od.OrderID = o.OrderID
JOIN Shippers s on s.ShipperID = o.ShipVia;
-- 24.  Display the products order each day. Show Order date and Product Name.
Select distinct o.OrderDate, p.ProductName
FROM Orders o join [Order Details] od on o.OrderID = od.OrderID
JOIN Products p on od.ProductID = od.ProductID
ORDER BY o.OrderDate;
-- 25.  Displays pairs of employees who have the same job title.
Select e1.EmployeeID as Employee1ID, e2.EmployeeID as Employee2ID
from Employees e1 join Employees e2 on e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID;
-- 26.  Display all the Managers who have more than 2 employees reporting to them.
-- to do
Select e1.EmployeeId
from Employees e1 right join Employees e2 on e1.EmployeeID = e2.reportsTo
GROUP BY e1.EmployeeID
HAVING count(e1.EmployeeID) >2;
Select * from employees;
-- 27.  Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)
Select City, CompanyName, ContactName, 'Customer' Type from Customers
UNION
Select City, CompanyName, ContactName, 'Supplier' Type from Suppliers
ORDER BY City;