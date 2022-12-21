SELECT *
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id


SELECT s.SalutationType,c.LastName,b.StartDate,b.EndDate,r.Id AS RoomName,r.Type,r.ExtraBed AS [Allowed amount of extra beds]
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id



select *
from Rooms

select *
from Customers c

select *
from Bookings b