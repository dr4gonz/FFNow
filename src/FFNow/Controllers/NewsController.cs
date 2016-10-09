using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FFNow.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FFNow.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var news = await NflNews.GetFeeds();
            return View(news);
        }
    }
}
