using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using Todo.Core;


namespace TodoList.Services
{
    public class FileService
    {
        private static BindingList<TodoModel> _todoDataList;
        private readonly string PATH;
        public FileService(string path)
        {
            PATH = path;
        }
        public static BindingList<TodoModel> LoadData(string PATH, int id)
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                _todoDataList = JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
                return _todoDataList;
            }
        }

        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
