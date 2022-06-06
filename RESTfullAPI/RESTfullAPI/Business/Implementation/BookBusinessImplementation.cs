using RESTfullAPI.Model;
using RESTfullAPI.Repository.Generic;

namespace RESTfullAPI.Business.Implementation
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IAsyncRepository<Book> _repository;

        public BookBusinessImplementation(IAsyncRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Book> Create(Book book)
        {
            return await _repository.Create(book);
        }

        public async Task<Book> Update(Book book)
        {
            return await _repository.Update(book);
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

    }
}
