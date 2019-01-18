using JMAShop.Models;
using JMAShop.Utility;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JMAShop.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IItemRepository itemRepository, ILogger<HomeController> logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }
        [Route("")]
        [Route("Index")]
        public ViewResult Index()
        {
            //Logging
            _logger.LogInformation(LogEventIds.LoadHomepage, "Loading home page");
            var homeViewModel = new HomeViewModel
            {
                ItemsOfTheWeek = _itemRepository.ItemsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
