using RestWithASPNet5.Model;
using RestWithASPNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNet5.Repository.Implementations
{
    public class PersonRepositoryImplementations : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepositoryImplementations(MySqlContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return GetPerson(id);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public Person Update(Person person)
        {
            var existsPerson = GetPerson(person.Id);

            if (existsPerson == null) return new Person();

            try
            {
                _context.Entry(existsPerson).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public void Delete(long id)
        {
            var existsPerson = GetPerson(id);

            if (existsPerson == null) return;

            try
            {
                _context.Remove(existsPerson);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Person GetPerson(long id)
        {
            return _context.Persons.FirstOrDefault(person => person.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(person => person.Id.Equals(id));
        }
    }
}
