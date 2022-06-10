using System;

namespace CSharp_Net_module1_2_1_lab
{

    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser

    public class LibraryUser : ILibraryUser
    {
        private string[] bookList; 
        public string this [int i]
        {
            get
            {
                if (i < bookList.Length && i >= 0)
                {
                    return bookList[i];
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException();
                };
            }
            set 
            {
                if(i < bookList.Length)
                {
                    bookList[i] = value;
                }
            }
        }
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public  string Phone { get; set; }
        public int BookLimit { get; private set; }
        public int BookCount{ get; private set; }

        public LibraryUser(int id = 0, string firstname = "",
            string lastname = "", string phone = "", int booklimit = 10)
        {
            bookList = new string [booklimit];
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Phone = phone;
            BookLimit = booklimit;
        }

        public void AddBook(string book)
        {
            bool HaveSpace = !string.IsNullOrEmpty(bookList[BookLimit - 1]);
            if (HaveSpace)
            {
                if (string.IsNullOrEmpty(book))
                {
                    throw new System.NullReferenceException();
                }
                else
                {
                    for (int i = 0; i < bookList.Length; ++i)
                    {
                        if(string.IsNullOrEmpty(bookList[i]))
                        {
                            bookList[i] = book;
                            return;
                        }
                        
                    }

                }
            }
            else
            {
                Console.WriteLine("Book Limit is reached !!!");
            }


        }

        public void RemoveBook(int index)
        {
            --index;
            if(index >= 0 && index < bookList.Length)
            {
                for(int i = index; i < bookList.Length - 1; ++i)
                {
                    bookList[i] = bookList[i + 1];
                }
                bookList[bookList.Length - 1] = null;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public string BookInfo(int index)
        {
            if (index < bookList.Length && index >= 0)
            {
                return bookList[index]; 
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int BooksCount()
        {
            int bookscount = 0;
            for(int i = 0; i < bookList.Length; ++i)
            {
                if(bookList[i] != null)
                {
                    ++bookscount;
                }
            }
            return bookscount;
        }
        public override string ToString()
        {
            string str = "\nID : " + ID + "\nFirstName : " + FirstName + "\nLastName : " + LastName + "\nPhone : " + Phone + "\nBookLimit : " + BookLimit;
            for(int i = 0; bookList[i] != null; ++i)
            {
                str += "\nBook #" + i + "\nBook Name : " + bookList[i];
            }
            return str;
        }
    }

    // 2) declare class LibraryUser, it implements ILibraryUser


    // 3) declare properties: FirstName (read only), LastName (read only), 
    // Id (read only), Phone (get and set), BookLimit (read only)
 
    // 4) declare field (bookList) as a string array

 
    // 5) declare indexer BookList for array bookList
 
    // 6) declare constructors: default and parameter
 
    // 7) declare methods: 

        //AddBook() – add new book to array bookList
 
        //RemoveBook() – remove book from array bookList
 
        //BookInfo() – returns book info by index
 
        //BooksCout() – returns current count of books
  
}
