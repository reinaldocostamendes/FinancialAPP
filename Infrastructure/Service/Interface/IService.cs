using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IService<T> where T : class
    {
        Task Post(T entity);

        Task Put(T entity);

        Task Delete(T entity);

        Task<List<T>> GetAll(PageParameters pageParameters);

        Task<T> GetById(Guid id);
    }
}