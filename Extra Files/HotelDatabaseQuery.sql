
SELECT *
FROM Salutations

SELECT *
FROM Rooms

SELECT *
FROM Customers 

SELECT *
FROM Bookings 

--Display all customers where last name contains an S
SELECT *
FROM Customers c
WHERE c.LastName Like '%S%'

--Count total amount of bookings 
SELECT COUNT(b.Id) AS TotalAmountOfBookings
FROM Bookings b

--Joining all tables & columns
SELECT *
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id

--Display all current bookings with room & customer ordered by starting date
SELECT s.SalutationType,c.LastName,b.Id AS BookingId,b.StartDate,b.EndDate,r.Id AS RoomId,r.Type,r.ExtraBed AS [Allowed extra beds]
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id
ORDER BY b.StartDate 

--Display customer,room & booking where starting date is later than 2023/02/01. Ordered by Last Name.
SELECT 
s.SalutationType,
c.FirstName,c.LastName,
b.Id AS BookingId,b.StartDate,b.EndDate,
r.Id AS RoomId,r.Floor,r.Type,r.Size,r.ExtraBed
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
WHERE b.StartDate > '2023/02/01'
ORDER BY c.LastName

--Count total amount of bookings each customer with a booking has.
SELECT COUNT(b.Id) AS AmountOfBookings,c.FirstName,c.LastName
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
GROUP BY c.FirstName,c.LastName

--Counts the total amount of different registered room types.
SELECT COUNT(r.type) AS [Amount of registered room types],r.Type
FROM Rooms r
GROUP BY r.Type

--SELECTS all customers that have a booking using a subquery.
SELECT *
FROM Customers c
WHERE c.Id  in (SELECT b.CustomerId  FROM Bookings b)


--=====CREATE DATABASE WITH SQL======================================================

CREATE DATABASE FredericksHotelDatabase

CREATE TABLE Salutations(

Id int NOT NULL PRIMARY KEY,
[SalutationType]  nvarchar(5) NOT NULL,
);

CREATE TABLE Customers(

Id int NOT NULL PRIMARY KEY,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Adress] int,
[Phone] int NOT NULL,
[SalutationId] int FOREIGN KEY REFERENCES Salutations(Id)
);

CREATE TABLE Bookings(

Id int NOT NULL PRIMARY KEY,
[StartDate] datetime NOT NULL,
[EndDate] datetime NOT NULL,
[CustomerId] int NOT NULL FOREIGN KEY REFERENCES Customers(Id),
[RoomId] int NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
);

CREATE TABLE Rooms(

Id int NOT NULL PRIMARY KEY,
[Floor] int NOT NULL,
[Type] nvarchar(50) NOT NULL,
[Size] int NOT NULL,
[ExtraBed] int
);

