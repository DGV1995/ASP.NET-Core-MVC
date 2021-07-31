using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var expenses = _db.Expense;
            return View(expenses);
        }

        // Create-GET
        public IActionResult Create()
        {
            return View();
        }

        // Create-POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _db.Expense.AddAsync(expense);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(expense);
        }
    }
}
