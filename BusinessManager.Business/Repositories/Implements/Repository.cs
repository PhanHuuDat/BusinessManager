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
        protected readonly DbSet<U> dbSet;
        protected readonly IMapper _mapper;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            dbSet = db.Set<U>();
        }
        public virtual async Task<bool> CreateAsync(T entity)
        {
            U obj = _mapper.Map<U>(entity);

            try
            {
                await dbSet.AddAsync(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public virtual async Task<bool> DeleteAsync(int entityId)
        {
            try
            {
                var item = await dbSet.FindAsync(entityId);
                dbSet.Remove(item!);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
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

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<U, bool>>? filter = null,
            string? includeProperties = null, bool isTracking = true)
        {
            IQueryable<U> query = dbSet;


            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            _db.ChangeTracker.QueryTrackingBehavior = isTracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;
            var entities = await query.ToListAsync();
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            return _mapper.Map<IEnumerable<U>, IEnumerable<T>>(entities);
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<U, bool>>? filter = null, string? includeProperties = null,
            bool isTracking = true)
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

            _db.ChangeTracker.QueryTrackingBehavior = isTracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;

            var result = await query.FirstOrDefaultAsync();

            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            return _mapper.Map<T>(result);
        }

        public virtual Task<bool> CreateRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }


    }
}
