using RestWithASPNet5.Model;
using System.Collections.Generic;

namespace RestWithASPNet5.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long Id);

        bool Exists(long id);
    }
}
