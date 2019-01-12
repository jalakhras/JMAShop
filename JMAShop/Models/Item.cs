using JMAShop.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage ="name is Requrid")]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "ShortDescription is Requrid")]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        public decimal Price { get; set; }
        [ValidUrl(ErrorMessage = "That's not a valid URL")]
        public string ImageUrl { get; set; }
        [ValidUrl(ErrorMessage = "That's not a valid URL")]
        public string ImageThumbnailUrl { get; set; }
        public bool IsItemOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ItemReview> ItemReviews { get; set; }

    }
}
