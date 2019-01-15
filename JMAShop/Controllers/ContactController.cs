using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JMAShop.Controllers
{
    public class ContactController : Controller
    {
        [Route("Contact")]
        [Route("ContactUs")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
