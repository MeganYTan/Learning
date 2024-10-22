-- 1.      List all cities that have both Employees and Customers.
Select distinct e.CITY from Employees e join Customers c on e.City = c.City;
-- 2.      List all cities that have Customers but no Employee.
-- a.      Use sub-query
Select distinct CITY from CUSTOMERS where CITY not in (Select distinct CITY from employees);
-- b.      Do not use sub-query
Select distinct c.CITY 
from Customers c 
left join Employees e on e.City = c.City
where e.city is null;
-- 3.      List all products and their total order quantities throughout all orders.
Select p.ProductID, ProductName, sum(Quantity) as TotalOrderQuantity
FROM Products p LEFT JOIN [Order Details] od on p.ProductID = od.ProductID
LEFT JOIN Orders o on od.OrderID = o.OrderID
GROUP BY p.ProductID, ProductName
Order by p.ProductID;
-- 4.      List all Customer Cities and total products ordered by that city.
Select c.City, sum(Quantity) as TotalOrderQuantity
FROM Customers c LEFT JOIN Orders o on c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.city
ORDER BY TotalOrderQuantity DESC
;
-- 5.      List all Customer Cities that have at least two customers.
Select CITY
FROM CUSTOMERS
GROUP BY City 
HAVING count(CITY) > 2;
-- 6.      List all Customer Cities that have ordered at least two different kinds of products.
Select c.CITY, count(distinct od.ProductID)
FROM CUSTOMERS c JOIN ORDERS o on c.CustomerID = o.CustomerID
JOIN [Order Details] od on od.OrderID = o.OrderID
GROUP BY c.City
HAVING count(distinct od.ProductID) > 2;
-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
Select distinct c.CustomerID, c.ContactName
FROM Customers c JOIN Orders o on c.CustomerID = o.CustomerID
Where c.City != o.ShipCity;
-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
-- assume most popular product is the one that sold the most in quantity
With TopProducts as (
SELECT TOP 5 ProductID, sum(Quantity) as TotalQuantity, AVG(UnitPrice - Discount) as AvgPrice
FROM [Order Details] od JOIN Orders o on od.OrderID = o.OrderID
JOIN Customers c on c.CustomerID = o.CustomerID
GROUP BY ProductID
ORDER BY TotalQuantity desc
),
ProductIdRankedByCity as (
Select City, ProductId, Rank() OVER(Partition BY ProductId order by SUM(Quantity) desc) RNK
FROM Customers c JOIN ORDERS o on c.customerId = o.customerId
JOIN [Order Details] od on o.orderId = od.orderId
GROUP  BY productId, City
)
Select tp.ProductId, AvgPrice, City
from TopProducts tp JOIN ProductIdRankedByCity prnk on tp.ProductId = prnk.ProductID
Where RNK = 1
ORDER BY TotalQuantity Desc
;
-- 9.      List all cities that have never ordered something but we have employees there.
-- a.      Use sub-query
Select distinct CITY 
FROM Employees
WHERE CITY NOT IN (SELECT ShipCity from ORDERS);
-- b.      Do not use sub-query
Select distinct e.City
FROM Employees e LEFT JOIN Orders o on e.City = o.ShipCity
WHERE o.ShipCity is null;
-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
-- and also the city of most total quantity of products ordered from. (tip: join  sub-query)
Select t1.ShipCity from 
(
Select TOP 1 EmployeeID, count(EmployeeID) as OrdersSoldByEmployee, ShipCity
FROM ORDERS
GROUP BY EmployeeID, ShipCity
ORDER BY OrdersSoldByEmployee desc
) AS t1 JOIN 
(
Select TOP 1 o.ShipCity, count(quantity) as QuantityOfProductsSoldInCity
FROM [Order Details] od join Orders o on od.orderId = o.orderId
GROUP BY o.ShipCity
ORDER BY QuantityOfProductsSoldInCity desc
) AS t2
ON t1.ShipCity = t2.ShipCity
;
-- 11. How do you remove the duplicates record of a table?
-- Method 1: Select distinct rows into a temporary table, and replace the table with the temporary table
-- Method 2: Select repeated rows from the table. Using this select as a subquery, delete all but one row for every row that is in this subquery