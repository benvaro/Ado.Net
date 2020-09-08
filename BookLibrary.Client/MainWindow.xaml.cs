using BookLibrary.BLL.Model;
using BookLibrary.BLL.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace BookLibrary.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBookService service;
        public ObservableCollection<BookDTO> Books { get; set; } = new ObservableCollection<BookDTO>();
        public MainWindow(IBookService bookService)
        {
            InitializeComponent();
            service = bookService;
            UpdateBooks(bookService);
            this.DataContext = Books;
        }

        private void UpdateBooks(IBookService bookService)
        {
            Books.Clear();
            var temp = bookService.GetBooks();
            foreach (var item in temp)
            {
                Books.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookDTO book = new BookDTO
            {
                Title = tbName.Text,
                Price = Single.Parse(tbPrice.Text),
                Year = Int32.Parse(tbYear.Text),
                Author = tbAuthor.Text,
                Genre = tbGenre.Text
            };
            service.AddBook(book);
            UpdateBooks(service);
        }
    }
}
