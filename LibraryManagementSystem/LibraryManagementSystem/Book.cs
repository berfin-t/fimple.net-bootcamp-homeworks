using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    public class Book : Literature
    {
        public string Name { get; private set; }
        private string author;
        public Book(string name, string author, int yearofPublication, int id) : base(name, yearofPublication, id)
        {
            this.Name = name;
            this.author = author;
        }
        public void Print()
        {
            base.Print();
            Console.WriteLine($"Author: {author}\n");
        }
    }
}
