using MongoDB.Bson;
using MongoDB.Driver;

namespace AutomationPractice.Helpers
{
    public class DatabaseConnector
    {
        public readonly IMongoDatabase MongoDB;
        public DatabaseConnector()
        {
            var client = new MongoClient("mongodb://TestAutomationUser:Password@localhost:27018/");
            MongoDB = client.GetDatabase("AutomationPracticeDB");
        }

        public IMongoCollection<LogEntry> GetLogsStorage() => MongoDB.GetCollection<LogEntry>("LogsStorage");

        public int GetNextSequenceValue(string sequenceName)
        {
            var sequenceCollection = MongoDB.GetCollection<BsonDocument>("Sequences");

            var filter = Builders<BsonDocument>.Filter.Eq("sequence_name", sequenceName);
            var update = Builders<BsonDocument>.Update.Inc("sequence_value", 1);

            var options = new FindOneAndUpdateOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.After
            };

            var sequenceDocument = sequenceCollection.FindOneAndUpdate(filter, update, options);

            return sequenceDocument["sequence_value"].AsInt32;
        }
    }
}
