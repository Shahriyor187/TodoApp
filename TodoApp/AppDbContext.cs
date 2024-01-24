using MongoDB.Driver;
using TodoApp.Models;

namespace TodoApp
{
    public class AppDbContext
    {
        public IMongoDatabase _database { get; }
        public AppDbContext(string connection, string database) 
        {
            var client = new MongoClient(connection);
            _database = client.GetDatabase(database);
        }
        public IMongoCollection<Todo> Todos => _database.GetCollection<Todo>("Todos");
    }
}
