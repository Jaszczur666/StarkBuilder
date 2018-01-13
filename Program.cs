using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StarkBuilder
{
    class Program
    {
        static Multiplets MultiData=new Multiplets();
        static void Main(string[] args)
        {
//            foreach (string arg in args)
//                Console.WriteLine(arg);
            if (args.Length==1)
            {
                string data = System.IO.File.ReadAllText(args[0]);
                //Console.WriteLine(data);
                //Console.WriteLine("___________________________________________________________");
                MultiData.LoadFromString(data);
                //Console.WriteLine(MultiData.ToString());
                MultiData.DumpFiles();
            }
        }
    }
}
