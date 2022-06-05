using RESTfullAPI.Model;
using RESTfullAPI.Model.Context;

namespace RESTfullAPI.Repository.Implementation
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> List()
        {
            return _context.TableBook.ToList();
        }

        public Book? GetById(long id)
        {
            if (!Exists(id)) return null;
            return _context.TableBook.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }


        public Book? Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var existBook = GetById(book.Id);

            if (existBook != null)
            {
                try
                {
                    _context.Entry(existBook).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var tableBook = GetById(id);

            if (tableBook != null)
            {
                try
                {
                    _context.TableBook.Remove(tableBook);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.TableBook.Any(p => p.Id.Equals(id));
        }
    }
}
