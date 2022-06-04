using Abogado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Ports
{
    public interface IRepository
    {
        public Task Save<T>(T obj) where T : Entity;

        public Task Update<T>(T obj) where T : Entity;

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;

        public Task Commit();

        public Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity;

        public Task<T> GetNested<T>(Expression<Func<T, bool>> expression, string nested, string nestedSecond) where T : Entity;

        public Task<T> GetNested<T>(Expression<Func<T, bool>> expression, string nested, string nestedSecond, string nestedTree) where T : Entity;

        public Task<T> GetNested<T>(Expression<Func<T, bool>> expression, string nested) where T : Entity;

        public Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expressionConditional) where T : Entity;

        public Task<List<T>> GetAll<T>() where T : Entity;

        public Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested) where T : Entity;

        public Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested, string nestedTwo) where T : Entity;
        public Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested, string nestedTwo, string nestedTree) where T : Entity;

        public Task Delete<T>(T obj) where T : Entity;
    }
}
