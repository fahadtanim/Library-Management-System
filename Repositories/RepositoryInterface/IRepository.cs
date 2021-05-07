using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Repositories.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        List<T> Get();
        T Get(string id);
        T Create(T t);
        bool Update(string id, T t);
        bool Remove(T t);
        bool Remove(string id);
    }
}
