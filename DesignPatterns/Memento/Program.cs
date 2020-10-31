using System;

namespace Memento 
{
    class Program
    {
        //This design pattern tells about creating a memory and returning to that memory when desired.
        // After an object is changed, the old object is reverted if desired.
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "123",
                Title = "Sefiller",
                Author = "Victor Hugo"

            };
            book.ShowBook();
            CareTaker history=new CareTaker();
            history.Memento = book.CreateUndo();
            book.Isbn = "54321";
            book.Title = "SEFİLLER";
            book.ShowBook();
            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadLine();

        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get => _isbn;
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
             _lastEdited=DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}",Isbn,Title,Author,_lastEdited);
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn,string title,string author,DateTime lastEdit)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdit;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
