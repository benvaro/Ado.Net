using Autofac;
using BookLibrary.BLL.Model;
using BookLibrary.BLL.Services;
using BookLibrary.DAL;
using BookLibrary.DAL.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace BookLibrary.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBookService service;

        public MainWindow()
        {
            InitializeComponent();
            service = new BookService();
            this.DataContext = service.GetBooks().ToList();
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
        }
    }
}
