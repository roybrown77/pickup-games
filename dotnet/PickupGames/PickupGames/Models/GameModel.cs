using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public DateTime GameDate { get; set; }
        public TimeSpan GameTime { get; set; }
        public string Location { get; set; }
        public int PlayerCount { get; set; }

        [Display(Name = "Distance: ")]
        public string DistanceToLocation { get; set; }

        public TimeSpan Duration { get; set; }

        public string Status { get; set; }

        [Display(Name = "Age Group: ")]
        public string AgeGroup { get; set; }

        public string Notes { get; set; }

        public int Views { get; set; }        
    }
}