using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Helpers
{
    public class GameHelper
    {

        public static List<Game> Games = GetFakeGameList();

        public static List<Game> GetFakeGameList()
        {
            return new List<Game> {
                new Game( ) {Id=1, Title = "Game", YearReleased = DateTime.Parse("1979-06-25"), Genre = "RPG", Description= "some description" },
                new Game( ) {Id=2, Title = "Game2", YearReleased = DateTime.Parse("1979-06-25"), Genre = "Strategy",  Description= "some description" },
                new Game( ) {Id=3, Title = "Game3", YearReleased = DateTime.Parse("1979-06-25"), Genre = "RPG",  Description= "some description" },
                new Game( ) {Id=4, Title = "Game4", YearReleased = DateTime.Parse("1985-06-25"), Genre = "FPS",  Description= "some description" },
                new Game( ) {Id=5, Title = "Game5", YearReleased = DateTime.Parse("1923-06-25"), Genre = "RPG", Description= "some description" },
                new Game( ) {Id=6, Title = "Game6", YearReleased = DateTime.Parse("1979-06-25"), Genre = "MMO",  Description= "some description" },
                new Game( ) {Id=7, Title = "Game7", YearReleased = DateTime.Parse("1979-06-25"), Genre = "RPG", Description= "some description" }
            };
        }

        public static Game GetGameById(int id)
        {
           return Games.Where(g => g.Id == id).FirstOrDefault();
        }

        public static void AddGame(Game newGame)
        {
            Game latestGame = Games.OrderByDescending(p => p.Id).FirstOrDefault();
            int newid = latestGame.Id + 1;
            newGame.Id = newid;
            Games.Add(newGame);
        }

        public static void EditGame(Game updatedGame)
        {
            Game Game = Games.Where(p => p.Id == updatedGame.Id).FirstOrDefault();
            Game.Title = updatedGame.Title;
            Game.Genre = updatedGame.Genre;
            Game.Description = updatedGame.Description;
            Game.YearReleased = updatedGame.YearReleased;

        }

        public static void DeleteGame(int id)
        {
            Game Game = Games.Where(p => p.Id == id).FirstOrDefault();
            Games.Remove(Game);
        }

        public static List<Game> GetLatestGames(int amount)
        {
          return Games.OrderByDescending(g => g.YearReleased).Take(amount).ToList();
        }
    
}
}