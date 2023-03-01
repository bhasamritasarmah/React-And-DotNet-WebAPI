using MongoDB.Driver;
using React_and_WebAPI.Models;

namespace React_and_WebAPI.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IMongoCollection<People> _people;

        public PeopleService(IPeopleDatabaseSettings settings, IMongoClient mongoClient)
        { 
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _people = database.GetCollection<People>(settings.CollectionName);
        }

        public People Create(People person)
        {
            _people.InsertOne(person);
            return person;
        }

        public List<People> Get()
        {
            return _people.Find(m => true).ToList();
        }

        public People Get(string id)
        {
            return _people.Find(m => m.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _people.DeleteOne(m => m.Id == id);
        }

        public void Update(string id, People person)
        {
            _people.ReplaceOne(m => m.Id == id, person); 
        }
    }
}
