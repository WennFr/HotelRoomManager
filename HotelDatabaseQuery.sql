SELECT *
FROM Booking b
INNER JOIN customer c ON b.CustomerId = c.Id
INNER JOIN room r ON b.RoomId = r.Id
INNER JOIN Salutation s ON c.SalutationId = s.Id


select *
from room

select *
from Customer c