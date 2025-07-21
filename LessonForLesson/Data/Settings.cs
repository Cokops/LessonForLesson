using MongoDB.Driver;

namespace LessonForLesson.Data
{
    public class Settings
    {
        public  IMongoDatabase _db;

        public Settings()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("DBForAPI");
        }
        public IMongoCollection<DataForDB> Data => _db.GetCollection<DataForDB>("IDK");

    }
}
