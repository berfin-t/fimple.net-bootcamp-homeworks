using System;
using System.Collections.Generic;
using LibraryManagementSystem;
using static System.Reflection.Metadata.BlobBuilder;
class Program
{
    static void Start(Lib lib)
    {
        lib.Print();
        Console.WriteLine("\n1.Add Book: ");
        Console.WriteLine("2.Remove Book: ");
        Console.WriteLine("3.Add Member: ");
        Console.WriteLine("4.Remove Member: ");
        Console.WriteLine("5.Lending Book: ");
        Console.WriteLine("6.Give Back Book: ");
        Console.WriteLine("\nPlease select the action you want to perform: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                lib.AddBook(CreateBookFromInput());
                break;
            case 2:
                lib.RemoveBookProcess();
                break;
            case 3:
                Console.WriteLine("Enter members informations: ");
                Console.Write("\nName: ");
                string memberNameAdd = Console.ReadLine();
                Console.Write("Surname: ");
                string surname = Console.ReadLine();
                Console.Write("Id: ");
                int memberId = Convert.ToInt32(Console.ReadLine());
                Member newMember = new Member(memberNameAdd, surname, memberId);
                lib.AddMember(newMember);
                Console.WriteLine("Member added successfully!");
                break;
            case 4:
                Console.WriteLine("Enter name of member: ");
                Console.Write("\nName: ");
                int memberIdDelete = Convert.ToInt32(Console.ReadLine());

                Member memberToDelete = lib.GetMemberById(memberIdDelete);
                if (memberIdDelete != null)
                {
                    lib.RemoveMember(memberToDelete);
                    Console.WriteLine("Member removed successfully!");
                }
                else
                {
                    Console.WriteLine("Member not found!");
                }
                break;
            case 5:
                Console.WriteLine("Enter id of member: ");
                Console.Write("\nId: ");
                int memberIdLending = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter id of book");
                Console.Write("\nId: ");
                int bookIdLending = Convert.ToInt32(Console.ReadLine());
                lib.Lending(memberIdLending, bookIdLending);              
                break;
            case 6:
                Console.WriteLine("Enter id of member: ");
                Console.Write("\nId: ");
                int memberIdReturn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter id of book");
                Console.Write("\nId: ");
                int bookIdReturn = Convert.ToInt32(Console.ReadLine());
                lib.GiveBack(memberIdReturn, bookIdReturn);
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a valid menu option.");
                break;
        }
    }
    static Book CreateBookFromInput()
    {
        Console.WriteLine("Enter books informations: ");
        Console.Write("\nName: ");
        string bookNameAdd = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Year of Publication: ");
        int yearofPublication = Convert.ToInt32(Console.ReadLine());
        Console.Write("Book Id: ");
        int bookId = Convert.ToInt32(Console.ReadLine());
        return new Book(bookNameAdd, author, yearofPublication, bookId);

    }
    static void Main()
    {
        Lib lib = new Lib();
        Book book1 = new Book("Yaşamak", "Yu Hua", 2023, 1);
        Book book2 = new Book("İçimizdeki Şeytan", "Sabahattin Ali", 2023, 2);
        Member member1 = new Member("Berfin", "Tek", 100);
        Member member2 = new Member("Ayşe", "Selvi", 101);        
        lib.AddBook(book1);
        lib.AddBook(book2);
        lib.AddMember(member1);
        lib.AddMember(member2);        
        while (true)
        {
            Start(lib);
        }
    }
}
