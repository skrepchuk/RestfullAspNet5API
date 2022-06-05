using RESTfullAPI.Model;

namespace RESTfullAPI.Repository
{
    public interface IBookRepository
    {
        Book Create(Book person);
        Book? GetById(long id);
        Book? Update(Book person);
        void Delete(long id);
        List<Book> List();
        bool Exists(long id);
    }
}
