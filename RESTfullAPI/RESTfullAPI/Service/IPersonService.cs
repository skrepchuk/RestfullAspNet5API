using RESTfullAPI.Model;

namespace RESTfullAPI.Service
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person? GetById(long id);
        Person Update(Person person);
        void Delete(long id);
        List<Person> List();

    }
}
