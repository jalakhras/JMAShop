using JMAShop.Models;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JMAShop.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;

   
        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        [Route("")]
        [Route("Index")]
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ItemsOfTheWeek = _itemRepository.ItemsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
