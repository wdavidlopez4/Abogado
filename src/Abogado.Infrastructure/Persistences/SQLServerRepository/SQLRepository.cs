using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Abogado.Infrastructure.Persistences.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Abogado.Infrastructure.Persistences.SQLServerRepository
{
    public class SQLRepository : IRepository
    {
        private readonly AbogadoDbContext context;

        public SQLRepository(AbogadoDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public async Task Delete<T>(T obj) where T : Entity
        {
            await Task.FromResult(
               this.context.Remove(obj));
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            return context.Set<T>().Any(expression);
        }

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }


        public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expressionConditional) where T : Entity
        {
            return await context.Set<T>().Where(expressionConditional).ToListAsync();
        }

        public async Task<List<T>> GetAll<T>() where T : Entity
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested) where T : Entity
        {
            return await context.Set<T>()
                   .Where(expressionConditional)
                   .Include(nested)
                   .ToListAsync();
        }


        public async Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested, string nestedTwo) where T : Entity
        {
            return await context.Set<T>()
                    .Where(expressionConditional)
                    .Include(nested)
                    .Include(nestedTwo)
                    .ToListAsync();
        }

        public async Task<T> GetNested<T>(Expression<Func<T, bool>> expression, string nested, string nestedSecond) where T : Entity
        {
            return await context.Set<T>()
                   .Where(expression)
                   .Include(nested)
                   .Include(nestedSecond)
                   .FirstOrDefaultAsync();
        }

        public async Task<T> GetNested<T>(Expression<Func<T, bool>> expression, string nested) where T : Entity
        {
            return await context.Set<T>()
                   .Where(expression)
                   .Include(nested)
                   .FirstOrDefaultAsync();
        }

        public async Task Save<T>(T obj) where T : Entity
        {
            await this.context.AddAsync<T>(obj);
        }

        public async Task Update<T>(T obj) where T : Entity
        {
            await Task.FromResult(
                this.context.Update(obj));
        }
    }
}
