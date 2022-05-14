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

        public T Exists<T>(Expression<Func<bool, T>> expression) where T : Entity;

        public Task Commit<T>() where T : Entity;

        public Task<T> Get<T>(Expression<Func<bool, T>> expression) where T : Entity; 
    }
}
