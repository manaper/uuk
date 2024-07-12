using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTest.Domain.Entities;
public class User
{
   
        public int Id { get; set; }
        public string? Name { get; set; }
        public  List<ToDoItem>? TodoItems { get; set; }
    
}
