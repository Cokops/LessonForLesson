using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LessonForLesson.Data
{
    [BsonIgnoreExtraElements]
    public class DataForDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {  get; set; }

        [BsonElement("идентификатор")]
        public int number {  get; set; }

        [BsonElement("производитель")]
        public string name {  get; set; }

    }
}
