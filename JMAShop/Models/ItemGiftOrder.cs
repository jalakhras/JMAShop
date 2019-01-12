using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace JMAShop.Models
{
    public class ItemGiftOrder { 
    [BindNever]
    public int ItemGiftOrderId { get; set; }
    public Item Item { get; set; }

    [Required(ErrorMessage = "Please enter the name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter the address")]
    [StringLength(100)]
    public string Address { get; set; }
}
}
