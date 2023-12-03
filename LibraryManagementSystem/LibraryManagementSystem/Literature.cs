using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Literature : IPrintable
    {
        private string name;
        private int yearofPublication;
        public int Id { get; private set; }
        public Literature(string name, int yearofPublication, int id)
        {
            this.name = name;
            this.yearofPublication = yearofPublication;
            this.Id = id;
        }
        public void Print()
        {
            Console.WriteLine($"Id: {Id}\nName: {name}\nYearofPublication: {yearofPublication}");
        }
    }
}
