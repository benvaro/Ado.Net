using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_AsyncDelegate
{
    //1

    class Program
    {
        //2
        public delegate int Calculator(int a, int b);
        static void Main(string[] args)
        {
            //3
            //   SqlCommand command;
            //BeginAction
            //EndAction
            Console.WriteLine("Main: \t" + Thread.CurrentThread.ManagedThreadId);
            Calculator calculator = new Calculator(Add);
            //   Console.WriteLine(calculator(4,7));
            //  int res = calculator.Invoke(4, 7);
            //  Console.WriteLine(res);
            //     res = Add(4, 7);

            string hello = "hello";

            IAsyncResult iar = calculator.BeginInvoke(4, 7, CalculateCallback, hello);
            //while (!iar.IsCompleted)
            //{
            //    Console.WriteLine("Main works....");
            //    Thread.Sleep(1000);
            //}
          
            // Отримати результат методу з іншого методу
            //int res = calculator.EndInvoke(iar);
            //Console.WriteLine(res);
            Console.ReadLine();

        }
        //interface IAsyncResult
        // class AsyncResult: IAsyncResult
        // 
        private static void CalculateCallback(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar; //?
            Console.WriteLine("Ended!!!!" + result.AsyncState);
            Calculator calculator = (Calculator)result.AsyncDelegate;
            int res = calculator.EndInvoke(ar);
            Console.WriteLine("Res: " + res);
        }

        // int  (int, int)
        public static int Add(int a, int b)
        {
            Console.WriteLine("Add: \t" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);

            return a + b;
        }
        public static int Mult(int a, int b)
        {
            return a * b;
        }
        public static int Sub(int a, int b)
        {
            Thread.Sleep(3000);
            return a - b;
        }
    }
}
