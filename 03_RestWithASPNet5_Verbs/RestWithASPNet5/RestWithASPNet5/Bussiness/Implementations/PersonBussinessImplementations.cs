using RestWithASPNet5.Model;
using RestWithASPNet5.Repository;
using System.Collections.Generic;

namespace RestWithASPNet5.Bussiness.Implementations
{
    public class PersonBussinessImplementations : IPersonBussiness
    {
        private readonly IPersonRepository _repository;

        public PersonBussinessImplementations(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
