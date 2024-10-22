-- q1 Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter. 
Select ProductID, Name, Color, ListPrice from Production.Product;
-- q2 Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0.
Select ProductID, Name, Color, ListPrice from Production.Product where ListPrice <> 0;
-- q3 Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column.
Select ProductID, Name, Color, ListPrice from Production.Product where Color is null;
-- q4 Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
Select ProductID, Name, Color, ListPrice from Production.Product where Color is not null;
-- q5 Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, and the column ListPrice has a value greater than zero.
Select ProductID, Name, Color, ListPrice from Production.Product where Color is not null and ListPrice > 0;
-- q6 Write a query that concatenates the columns Name and Color from the Production.Product table by excluding the rows that are null for color.
Select Name + ': ' + Color as "Name and Color" from Production.Product where Color is not null;
-- q7 Write a query that generates the following result set  from Production.Product:
-- NAME: LL Crankarm  --  COLOR: Black
-- NAME: ML Crankarm  --  COLOR: Black
-- NAME: HL Crankarm  --  COLOR: Black
-- NAME: Chainring Bolts  --  COLOR: Silver
-- NAME: Chainring Nut  --  COLOR: Silver
-- NAME: Chainring  --  COLOR: Black
Select 'NAME: ' + Name + ' -- ' + 'COLOR: ' + Color as "Name and Color" from Production.Product where Color in ('Black', 'Silver') and (Name like '%Crankarm' or Name like 'Chainring%') ORDER BY Name desc;
-- q8 Write a query to retrieve the to the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
Select ProductId, Name from Production.Product where ProductID BETWEEN 400 and 500;
-- q9 Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
Select ProductID, Name, Color from Production.Product where Color in ('Black', 'Blue');
-- q10 Write a query to get a result set on products that begins with the letter S. 
Select * from Production.Product where Name like 's%';
-- q11 Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. 
-- Name                                  ListPrice
-- Seat Lug                                0,00
-- Seat Post                               0,00
-- Seat Stays                              0,00
-- Seat Tube                               0,00
-- Short-Sleeve Classic Jersey, L          53,99
-- Short-Sleeve Classic Jersey, M          53,99
Select Name, ListPrice from Production.Product where (Name like 'seat%' or Name like 'Short%, [ML]') ORDER BY Name;
-- q12  Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. 
-- The products name should start with either 'A' or 'S'
-- Name                                        ListPrice
-- Adjustable Race                               0,00
-- All-Purpose Bike Stand                       159,00
-- AWC Logo Cap                                  8,99
-- Seat Lug                                      0,00
-- Seat Post                                     0,00
Select Name, ListPrice from Production.Product where Name like 'A%' or Name like 'S%' ORDER BY Name;
-- q13 Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. After this zero or more letters can exists. Order the result set by the Name column.
Select * from Production.Product where Name like 'SPO[^K]%' ORDER BY Name;
-- q14 Write a query that retrieves unique colors from the table Production.Product. Order the results  in descending  manner.
Select DISTINCT Color from Production.Product ORDER BY Color Desc;