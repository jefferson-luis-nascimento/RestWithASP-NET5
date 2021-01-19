using RestWithASPNet5.Model;
using RestWithASPNet5.Repository;
using System.Collections.Generic;

namespace RestWithASPNet5.Bussiness.Implementations
{
    public class BookBussinessImplementations : IBookBussiness
    {
        private readonly IBookRepository _repository;

        public BookBussinessImplementations(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }
        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
