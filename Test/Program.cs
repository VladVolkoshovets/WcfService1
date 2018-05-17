using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseBLL _bll = new DatabaseBLL();
            _bll.SomeWork();
            Console.WriteLine("Good!");
            Console.ReadLine();
        } 
    }
}
