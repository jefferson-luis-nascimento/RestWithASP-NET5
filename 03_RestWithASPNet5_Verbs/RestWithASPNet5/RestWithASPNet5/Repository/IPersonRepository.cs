﻿using RestWithASPNet5.Model;
using System.Collections.Generic;

namespace RestWithASPNet5.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);

        Person FindById(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long Id);

        bool Exists(long id);
    }
}
