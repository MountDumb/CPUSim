using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Run();
        }

        void Run()
        {
            Programs p = new Programs();
            p.TrySubtracting();

            Console.Read();
        }

        //private void Run()
        //{
        //    //Loop(1);
        //    Recursion(1);
        //}

        //private void Loop(int v)
        //{
        //    while (v > 0)
        //    {
        //        Console.WriteLine(v);
        //        v++;
        //    }
        //}

        //private void Recursion(int v)
        //{
        //    Console.WriteLine(v);
        //    Recursion(++v);
        //}
    }

}
