SELECT *
FROM Bookings b
INNER JOIN Customers c ON b.CustomerId = c.Id
INNER JOIN Rooms r ON b.RoomId = r.Id
INNER JOIN Salutations s ON c.SalutationId = s.Id


select *
from Rooms

select *
from Customers c