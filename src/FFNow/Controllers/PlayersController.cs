using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FFNow.Data;
using FFNow.Models;

namespace FFNow.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public PlayersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Players
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Player
                .Include(p => p.PlayersTeams).ThenInclude(pt => pt.Team)
                .Include(p => p.UserTeam)
                .OrderBy(player => player.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id, int currentTeamId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.Include(p => p.PlayersTeams)
                .ThenInclude(pt => pt.Team)
                .SingleOrDefaultAsync(m => m.Id == id);
            ViewData["CurrentTeamId"] = currentTeamId;
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            //ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id");
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Position,TeamId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.Include(p => p.PlayersTeams).SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.Include(p => p.PlayersTeams).SingleOrDefaultAsync(m => m.Id == id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetPlayers()
        {
            var players = Player.GetPlayers();
            foreach (var player in players)
            {
                _context.Player.Add(player);
            }
            await _context.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> DetailsFromIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }
    }
}
