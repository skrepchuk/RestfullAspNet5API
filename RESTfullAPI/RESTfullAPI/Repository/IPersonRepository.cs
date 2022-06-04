using RESTfullAPI.Model;

namespace RESTfullAPI.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person? GetById(long id);
        Person? Update(Person person);
        void Delete(long id);
        List<Person> List();
        bool Exists(long id);

    }
}
