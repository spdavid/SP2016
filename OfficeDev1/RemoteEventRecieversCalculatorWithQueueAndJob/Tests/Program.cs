using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteEventRecieversCalculator.Comon.Helpers;
using RemoteEventRecieversCalculator.Comon.Models;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemEventInfo info = new ItemEventInfo();
            info.WebUrl = "https://zalo.sharepoint.com/sites/OD1";
            info.ItemId = 11;
            CalculatorHelper.DoCalculation(info);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
