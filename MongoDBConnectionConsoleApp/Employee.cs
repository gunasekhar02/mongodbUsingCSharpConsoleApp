using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBConnectionConsoleApp
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmpId {  get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public int YearsOfExp { get; set; }

    }
}
