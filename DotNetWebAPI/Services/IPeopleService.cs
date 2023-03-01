using React_and_WebAPI.Models;

namespace React_and_WebAPI.Services
{
    public interface IPeopleService
    {
        List<People> Get();
        People Get(string id);
        People Create(People person);
        void Update(string id, People person); 
        void Remove(string id);
    }
}
