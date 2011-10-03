using System;
namespace TenYears.Services
{
    public interface IServiceBase<T>
    {
        void Delete(string id);
        T Get(string id);
        System.Collections.Generic.IEnumerable<T> GetAll();
        T Save(T entity);
    }
}
