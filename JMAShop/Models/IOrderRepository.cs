﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void CreateItemGiftOrder(ItemGiftOrder itemGiftOrder);
    }
}
