using ContollersAndViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContollersAndViews.Helpers
{
    public class HockeyPlayerHelper
    {

        public static List<HockeyPlayer> players = GetFakeHockyPlayerList();

        public static List<HockeyPlayer> GetFakeHockyPlayerList()
        {
            return new List<HockeyPlayer> {
                new HockeyPlayer( ) {Id=1, Name = "David", Birthday = DateTime.Parse("1979-06-25"), Position = "Goalie" },
                new HockeyPlayer( ) {Id=2, Name = "David2", Birthday = DateTime.Parse("1979-06-25"), Position = "Center" },
                new HockeyPlayer( ) {Id=3, Name = "David3", Birthday = DateTime.Parse("1979-06-25"), Position = "RightWing" },
                new HockeyPlayer( ) {Id=4, Name = "David4", Birthday = DateTime.Parse("1985-06-25"), Position = "LeftWing" },
                new HockeyPlayer( ) {Id=5, Name = "David5", Birthday = DateTime.Parse("1923-06-25"), Position = "LeftDef" },
                new HockeyPlayer( ) {Id=6, Name = "David6", Birthday = DateTime.Parse("1979-06-25"), Position = "RightDef" },
                new HockeyPlayer( ) {Id=7, Name = "David7", Birthday = DateTime.Parse("1979-06-25"), Position = "Center" }
            };
        }


        public static void AddHockeyPlayer(HockeyPlayer newPLayer)
        {
            HockeyPlayer latestplayer = players.OrderByDescending(p => p.Id).FirstOrDefault();
            int newid = latestplayer.Id + 1;
            newPLayer.Id = newid;
            players.Add(newPLayer);
        }

        public static void EditHockeyPlayer(HockeyPlayer updatedplayer)
        {
            HockeyPlayer player = players.Where(p => p.Id == updatedplayer.Id).FirstOrDefault();
            player.Name = updatedplayer.Name;
            player.Position = updatedplayer.Position;
            player.Birthday = updatedplayer.Birthday;
        }

        public static void DeleteHockeyPlayer(int id)
        {
            HockeyPlayer player = players.Where(p => p.Id == id).FirstOrDefault();
            players.Remove(player);
        }
    }
}