using RESTfullAPI.Model;

namespace RESTfullAPI.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person? GetById(long id);
        Person? Update(Person person);
        void Delete(long id);
        List<Person> List();

    }
}
