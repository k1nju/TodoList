using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace Todo.Core.Repository
{
    public interface TodoRepository
    {
        //CRUD
        List<TodoModel> Read();
        void Delete(int id);
        void Create(TodoModel model);

        void Update(TodoModel model);
        void Save(List<TodoModel> todoModels);
    }

    public class TodoRepositoryImpl : TodoRepository
    {
        public TodoRepositoryImpl()
        {
            var parentDir = Path.GetDirectoryName(AppContext.BaseDirectory);
            string tmp = parentDir.Remove(parentDir.Length - 10, 10);
            string absolutePath = Path.Combine(tmp, ConnectionString);
            ConnectionString = string.Format("Data Source = {0};Version=3; FailIfMissing=False", absolutePath);
        }

        private readonly string ConnectionString = @"F:\\TodoList\\Todo.Core\\TodoList.db";
        void TodoRepository.Create(TodoModel todoModel)
        {
            try
            {
                string sql = $"INSERT INTO \"Todo\" VALUES(NULL, \"{todoModel.Name}\", \"{todoModel.Description}\", {todoModel.Group_id}, {todoModel.IsDone}, datetime(\'now\'), datetime('now'))";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
        }

        void TodoRepository.Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM \"Todo\" WHERE \"ID\" = {id}";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
        }

        List<TodoModel> TodoRepository.Read()
        {
            List<TodoModel> todoModels = new List<TodoModel>();
            try
            {
                string sql = $"Select * From Todo";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int index = 0;
                                int _id = rdr.GetInt32(index++);
                                string _name = rdr.GetString(index++);
                                string _description = (string)rdr.GetString(index++);
                                int _group_id = rdr.GetInt32(index++);
                                int _isDone = rdr.GetInt32(index++);
                                string _createdAt = rdr.GetString(index++);
                                string _updatedAt = rdr.GetString(index++);
                                todoModels.Add(new TodoModel());
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
            return todoModels;
        }

        void TodoRepository.Update(TodoModel todoModel)
        {
            try
            {
                string sql = $"UPDATE \"Todo\" SET \"name\" = \"{todoModel.Name}\", \"description\" = \"{todoModel.Description}\", \"group_id\" = {todoModel.Group_id}, \"isDone\" = {todoModel.IsDone}, updatedAt = date(\'now\') WHERE \"ID\" = {todoModel.Id};";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {

            }
        }

        public void Save(List<TodoModel> todoModels)
        {
            // Удалить повторы
            List<TodoModel> current = new List<TodoModel>();
            List<TodoModel> noDupes = new List<TodoModel>();
            try
            {
                string sql = $"Select * From Todo";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int index = 0;
                                int _id = rdr.GetInt32(index++);
                                string _name = rdr.GetString(index++);
                                string _description = (string)rdr.GetString(index++);
                                int _group_id = rdr.GetInt32(index++);
                                int _isDone = rdr.GetInt32(index++);
                                string _createdAt = rdr.GetString(index++);
                                string _updatedAt = rdr.GetString(index++);
                                current.Add(new TodoModel());
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
            current.AddRange(todoModels);
            foreach (TodoModel item in current)
            {
                List<TodoModel> tmp = current.Where(x => x.Id == item.Id).ToList();

                if (!tmp[0].Equals(tmp[1]))
                {
                    try
                    {
                        string sql = $"UPDATE \"Todo\" SET \"name\" = \"{tmp[1].Name}\", \"description\" = \"{tmp[1].Description}\", \"group_id\" = {tmp[1].Group_id}, \"isDone\" = {tmp[1].IsDone}, updatedAt = date(\'now\') WHERE \"ID\" = {tmp[1].Id};";
                        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                        {
                            connection.Open();
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (SQLiteException ex)
                    {

                    }
                }
            }
        }

        //CRUD - create, read, update, delete
    }
}
