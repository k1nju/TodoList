using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Core.Repository;
using System.Net.Http.Headers;
using System.Net.Http;
using Todo.Server.Utils;

namespace Todo.Integration
{
    public class Program
    {
        static void Main(string[] args)
        {
            var clientResponse = callRESTAPI();

            if (clientResponse.Result == null)
            {
                Console.WriteLine("Please check the Url Parameters");
            }
            TodoRepository rep = new TodoRepositoryImpl();
            List<TodoModel> Tmp = rep.Read();
            foreach (TodoModel w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.Id) + " " + w.Name
                    + " " + w.Description + " " + w.Group_id + " " + w.IsDone + " " + w.CreatedAt + " " + w.UpdatedAt);
            }

            TodoModel todo = new TodoModel();
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
        public static async Task<IEnumerable<TodoModel>> callRESTAPI()
        {

            var httpClient = new HttpClient();
            var baseUrl = "https://localhost:8080/api/Employee/GetAll";
            httpClient.BaseAddress = new Uri(baseUrl);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = httpClient.GetAsync(baseUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic dataresponseobject = response.Content.ReadAsStringAsync().Result;

                foreach (var item in dataresponseobject)
                {
                    Console.WriteLine($"{item.Company}");
                }
            }
            return DataSerializer. response.Content.ReadAsStringAsync().Result;
        }
    }
}