using RestWithASPNet5.Model;
using System.Collections.Generic;

namespace RestWithASPNet5.Bussiness
{
    public interface IBookBussiness
    {
        Book Create(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book pook);

        void Delete(long Id);
    }
}
