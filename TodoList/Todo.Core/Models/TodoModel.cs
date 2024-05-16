using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core
{
    public class TodoModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private int _id;
        private string _name;
        private string _description;
        private int _group_id;
        private int _isDone;
        private string _createdAt;
        private string _updatedAt;

        public TodoModel(int id, string name, string description, int group_id, int isDone, string createdAt, string updatedAt)
        {
            _id = id;
            _name = name;
            _description = description;
            _group_id = group_id;
            _isDone = isDone;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int Group_id { get => _group_id; set => _group_id = value; }
        public int IsDone { get => _isDone; set => _isDone = value; }

        public string CreatedAt { get => _createdAt; set => _createdAt = value;}
        public string UpdatedAt { get => _updatedAt; set => _updatedAt = value;} 
	}
}