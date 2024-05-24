using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyD
{
    class TestClass
    {
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            Ytdlp ytdlp = new Ytdlp();
            var foi = ytdlp.Download();
        }
    }

}
