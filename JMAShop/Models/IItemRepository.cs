using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> Items { get; }
        IEnumerable<Item> ItemsOfTheWeek { get; }
        Item GetItemById(int ItemId);
        void CreateItem(Item item);
        void UpdateItem(Item item);
    }
}
