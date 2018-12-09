﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JMAShop.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext; 

        public ItemRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
        }
        public IEnumerable<Item> Items
        {
            get
            {
                return _appDbContext.Items.Include(c => c.Category);
            }
        }

        public IEnumerable<Item> ItemsOfTheWeek
        {
            get
            {
                return _appDbContext.Items.Include(c => c.Category).Where(p => p.IsItemOfTheWeek);
            }
        }

        public Item GetItemById(int itemId)
        {
            return _appDbContext.Items.FirstOrDefault(p => p.ItemId == itemId);
        }
    }
}