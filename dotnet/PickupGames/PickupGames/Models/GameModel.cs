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

        [Display(Name = "Sport")]
        public IEnumerable<SelectListItem> SportItems { get; set; }

        [Required]
        public string Sport { get; set; }    
    }
}