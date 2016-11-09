using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContollersAndViews.Models
{
    public class HockeyPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime Birthday { get; set; }
        public int Age {
            get {
                DateTime zeroTime = new DateTime(1, 1, 1);
                TimeSpan span = DateTime.Now - Birthday;
                int years = (zeroTime + span).Year - 1;
                return years;
            }
        }

    }
}