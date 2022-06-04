using RESTfullAPI.Model;
using RESTfullAPI.Repository;

namespace RESTfullAPI.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> List()
        {
            return _repository.List();
        }

        public Person? GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
                
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        } 

    }
}
