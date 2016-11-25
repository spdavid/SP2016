using LINQPrimer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQPrimer
{
    public static class MyExtensions
    {
        public static void Grow10Cm(this Plant p)
        {
            p.Height += 10;

        }

        public static string AddDavid(this string s)
        {
            return s + "David";

        }

    }
}
