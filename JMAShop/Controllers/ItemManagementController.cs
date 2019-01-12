using System.Collections.Generic;
using System.Linq;
using JMAShop.Models;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JMAShop.Controllers
{
    [Authorize(Roles = "Administrator")]
   // [Authorize(Policy = "DeleteItem")]
    public class ItemManagementController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemManagementController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
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
            //custom validation rules
            if (ModelState.GetValidationState("Item.Price") == ModelValidationState.Valid
                && itemEditViewModel.Item.Price < 0)
                ModelState.AddModelError(nameof(itemEditViewModel.Item.Price), "The price of the item should be higher than 0");

            if (ModelState.IsValid)
            {
                _itemRepository.CreateItem(itemEditViewModel.Item);
                return RedirectToAction("Index");
            }
            return View(itemEditViewModel);
        }

        public IActionResult EditItem([FromQuery]int itemId, [FromHeader(Name = "Accept-Language")] string accept)
        {
            var categories = _categoryRepository.Categories;

            var item = _itemRepository.Items.FirstOrDefault(p => p.ItemId == itemId);

            var itemEditViewModel = new ItemEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Item = item,
                CategoryId = item.CategoryId
            };

            var items = itemEditViewModel.Categories.FirstOrDefault(c => c.Value == item.CategoryId.ToString());
            items.Selected = true;

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
        public IActionResult DeleteItem(int itemId)
        {
            _itemRepository.DeleteItem(itemId);
            return RedirectToAction("index");
        }
        public IActionResult QuickEdit()
        {
            var itemsNames = _itemRepository.Items.Select(i => i.Name).ToList();
            return View(itemsNames);
        }

        [HttpPost]
        public IActionResult QuickEdit(List<string> itemsNames)
        {
            //Do awesome things with the pie names here
            return RedirectToAction("index");
        }

        public IActionResult BulkEditItems()
        {
            var itemNames = _itemRepository.Items.ToList();
            return View(itemNames);
        }

        [HttpPost]
        public IActionResult BulkEditItems(List<Item> Items)
        {
            //Do awesome things with the item here
            return View(Items);
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckIfItemNameAlreadyExists([Bind(Prefix = "Item.Name")]string name)
        {
            var Item = _itemRepository.Items.FirstOrDefault(p => p.Name == name);
            return Item == null ? Json(true) : Json("That Item name is already taken");
        }
    }
}
