create view getallbooks
as
select tblBook.BookId, tblCategory.Name as 'cat_name',
tblBook.Description, tblBook.Unit, tblBook.Image
from tblBook
inner join tblCategory on tblCategory.CatId = tblBook.CatId
