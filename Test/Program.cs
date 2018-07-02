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
            BLL.BLL _bll = new BLL.BLL();
            _bll.SomeWork();
            Console.WriteLine("Good!");
            Console.ReadLine();
        } 
    }
}
