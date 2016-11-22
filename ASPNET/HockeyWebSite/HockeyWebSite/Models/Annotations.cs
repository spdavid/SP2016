using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HockeyWebSite.Models
{

    //[MetadataType(typeof(ItemRequestMetaData))]
    //public partial class ItemRequest
    //{
    //}

    //public class ItemRequestMetaData
    //{
    //    [Required]
    //    public int RequestId { get; set; }

    //    //...
    //}

    [MetadataType(typeof(PlayerAnnotations))]
    public partial class Player{}

    [MetadataType(typeof(PositionAnnotations))]
    public partial class Position { }


    [MetadataType(typeof(TeamAnnotations))]
    public partial class Team { }

    public class PlayerAnnotations
    {
        [Display(Name="Player Name")]
        public string Name { get; set; }

    }

    public class PositionAnnotations
    {
        [Display(Name = "Position Name")]
        public string Name { get; set; }

    }


    public class TeamAnnotations
    {
        [Display(Name = "Team Name")]
        public string Name { get; set; }

    }
}