using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PickupGames.Models
{
    public class GameModel
    {
        public GameModel()
        {
            SportItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Football",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Basketball",
                    Value = "2"
                }
            };
        }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Sport")]
        public IEnumerable<SelectListItem> SportItems { get; set; }

        [Required]
        public string Sport { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
    }
}