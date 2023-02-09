using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessManager.Business.Repositories.Implements
{
    public class Repository<T, U> : IRepository<T, U> where T : BaseDTO where U : BaseDAO
    {
        protected readonly ApplicationDbContext _db;
        private readonly DbSet<U> dbSet;
        protected readonly IMapper _mapper;
        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            dbSet = db.Set<U>();
        }
        public async Task<bool> CreateAsync(T entity)
        {
            U obj = _mapper.Map<U>(entity);
            try
            {
                var result = await dbSet.AddAsync(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public async Task<bool> DeleteAsync(T entity)
        {
            U obj = _mapper.Map<U>(entity);

            try
            {
                await Task.Run(() => dbSet.Remove(obj!));
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            IEnumerable<U> objects = _mapper.Map<IEnumerable<U>>(entities);
            try
            {
                await Task.Run(() => dbSet.RemoveRange(objects));
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<U, bool>>? filter = null,
            Func<IQueryable<U>, IOrderedQueryable<U>>? orderby = null,
            string? includeProperties = null)
        {
            IQueryable<U> query = dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderby != null)
            {
                List<U> source = await orderby(query).ToListAsync();
                return await Task.Run(() => _mapper.Map<IEnumerable<U>, IEnumerable<T>>(source));
            }

            return _mapper.Map<IEnumerable<U>, IEnumerable<T>>(await query.ToListAsync());
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<U, bool>>? filter = null, string? includeProperties = null)
        {

            IQueryable<U> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            var result = await query.FirstOrDefaultAsync();
            return _mapper.Map<T>(result);
        }

        public Task<bool> CreateRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<U, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }
    }
}
