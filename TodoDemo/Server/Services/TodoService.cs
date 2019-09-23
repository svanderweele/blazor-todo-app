using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoDemo.Shared;

namespace TodoDemo.Server.Services
{
    public class TodoService
    {

        private readonly IMongoCollection<TodoModel> _todos;

        public TodoService(IAppDatabaseSettings appDatabaseSettings)
        {
            var client = new MongoClient(appDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(appDatabaseSettings.DatabaseName);

            _todos = database.GetCollection<TodoModel>(appDatabaseSettings.TodosCollectionName);
        }

        public List<TodoModel> Get() => _todos.Find(todo => true).ToList();

        public TodoModel Get(string id) => _todos.Find<TodoModel>(todo => todo.Id == id).FirstOrDefault();

        public TodoModel Create(TodoModel todo)
        {
            _todos.InsertOne(todo);
            return todo;
        }

        public void Update(string id, TodoModel todoIn)
        {
            _todos.ReplaceOne(todo => todo.Id == id, todoIn);
        }


        public void Remove(string id)
        {
            _todos.DeleteOne(todo => todo.Id == id);
        }
        public void Update(TodoModel todoIn)
        {
            _todos.DeleteOne(todo => todo.Id == todoIn.Id);
        }
    }
}
