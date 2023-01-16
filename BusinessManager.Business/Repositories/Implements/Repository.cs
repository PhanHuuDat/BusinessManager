using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Repositories.Implements
{
    public class Repository<T, U> : IRepository<T, U> where T : BaseDTO where U : BaseDAO
    {
        private readonly DbSet<U> dbSet;
        private readonly IMapper _mapper;
        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            dbSet = db.Set<U>();
        }
        public async Task<T?> CreateAsync(T entity)
        {
            U obj = _mapper.Map<U>(entity);
            try
            {
                obj.CreatedDate = DateTimeOffset.UtcNow;
                await dbSet.AddAsync(obj);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return _mapper.Map<T>(obj);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                U obj = _mapper.Map<U>(entity);
                await Task.Run(() => dbSet.Remove(obj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                IEnumerable<U> objects = (IEnumerable<U>)_mapper.Map<U>(entities);
                await Task.Run(() => dbSet.RemoveRange(objects));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<U, bool>>? filter = null,
            Func<IQueryable<U>, IOrderedQueryable<U>>? orderby = null,
            string? includeProperties = null)
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
            return _mapper.Map<T>(await query.FirstOrDefaultAsync());
        }

    }
}
