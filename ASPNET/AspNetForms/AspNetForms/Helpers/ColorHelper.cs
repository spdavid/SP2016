using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetForms.Helpers
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class ColorHelper
    {
        public static List<Color> GetColors()
        {
            List<Color> colors = new List<Color>();

            colors.Add(new Color() { Id = 1, Name = "Red" });
            colors.Add(new Color() { Id = 2, Name = "Blue" });
            colors.Add(new Color() { Id = 3, Name = "Green" });
            colors.Add(new Color() { Id = 4, Name = "Yellow" });
            colors.Add(new Color() { Id = 5, Name = "Brown" });

            return colors;

        }
    }
}