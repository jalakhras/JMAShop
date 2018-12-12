using JMAShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JMAShop.ViewModels
{
    public class ItemEditViewModel
    {
        public Item Item { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
