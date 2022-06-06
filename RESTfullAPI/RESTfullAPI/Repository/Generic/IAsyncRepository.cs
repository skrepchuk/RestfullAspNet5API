using RESTfullAPI.Model.Base;

namespace RESTfullAPI.Repository.Generic
{
    public interface IAsyncRepository<Entity> where Entity : BaseEntity
    {
        Task<List<Entity>> GetAll();
        Task<Entity> GetById(long id);
        Task<Entity> Create(Entity entity);
        Task<Entity> Update(Entity entity);
        Task Delete(long id);
    }
}
