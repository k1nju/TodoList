// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

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
            
        else
            {
                clientResponse.Result.ToList().ForEach(x => Console.WriteLine(x.Name + " ")) ;
            }


        }
        public static async Task<IEnumerable<TodoModel>> callRESTAPI()
        {

            var httpClient = new HttpClient();
            var baseUrl = "http://localhost:5052/api/TodoModels";
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
            return DataSerializer.Deserialize<IEnumerable<TodoModel>>(response.Content.ReadAsStringAsync().Result)!;
        }
    }
}