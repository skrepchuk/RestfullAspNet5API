using RESTfullAPI.Model;

namespace RESTfullAPI.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book? GetById(long id);
        Book? Update(Book book);
        void Delete(long id);
        List<Book> List();
    }
}
