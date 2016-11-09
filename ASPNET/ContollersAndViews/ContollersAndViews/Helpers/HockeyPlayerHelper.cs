using ContollersAndViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContollersAndViews.Helpers
{
    public class HockeyPlayerHelper
    {

        public static List<HockeyPlayer> GetFakeHockyPlayerList()
        {
            return new List<HockeyPlayer> {
                new HockeyPlayer( ) { Name = "David", Birthday = DateTime.Parse("1979-06-25"), Position = "Goalie" },
                new HockeyPlayer( ) { Name = "David2", Birthday = DateTime.Parse("1979-06-25"), Position = "Center" },
                new HockeyPlayer( ) { Name = "David3", Birthday = DateTime.Parse("1979-06-25"), Position = "RightWing" },
                new HockeyPlayer( ) { Name = "David4", Birthday = DateTime.Parse("1985-06-25"), Position = "LeftWing" },
                new HockeyPlayer( ) { Name = "David5", Birthday = DateTime.Parse("1923-06-25"), Position = "LeftDef" },
                new HockeyPlayer( ) { Name = "David6", Birthday = DateTime.Parse("1979-06-25"), Position = "RightDef" },
                new HockeyPlayer( ) { Name = "David7", Birthday = DateTime.Parse("1979-06-25"), Position = "Center" }
            };
        }
    }
}