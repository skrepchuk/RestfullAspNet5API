using Microsoft.EntityFrameworkCore;
using RESTfullAPI.Model.Base;
using RESTfullAPI.Model.Context;

namespace RESTfullAPI.Repository.Generic
{
    public class AsyncGenericRepository<Entity> : IAsyncRepository<Entity> where Entity : BaseEntity
    {
        private readonly MySQLContext _context;
        public AsyncGenericRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<List<Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Entity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Entity> GetById(long id)
        {
            try
            { 
                var exists = await _context.Set<Entity>().SingleOrDefaultAsync(e => e.Id.Equals(id));
                if (exists != null) return exists;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve this specific entity: {ex.Message}");
            }
            return null;
        }
        public async Task<Entity> Create(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Create)} entity must not be null");
            }
            try
            {
                await _context.Set<Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<Entity> Update(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                _context.Set<Entity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public async Task Delete(long id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException($"{nameof(Delete)} The identifier value `0` is not valid");
            }
            try
            {
                var exists = await _context.Set<Entity>().SingleOrDefaultAsync(e => e.Id.Equals(id));
                if (exists != null) _context.Set<Entity>().Remove(exists);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be deleted user with this specific id: {ex.Message}");
            }
        }
    }
}
