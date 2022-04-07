using SQLite;

namespace ToDos.Data
{
    internal class ToDo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
