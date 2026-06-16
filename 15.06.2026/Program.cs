using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;

namespace _15._06._2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1 Shop
            //Shop miniMarket = new Shop ("ABC","Ukraine, Mukachevo",35.5,"food market","0950643568","Minimarket@gmail.com");
            //Shop miniMarket2 = new Shop ("Lux","Ukraine, Mukachevo",42.33,"food market","0950987568","FoodLuxmarket@gmail.com");
            //Console.WriteLine(miniMarket);
            //Console.WriteLine("\n");
            //Console.WriteLine(miniMarket2);
            //miniMarket += 10.5;
            //miniMarket2 -= 3.5;
            //Console.WriteLine(miniMarket < miniMarket2);
            //Console.WriteLine(miniMarket > miniMarket2);
            //Console.WriteLine(miniMarket == miniMarket2);
            //Console.WriteLine(miniMarket != miniMarket2);
            //Console.WriteLine(miniMarket.Equals(miniMarket2));
            //Console.WriteLine("~~~~~~~~~~~~~~~~Shops after change Area!~~~~~~~~~~~~~~~");
            //Console.WriteLine(miniMarket);
            //Console.WriteLine("\n");
            //Console.WriteLine(miniMarket2);
            #endregion
            var MyList = new BookList(new Book[]
            {
                new Book("I See You Are Interested in Darkness","Illarion Pavlyuk","deep psychological detective",639),
                new Book("Harry Potter and philosopher's stone","Joanne Rowling","family nowel",223),
                new Book ("100 years of solitude","Gabriel García Márquez","multi-generational story",422)
            });
            try
            {
                Console.WriteLine(MyList[0].Name);
                Console.WriteLine(MyList[0].pages);
                MyList[0] += 10;
                Console.WriteLine(MyList[0].pages);
                Console.WriteLine(MyList["100 years of solitude"].Author);
                MyList["100 years of solitude"].Author = "test author";
                Console.WriteLine(MyList["100 years of solitude"].Author);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Shop
    {
        string telephone;
        string email;
        public Shop(string name, string address, double storeArea, string description, string telephone, string email)
        {
            Name = name;
            Address = address;
            StoreArea = storeArea;
            Description = description;
            Telephone = telephone;
            Email = email;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public double StoreArea { get; set; }
        public string Description { get; set; }
        public string Telephone
        {
            get { return telephone; }

            set
            {
                if (value.Length == 10 && value.All(char.IsDigit))
                {
                    telephone = value;
                }
                else { Console.WriteLine("Invalid phone number. It should be 10 digits."); }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains("@"))
                {
                    email = value;
                }
                else { Console.WriteLine("Invalid email format."); }
            }
        }
        public override string ToString()
        {
            return
                $" Name: {Name}\n " +
                $"Address: {Address}\n" +
                $"Store Area: {StoreArea}\n" +
                $" Description: {Description}\n" +
                $" Telephone: {Telephone}\n" +
                $" Email: {Email}";
        }
        public static Shop operator +(Shop a, double num)
        {
            a.StoreArea += num;
            return a;
        }
        public static Shop operator -(Shop a, double num)
        {
            a.StoreArea -= num;
            return a;
        }
        public static bool operator >(Shop a, Shop b)
        {
            return a.StoreArea > b.StoreArea;
        }
        public static bool operator <(Shop a, Shop b)
        {
            return a.StoreArea < b.StoreArea;
        }
        public static bool operator ==(Shop a, Shop b)
        {
            return (a.StoreArea == b.StoreArea);
        }
        public static bool operator !=(Shop a, Shop b)
        {
            return (a.StoreArea != b.StoreArea);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Shop)
            {
                return ((Shop)obj).StoreArea == this.StoreArea;
            }
            else
            {
                return false;
            }
        }
    }
    class Book
    { 
    public string Name { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    
    private int Pages;
    public int pages 
        {
            get {  return Pages; }
            set 
            {
            if(value > 0)
                {
                    Pages = value;
                }
                else
                {
                    Console.WriteLine("Number of pages must be greater than zero.");
                }
            }
        }
        public Book(string name, string author, string description, int _pages)
        {
            Name = name;
            Author = author;
            Description = description;
            Pages = _pages;
        }
        public static Book operator +(Book a, int num)
        {
            a.Pages += num;
            return a;
        }

        public static Book operator -(Book a, int num)
        {
            a.Pages -= num;
            return a;
        }
    }
    
    class BookList
    {
        Book[] book;
        public BookList(Book[] books)
        { 
            book = books;
        }
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && book.Length > index)
                    return book[index];
                else
                    throw new IndexOutOfRangeException("Bounds Alert!!");
            }
            set 
            {
                if (index >= 0 && book.Length > index)
                    book[index] = value;
            }
        }
        public Book this[string name]
        {
            get 
            {
                foreach (var item in book)
                {
                    if (item.Name == name) return item;
                }
                throw new Exception("Book not found");
            }
                        
        }
        
        public bool Contains(string name)
        {
            foreach (var item in book)
            {
                if (item.Name == name)
                    return true;
            }
            return false;
        }
        
    }
}