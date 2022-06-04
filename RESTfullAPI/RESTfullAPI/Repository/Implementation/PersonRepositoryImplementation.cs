using RESTfullAPI.Model;
using RESTfullAPI.Model.Context;

namespace RESTfullAPI.Repository.Implementation
{
    public class PersonRepositoryImplementation : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImplementation (MySQLContext context)
        {
            _context = context;
        }

        public List<Person> List()
        {
            return _context.TablePerson.ToList();
        }

        public Person? GetById(long id)
        {
            return _context.TablePerson.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var existPerson = GetById(person.Id);

            if (existPerson != null)
            {
                try
                {
                    _context.Entry(existPerson).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        public void Delete(long id)
        {
            var existPerson = GetById(id);

            if (existPerson != null)
            {
                try
                {
                    _context.TablePerson.Remove(existPerson);
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
            return _context.TablePerson.Any(p => p.Id.Equals(id));
        }

    }
}
