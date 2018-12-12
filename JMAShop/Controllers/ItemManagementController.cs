using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMAShop.Models;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JMAShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "DeleteItem")]
    public class ItemManagementController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemManagementController(ItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var items = _itemRepository.Items.OrderBy(p => p.ItemId);
            return View(items);
        }

        public IActionResult AddItem()
        {
            var categories = _categoryRepository.Categories;
            var itemEditViewModel = new ItemEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().CategoryId
            };
            return View(itemEditViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(ItemEditViewModel itemEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.CreateItem(itemEditViewModel.Item);
                return RedirectToAction("Index");
            }
            return View(itemEditViewModel);
        }

        [HttpPost]
        public IActionResult EditItem(ItemEditViewModel itemEditViewModel)
        {
            itemEditViewModel.Item.CategoryId = itemEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _itemRepository.UpdateItem(itemEditViewModel.Item);
                return RedirectToAction("Index");
            }
            return View(itemEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteItem(string itemId)
        {
            return View();
        }

    }
}