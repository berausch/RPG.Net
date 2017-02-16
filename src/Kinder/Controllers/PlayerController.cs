using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kinder.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kinder.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Players.Where(x=> x.User.Id == currentUser.Id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            player.User = currentUser;
            _db.Players.Add(player);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            return View(thisPlayer);
        }

   
        public IActionResult Edit(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            return View(thisPlayer);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(players => players.PlayerId == id);
            _db.Players.Remove(thisPlayer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
