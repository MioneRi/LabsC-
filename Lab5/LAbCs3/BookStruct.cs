using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    struct Book
    {
        private int bookID;
        private string title;
        private int price;
        // Год выпуска.
        private int year;

        // Initialize all fields with zeroes.
        public Book(int bookID) : this() 
        {
            this.bookID = bookID;
        }

        public int BookID
        {
            get { return bookID; }
        }

        public string Title
        {
            get { return title; }
        }

        public int Price
        {
            get { return price; }
        }

        public int Year
        {
            get { return year; }
        }

        public void SetInfo()
        {
            //------------------------------
            Write("Название : ");
            title = MainActions.GetCorrectString();

            //------------------------------
            Write("Год издания : ");
            year = MainActions.GetCorrectPositiveInt(1500, 2020);

            //------------------------------
            Write("Цена($) : ");
            price = MainActions.GetCorrectPositiveInt();
        }

        public void ShowInfo()
        {
            WriteLine( BookID + "   " + Title + "   " + Year + "   " + Price );
        }

    }


}
