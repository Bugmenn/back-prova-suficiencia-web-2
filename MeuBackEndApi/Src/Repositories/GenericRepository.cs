using MeuBackEndApi.Src.Data;
using MeuBackEndApi.Src.GenericModels;
using MeuBackEndApi.Src.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeuBackEndApi.Src.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Contexto do banco de dados todo, usado para salvar (SaveChangesAsync), usar transações,
        /// acessar outras tabelas e configurar tracking/comportamentos avançados
        /// </summary>
        protected readonly AppDbContext _context;
        /// <summary>
        /// Atalho da tabela especifica do banco de dados, 
        /// usado para ações diretas na tabela (como .Add, .Find, .Remove, .Where etc)
        /// </summary>
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<T> GetByWhere(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            if (where != null)
                query = query.Where(where);

            return query;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
