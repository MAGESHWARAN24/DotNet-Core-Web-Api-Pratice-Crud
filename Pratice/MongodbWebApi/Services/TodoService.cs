using Microsoft.Extensions.Options;
using MongodbWebApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongodbWebApi.Services
{
    public class TodoService
    {
        public readonly IMongoCollection<Todo> _TodoCollection;
        public TodoService(IOptions<DatabaseSettings> databaseSettings) {
            var mongodbClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongodbDatabase = mongodbClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _TodoCollection = mongodbDatabase.GetCollection<Todo>(databaseSettings.Value.CollectionName);
        }
        public async Task<List<Todo>> GetAllTodo() => await _TodoCollection.Find(_=>true).ToListAsync();
        public async Task CreateTodo(Todo todo) => await _TodoCollection.InsertOneAsync(todo);
        public async Task<Todo> GetTodoId(string Id) => await _TodoCollection.Find(todo => todo.Id == Id).FirstOrDefaultAsync();

        public async Task UpdateTodo(string Id,string updateStatus)
        {
            Todo todo = await GetTodoId(Id);
            todo.Status = updateStatus;
            await _TodoCollection.ReplaceOneAsync(todo => todo.Id == Id, todo);
        }
        public async Task DeleteTodo(string Id) => await _TodoCollection.FindOneAndDeleteAsync(todo  => todo.Id == Id);
    }
}
