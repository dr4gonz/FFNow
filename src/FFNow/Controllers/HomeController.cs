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
            var games = NflGame.GetGames("11");
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
        public IActionResult UpdatePlayers()
        {

            var players = Player.GetPlayers();
            if (_context.Player.Count() != 0)
            {
                foreach (var player in players)
                {
                    var dbPlayer = _context.Player.FirstOrDefault(p => p.Name == player.Name);
                    if(dbPlayer != null)
                    {

                    
                        dbPlayer.FantasyPoints = player.FantasyPoints;
                        dbPlayer.Fumbles = player.Fumbles;
                        dbPlayer.FumblesLost = player.FumblesLost;
                        dbPlayer.PassingAttempts = player.PassingAttempts;
                        dbPlayer.PassingCompletions = player.PassingCompletions;
                        dbPlayer.PassingInterceptions = player.PassingInterceptions;
                        dbPlayer.PassingRating = player.PassingRating;
                        dbPlayer.PassingTouchdowns = player.PassingTouchdowns;
                        dbPlayer.PassingYards = player.PassingYards;
                        dbPlayer.PassingCompletionPercentage = player.PassingCompletionPercentage;
                        dbPlayer.Played = player.Played;
                        dbPlayer.ReceivingTargets = player.ReceivingTargets;
                        dbPlayer.ReceivingTouchdowns = player.ReceivingTouchdowns;
                        dbPlayer.ReceivingYards = player.ReceivingYards;
                        dbPlayer.Receptions = player.Receptions;
                        dbPlayer.RecevingYardsPerReception = player.RecevingYardsPerReception;
                        dbPlayer.RushingAttempts = player.RushingAttempts;
                        dbPlayer.RushingTouchdowns = player.RushingTouchdowns;
                        dbPlayer.RushingYards = player.RushingYards;
                        dbPlayer.RushingYardsPerAttempt = player.RushingYardsPerAttempt;
                        dbPlayer.Started = player.Started;

                        _context.Entry(dbPlayer).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                foreach (var player in players)
                {
                    _context.Player.Add(player);
                    _context.SaveChanges();
                }
            }
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
