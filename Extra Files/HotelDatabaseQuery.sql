
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


