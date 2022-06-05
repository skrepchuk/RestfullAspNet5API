using RESTfullAPI.Model;
using RESTfullAPI.Repository;

namespace RESTfullAPI.Business.Implementation
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> List()
        {
            return _repository.List();
        }

        public Book? GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book? Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
