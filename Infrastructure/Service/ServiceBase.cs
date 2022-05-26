using Infrastructure.Entity;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        private readonly IRepositoryBase<T> _irepository;

        public async Task Delete(T entity)
        {
            await _irepository.Delete(entity);
        }

        public async Task<List<T>> GetAll(PageParameters pageParameters)
        {
            return await _irepository.GetAll(pageParameters);
        }

        public async Task<T> GetById(Guid id)
        {
            return await _irepository.GetById(id);
        }

        public async Task Post(T entity)
        {
            await _irepository.Post(entity);
        }

        public async Task Put(T entity)
        {
            await _irepository.Put(entity);
        }
    }
}