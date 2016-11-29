using LINQPrimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static LINQPrimer.MyExtensions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        List<Plant> plants = new List<Plant>();
        plants.Add(new Plant() { Id = 1, Color = "green", Name = "tree", hasLeaves = true, Height = 100 });
        plants.Add(new Plant() { Id = 2, Color = "blue", Name = "plant1", hasLeaves = false, Height = 1030 });
        plants.Add(new Plant() { Id = 3, Color = "red", Name = "plant2", hasLeaves = true, Height = 1500 });
        plants.Add(new Plant() { Id = 4, Color = "green", Name = "plant3", hasLeaves = false, Height = 1700 });
        plants.Add(new Plant() { Id = 5, Color = "green", Name = "plant4", hasLeaves = true, Height = 200 });
        plants.Add(new Plant() { Id = 6, Color = "green", Name = "plant5", hasLeaves = false, Height = 1100 });
        plants.Add(new Plant() { Id = 7, Color = "red", Name = "plant6", hasLeaves = true, Height = 3 });
        plants.Add(new Plant() { Id = 8, Color = "yellow", Name = "plant7", hasLeaves = true, Height = 33 });
        plants.Add(new Plant() { Id = 9, Color = "green", Name = "plant8", hasLeaves = false, Height = 444 });
        plants.Add(new Plant() { Id = 10, Color = "green", Name = "plant9", hasLeaves = true, Height = 103220 });
        plants.Add(new Plant() { Id = 11, Color = "green", Name = "plant10", hasLeaves = true, Height = 22 });
        plants.Add(new Plant() { Id = 12, Color = "green", Name = "plant11", hasLeaves = true, Height = 44 });
        plants.Add(new Plant() { Id = 13, Color = "green", Name = "plant12", hasLeaves = true, Height = 456 });


        int[] plantids = { 7, 6, 8, 12 };
        plants.Where(p => plantids.Contains(p.Id));


        List<Plant> allWithLeavesOldFashoned = new List<Plant>();

        foreach (Plant foo in plants)
        {
            if (foo.hasLeaves)
            {
                allWithLeavesOldFashoned.Add(foo);
            }
        }




        // lambda
        List<Plant> allWithLeaves = plants.Where(foo => foo.hasLeaves == true).ToList();

        List<Plant> orderedbysize = plants.OrderBy(p => p.Height).ToList();


        // query syntax
        List<Plant> allWithLeaves2 = (from p in plants
                                      where p.hasLeaves == true
                                      select p).ToList();

        List<Plant> orderedbysize2 = (from p in plants
                                      orderby p.Height
                                      select p).ToList();

        var anonClass = (from p in plants
                         where p.Color.ToUpper() == "GREEN"
                         orderby p.Height
                         select new {
                             foo1 = p.Id,
                             bar2 = p.Name + " " + p.Height.ToString()
                         });

        foreach (var item in anonClass)
        {
            Console.WriteLine(item.foo1);
            Console.WriteLine(item.bar2);


        }


        Console.WriteLine(plants[0].Height);
        plants[0].Grow10Cm();
        Console.WriteLine(plants[0].Height);

        string s = "Hello ";
      
        Console.WriteLine(s.AddDavid());


        Console.ReadLine();
    }


   
}