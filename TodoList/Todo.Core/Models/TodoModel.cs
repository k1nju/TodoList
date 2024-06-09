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

        public int Id { get ; set ; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Group_id { get; set; }
        public int IsDone { get; set; }

        public string CreatedAt { get; set;}
        public string UpdatedAt { get ; set ;} 
	}
}