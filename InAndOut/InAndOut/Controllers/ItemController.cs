using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> items = _db.Item;
            return View(items);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST-Create
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                await _db.Item.AddAsync(item);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        /*[HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var item = await _db.Item.FindAsync(id);

            if (item != null)
            {
                _db.Item.Remove(item);
                await _db.SaveChangesAsync();
            }

            return NotFound();
        }*/
    }
}
