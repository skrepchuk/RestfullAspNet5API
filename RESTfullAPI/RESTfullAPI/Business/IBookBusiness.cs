using RESTfullAPI.Model;

namespace RESTfullAPI.Business
{
    public interface IBookBusiness
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(long id);
        Task<Book> Update(Book book);
        Task<Book> Create(Book book);
        Task Delete(long id);
    }
}
