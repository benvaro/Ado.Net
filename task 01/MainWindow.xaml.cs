using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;

namespace task_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate int Calculator(int a, int b);
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator(Add);
            this.Title = "Window thread: " + Thread.CurrentThread.ManagedThreadId.ToString();
        }

        // Action -> void(..16)  -> void Show()
        //Func => Func<...16, bool>  -> bool isEven(int number)
        public int Add(int a, int b)
        {
            Dispatcher.Invoke(() => { Title = "Add: \t" + Thread.CurrentThread.ManagedThreadId; });
            //     Dispatcher.Invoke(ShowThread);
            Thread.Sleep(8000);

            return a + b;
        }
        public void ShowThread()
        {
            Title = "Add: \t" + Thread.CurrentThread.ManagedThreadId;
        }
        public int Mult(int a, int b)
        {
            return a * b;
        }
        public int Sub(int a, int b)
        {
            Thread.Sleep(3000);
            return a - b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IAsyncResult iar = calculator.BeginInvoke(Convert.ToInt32(tbTread.Text), Convert.ToInt32(tbRes.Text), CalculateCallback, null);
        }

        private void CalculateCallback(IAsyncResult ar)
        {
            var result = (AsyncResult)ar;
            var calculator = (Calculator)result.AsyncDelegate;
            int res = calculator.EndInvoke(ar);
            Dispatcher.Invoke(() => { tbRes.Text = res.ToString(); });
        }

        private void Button_ClickPlus(object sender, RoutedEventArgs e)
        {
            calculator = Add;
        }

        private void Button_ClickSub(object sender, RoutedEventArgs e)
        {
            calculator = Sub;
        }

        private void Button_ClickMult(object sender, RoutedEventArgs e)
        {
            calculator = Mult;
        }
    }
}