using JMAShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.ViewModels
{
    public class HomeViewModel
    {
       public IEnumerable<Item> ItemsOfTheWeek { get; set; }
    }
}
