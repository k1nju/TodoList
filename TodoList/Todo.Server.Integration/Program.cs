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
using System.Net.Http.Json;

namespace Todo.Integration
{
    public class Program
    {
        public static readonly HttpClient client = new HttpClient();

        private static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:5052/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                TodoModel model = new TodoModel
                {
                    Id = 0,
                    Name = "zxc",
                    Description = "qwe"
                };

                // Get the product
                List<TodoModel> todos = await Create(model);

                await Console.Out.WriteLineAsync("РЕГАЕМСЯ");
                await Console.Out.WriteLineAsync(string.Join(" ", todos));

                todos = await Get();
                await Console.Out.WriteLineAsync("ЛОГИНИМСЯ");
                await Console.Out.WriteLineAsync(string.Join(" ", todos));



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }


        static async Task<TodoModel> GetUserAsync(string path)
        {
            TodoModel model = null;


            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                model = DataSerializer.Deserialize<TodoModel>(await response.Content.ReadAsStringAsync())!;
            }
            return model;
        }

        static async Task<List<TodoModel>> Create(TodoModel model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/TodoModels", model);
            response.EnsureSuccessStatusCode();

            List<TodoModel> userResponse = new();
            if (response.IsSuccessStatusCode)
            {
                userResponse = DataSerializer.Deserialize<List<TodoModel>>(await response.Content.ReadAsStringAsync())!;
            }
            return userResponse;
        }

        static async Task<List<TodoModel>> Get()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/TodoModels");
            response.EnsureSuccessStatusCode();

            List<TodoModel> userResponse = new();
            if (response.IsSuccessStatusCode)
            {
                userResponse = DataSerializer.Deserialize<List<TodoModel>>(await response.Content.ReadAsStringAsync())!;
            }
            return userResponse;
        }
    }
}