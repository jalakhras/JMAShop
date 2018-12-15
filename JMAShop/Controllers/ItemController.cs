using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using JMAShop.Models;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JMAShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemReviewRepository _itemReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository , IItemReviewRepository itemReviewRepository, HtmlEncoder htmlEncoder)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _itemReviewRepository = itemReviewRepository;
            _htmlEncoder = htmlEncoder;
        }

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

        public IActionResult Details(int ItemId)
        {
            var item = _itemRepository.GetItemById(ItemId);
            if (item == null)
                return NotFound();

            return View(new ItemDetailViewModel() { Item = item});
        }

        [HttpPost]
        public IActionResult Details(int ItemId, string review)
        {
            var item = _itemRepository.GetItemById(ItemId);
            if (item == null)
                return NotFound();

            //_itemReviewRepository.AddItemReview(new ItemReview() { Item = item, Review = review });

            string encodedReview = _htmlEncoder.Encode(review);
            _itemReviewRepository.AddItemReview(new ItemReview() { Item = item, Review = encodedReview });

            return View(new ItemDetailViewModel() { Item = item });
        }

    }
}

    