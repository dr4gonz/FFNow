using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FFNow.Data;
using FFNow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FFNow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var games = NflGame.GetGames("5");
            //List<NflGame> gameList = new List<NflGame>();
            //foreach (var game in games)
            //{
            //    gameList.Add(game);
            //}
            return View(games);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> UpdatePlayers()
        {

            var players = Player.GetPlayers();
            foreach (var player in players)
            {
                _context.Player.Add(player);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> UpdateGames()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [NflGames]");
            var games = NflGame.GetGames("5");
            foreach (var game in games)
            {
                _context.NflGames.Add(game);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
