using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMAShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace JMAShop.Controllers
{
    public class ItemGiftController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public ItemGiftController(IItemRepository pieRepository, IOrderRepository orderRepository)
        {
            _itemRepository = pieRepository;
            _orderRepository = orderRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public IActionResult Index(ItemGiftOrder itemGiftOrder)
        {
            var itemOfTheMonth = _itemRepository.ItemsOfTheWeek.FirstOrDefault();

            if (itemOfTheMonth != null)
            {
                itemGiftOrder.Item = itemOfTheMonth;
                _orderRepository.CreateItemGiftOrder(itemGiftOrder);
                return RedirectToAction("ItemGiftOrderComplete");
            }

            return View();
        }
        [Route("GiftOrderComplete")]
        [Route("ItemGiftOrderComplete")]
        public IActionResult ItemGiftOrderComplete()
        {
            ViewBag.ItemGiftOrderCompleteMessage = HttpContext.User.Identity.Name +
                                                  ", thanks for the order. Your friend will soon receive the pie!";
            return View();
        }
    }
}
