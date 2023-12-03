using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Member : IPrintable
    {
        public string Name { get; private set; }
        private string surname;
        public int MemberId { get; private set; }
        private List<Book> booksBarrowed;
        public Member(string name, string surname, int memberId)
        {
            this.Name = name;
            this.surname = surname;
            this.MemberId = memberId;
            this.booksBarrowed = new List<Book>();
        }
        public void Borrow(Book book)
        {
            booksBarrowed.Add(book);
        }
        public void GiveBook(Book book)
        {
            booksBarrowed.Remove(book);
        }
        public void Print()
        {
            Console.WriteLine($"\nMember Name: {Name}, Surname: {surname}, Member Id: {MemberId}");
            Console.WriteLine("\nBooks of Borrow: ");
            foreach (var book in booksBarrowed) { book.Print(); }
        }
    }
}
