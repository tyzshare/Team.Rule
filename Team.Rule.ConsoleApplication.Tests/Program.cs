using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.ConsoleApplication.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var sum = GetSum();
            //var sum1 = GetSum1();
            //int result = sum + sum1;
            //Console.WriteLine(result);


            DisplayValue(); //这里不会阻塞  
            Console.WriteLine("MyClass() End.");
            Console.ReadKey();
        }



        //private static int GetSum()
        //{
        //    int sum = 0;
        //    for (int i = 1; i <= 1000; i++)
        //    {
        //        sum = sum + i;
        //    }
        //    return sum;
        //}


        //private static int GetSum1()
        //{
        //    int sum = 0;
        //    for (int i = 1; i <= 1000; i++)
        //    {
        //        sum = sum + i;
        //    }
        //    return sum;
        //}


        public static Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    num1 = num1 / num2;
                }
                return num1;
            });
        }
        public static async void DisplayValue()
        {
            double result = await GetValueAsync(1234.5, 1.01);//此处会开新线程处理GetValueAsync任务，然后方法马上返回  
                                                              //这之后的所有代码都会被封装成委托，在GetValueAsync任务完成时调用  
            Console.WriteLine("Value is : " + result);
        }
    }



}
