using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDos.Data
{
    internal class ToDosDatabase
    {
        private readonly SQLiteAsyncConnection connection;

        public ToDosDatabase(string path)
        {
            connection = new SQLiteAsyncConnection(path); //[utworzenie] i połaczenie za bazą danych
            connection.CreateTableAsync<ToDo>().Wait(); //utworzenie tabeli
        }

        //Async
        public Task<List<ToDo>> getTodosAsync()
        {
            return connection.Table<ToDo>().ToListAsync(); //async
        }

        public Task<ToDo> getTodoAsync(int id)
        {
            return connection.Table<ToDo>().FirstOrDefaultAsync(t => t.ID == id); //async
        }

        public Task<int> addOrUpdateToDoAsync(ToDo toDo)
        {
            if (toDo.ID == 0)
                return connection.InsertAsync(toDo);
            else
                return connection.UpdateAsync(toDo);
        }

        //Async z await 
        //public async Task<List<ToDo>> getTodos() {
        //    return await connection.Table<ToDo>().ToListAsync(); //synch, ale z przekazywaniem wątku
        //}

        //V. Synchroniczna
        //public List<ToDo> getTodos()
        //{
        //    return connection.Table<ToDo>().ToListAsync().Result;
        //}
    }
}
