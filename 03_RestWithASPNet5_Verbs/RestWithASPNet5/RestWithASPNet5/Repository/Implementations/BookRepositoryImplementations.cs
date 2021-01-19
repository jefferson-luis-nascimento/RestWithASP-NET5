using RestWithASPNet5.Model;
using RestWithASPNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNet5.Repository.Implementations
{
    public class BookRepositoryImplementations : IBookRepository
    {
        private MySqlContext _context;

        public BookRepositoryImplementations(MySqlContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }
        public Book FindById(long id)
        {
            return GetBook(id);
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return book;
        }

        public Book Update(Book book)
        {
            var existsPerson = GetBook(book.Id);

            if (existsPerson == null) return null;

            try
            {
                _context.Entry(existsPerson).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return book;
        }

        public void Delete(long id)
        {
            var existsBook = GetBook(id);

            if (existsBook == null) return;

            try
            {
                _context.Remove(existsBook);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Book GetBook(long id)
        {
            return _context.Books.FirstOrDefault(book => book.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(book => book.Id.Equals(id));
        }
    }
}
