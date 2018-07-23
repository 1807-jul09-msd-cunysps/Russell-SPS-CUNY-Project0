/*CREATE TABLE Product(
ID int, 
ProductName varchar(255),
Price int,
PRIMARY KEY (ID));

CREATE TABLE Customers(
ID int,
FirstName varchar(255),
LastName varchar(255),
CardNumber int,
PRIMARY KEY (ID));

CREATE TABLE Orders(
ID int,
ProductID int,
CustomerID int,
FOREIGN KEY (ID) REFERENCES Product(ID),
FOREIGN KEY (CustomerID) REFERENCES Customers(ID));*/


/*
INSERT INTO Product(ID,ProductName,Price)VALUES (1,'banana',2);
INSERT INTO Product(ID,ProductName,Price)VALUES (2,'kiwi',3);
INSERT INTO Product(ID,ProductName,Price)VALUES (3,'grape',5);
INSERT INTO Product(ID,ProductName,Price)VALUES (4,'Iphone',200);
INSERT INTO Customers(ID,FirstName,LastName,CardNumber)VALUES (1,'Tina','Smith',2505);
INSERT INTO Customers(ID,FirstName,LastName,CardNumber)VALUES (2,'Russell','Chin',2605);
INSERT INTO Customers(ID,FirstName,LastName,CardNumber)VALUES (3,'Sally','King',2705);
INSERT INTO Orders(ID,ProductID,CustomerID) VALUES(1,4,1);
INSERT INTO Orders(ID,ProductID,CustomerID) VALUES(2,2,3);
INSERT INTO Orders(ID,ProductID,CustomerID) VALUES(3,1,3);
INSERT INTO Orders(ID,ProductID,CustomerID) VALUES(4,4,1);*/


SELECT Customers.FirstName,Customers.LastName, Orders.ProductID FROM Customers INNER JOIN Orders on 
Orders.CustomerID = Customers.ID
WHERE Customers.FirstName = 'Tina';


SELECT SUM(Price) FROM Product INNER JOIN Orders ON Orders.ProductID = Product.ID 
WHERE ProductName = 'Iphone';




