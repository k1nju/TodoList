using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Core.Repository;

namespace Todo.Integration
{
    public class Program
    {
        static void Main(string[] args)
        {
            TodoRepository rep = new TodoRepositoryImpl();
            List<TodoModel> Tmp = rep.Read();
            foreach (TodoModel w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.Id) + " " + w.Name
                    + " " + w.Description + " " + w.Group_id + " " + w.IsDone + " " + w.CreatedAt + " " + w.UpdatedAt);
            }

            TodoModel todo = new TodoModel(1, "сделать уроки", "на завтра", 1, 0, "", "");
            rep.Create(todo);
            
            Tmp = rep.Read();
            
            todo = Tmp.Last();
            
            foreach (TodoModel w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.Id) + " " + w.Name
                    + " " + w.Description + " " + w.Group_id + " " + w.IsDone + " " + w.CreatedAt + " " + w.UpdatedAt);
            }
            todo.IsDone = 1;
            todo.Name = "сходить в зал";
            todo.Description = "в субботу";
            rep.Update(todo);
            Tmp = rep.Read();

            foreach (TodoModel w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.Id) + " " + w.Name
                    + " " + w.Description + " " + w.Group_id + " " + w.IsDone + " " + w.CreatedAt + " " + w.UpdatedAt);
            }
            Console.ReadKey();
        }
    }
}