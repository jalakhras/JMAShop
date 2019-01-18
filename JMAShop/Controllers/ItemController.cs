using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using JMAShop.Filters;
using JMAShop.Models;
using JMAShop.Utility;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JMAShop.Controllers
{
    [ItemNotFoundException]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemReviewRepository _itemReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository , IItemReviewRepository itemReviewRepository, HtmlEncoder htmlEncoder,
            ILogger<ItemController> logger)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _itemReviewRepository = itemReviewRepository;
            _htmlEncoder = htmlEncoder;
            _logger = logger;
        }

        [Route("ListItems")]
        [Route("ListOfIems")]
        [Route("List")]
        public ViewResult List(string category)
        {
            IEnumerable<Item> items;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                items = _itemRepository.Items.OrderBy(p => p.ItemId);
                currentCategory = "All items";
            }
            else
            {
                items = _itemRepository.Items.Where(p => p.Category.CategoryName == category)
                   .OrderBy(p => p.ItemId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new ItemsListViewModel
            {
                Items = items,
                CurrentCategory = currentCategory
            });
        }

        //[Route("Details/{id}")]
        public IActionResult Details(int ItemId)
        {
            var item = _itemRepository.GetItemById(ItemId);
            if (item == null)
            {
                _logger.LogDebug(LogEventIds.GetItemIdNotFound, new Exception("Item not found"), "Item with id {0} not found", ItemId);
                throw new ItemNotFoundException();
            }

            return View(new ItemDetailViewModel() { Item = item});
        }

        //[Route("Details/{id}")]
        [HttpPost]
        public IActionResult Details(int ItemId, string review)
        {
            var item = _itemRepository.GetItemById(ItemId);
            if (item == null)
            {
                _logger.LogWarning(LogEventIds.GetItemIdNotFound, new Exception("Item not found"), "Item with id {0} not found", ItemId);
                throw new ItemNotFoundException();
            }

            //_itemReviewRepository.AddItemReview(new ItemReview() { Item = item, Review = review });

            string encodedReview = _htmlEncoder.Encode(review);
            _itemReviewRepository.AddItemReview(new ItemReview() { Item = item, Review = encodedReview });

            return View(new ItemDetailViewModel() { Item = item });
        }

    }
}

    