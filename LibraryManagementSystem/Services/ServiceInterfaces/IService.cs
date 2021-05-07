using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.ServiceInterfaces
{
    public interface IService<T,InsertDTO,UpdateDTO>
    {
        public T Insert(InsertDTO t);
        public T Get(string id);
        public T Update(string id, UpdateDTO t);
        public T Delete(string id);
    }
}
