using System;
using System.Collections.Generic;
using System.Text;

namespace Task1DatabaseLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Student> Students { get; set; }
    }
}
