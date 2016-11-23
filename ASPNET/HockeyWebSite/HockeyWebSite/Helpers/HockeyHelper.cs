using HockeyWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyWebSite.Helpers
{
    public class HockeyHelper
    {
        public static void TradePlayer(int playerId, int newTeamId)
        {
            HockeyEntities db = new HockeyEntities();
            Player player = db.Players.Where(p => p.Id == playerId).FirstOrDefault();
            player.TeamId = newTeamId;
            db.SaveChanges();
        }
    }
}