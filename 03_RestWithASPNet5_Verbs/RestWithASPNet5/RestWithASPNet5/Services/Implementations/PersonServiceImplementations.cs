using RestWithASPNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNet5.Services.Implementations
{
    public class PersonServiceImplementations : IPersonService
    {
        private int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {

        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                persons.Add(new Person
                {
                    Id = IncrementAndGet(),
                    FirstName = "Person FistName" + i,
                    LastName = "Person LastName" + i,
                    Address = "Some Adress" + i,
                    Gender = "Male",
                });
            }

            return persons;
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia - MG - Brasil",
                Gender = "Male",
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
