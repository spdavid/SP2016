using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage="You need to add something here")]
        [StringLength(100, MinimumLength=10)]
        public string Title { get; set; }

        [Display(Name="Year Released")]
        [DataType(DataType.Date, ErrorMessage ="You need a valid date")]
        [DisplayFormat(ApplyFormatInEditMode=true,DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime YearReleased { get; set; }

        public string Genre { get; set; }
        public string Description { get; set; }
    }
}