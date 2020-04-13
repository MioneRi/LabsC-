using System;
using static System.Console;
using System.Globalization;

namespace LAbCs3
{
    public struct Book : IEntity, IFormattable
    {
        private int bookID;
        private string title;
        private int price;
        // Год выпуска.
        private int year;

        // "this()" Initializes all fields with zeroes.
        public Book(int bookID) : this() 
        {
            this.bookID = bookID;
        }

        public int BookID => bookID;

        public string Title => title;

        public int Price => price;

        public int Year => year;        

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
            WriteLine( BookID + "   " + Title + "   " + Year + "   " + Price.ToString("C2"));
        }

        public override string ToString()
        {
            return ToString("Standart", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            string ourOutput;

            if (String.IsNullOrEmpty(format))
            {
                format = "Standart";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }            

            switch (format)
            {
                case "Full":
                    {
                        ourOutput = "ID: " + BookID + "\n" + "Название: " + Title + "\n" + "Год: " + 
                            Year + "\n" + "Цена: " + Price.ToString("C2", new CultureInfo("en-US")) + "\n";
                    }
                    break;

                case "Minimal":
                    {
                        ourOutput = "ID: " + BookID + "\n" + "Название: " + Title + "\n";
                    }
                    break;

                case "Standart":
                    {
                        ourOutput = BookID + "   " + Title + "   " + Year + "   " + Price.ToString("C2", new CultureInfo("en-US")) + "\n";
                    }
                    break;

                default:
                    {
                        throw new FormatException(String.Format("The {0} format string is not supported.", format));
                    }
                    break;
            }

            return ourOutput;
        }

    }


}
