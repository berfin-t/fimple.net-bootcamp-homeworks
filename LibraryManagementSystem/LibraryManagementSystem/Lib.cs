using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Lib : IPrintable
    {
        private List<Book> books;
        private List<Member> members;
        private Dictionary<int, bool> inLibrary;
        public Lib()
        {
            books = new List<Book>();
            members = new List<Member>();
            inLibrary = new Dictionary<int, bool>();
        }
        public void Print()
        {
            Console.WriteLine("\nBooks:");
            foreach (var item in inLibrary.Where(i => i.Value == true).ToDictionary(i => i.Key))
            {
                Book book = books.Find(i => i.Id == item.Key);
                book.Print();
            }
            Console.WriteLine("****************************************************************************************************");
            Console.WriteLine("\nMembers:");
            foreach (var member in members)
            {
                member.Print();
            }
            Console.WriteLine("****************************************************************************************************");
        }
        public void AddBook(Book book)
        {
            books.Add(book);
            inLibrary.Add(book.Id, true);
            Console.WriteLine("Book added successfully!");
        }
        public void RemoveBookProcess()
        {
            Console.WriteLine("Enter id of book: ");
            Console.Write("\nBook Id: ");
            int bookId = Convert.ToInt32(Console.ReadLine());

            Book book = GetBookById(bookId);
            if (book != null)
            {
                books.Remove(book);
                inLibrary.Remove(book.Id);
                Console.WriteLine("Book removed successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        public void AddMember(Member member)
        {
            members.Add(member);
        }
        public void RemoveMember(Member member)
        {
            members.Remove(member);
        }
        public void Lending(int memberId, int bookId)
        {
            Member member = GetMemberById(memberId);
            Book book = GetBookById(bookId);

            if (member == null || book == null || !inLibrary[book.Id]) { Console.WriteLine("Member or book not found!"); return; }
            member.Borrow(book);
            inLibrary[book.Id] = false;
            Console.WriteLine($"{book.Name} successfully lent.");
        }
        public void GiveBack(int memberId, int bookId)
        {
            Member member = GetMemberById(memberId);
            Book book = GetBookById(bookId);
            if (member == null || book == null || inLibrary[book.Id]) { Console.WriteLine("Member or book not found!"); return; }
            member.GiveBook(book);
            inLibrary[book.Id] = true;
            Console.WriteLine($"{book.Name} successfully return.");
        }
        public Book GetBookById(int id)
        {
            return books.Find(book => book.Id == id);
        }
        public Member GetMemberById(int id)
        {
            return members.Find(member => member.MemberId == id);
        }
    }
}
