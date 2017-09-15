using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateGroupSiteMicrosoftGraph
{
    class Program
    {
        static void Main(string[] args)
        {

         Helpers.GroupHelper.CreateUnifedGroup("davidtest6", "davidtest6", "davidtest6", "David@folkuniversitetetsp2016.onmicrosoft.com");


            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
