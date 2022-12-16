using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _db;
        public ExpenseController(AppDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> Expenses = _db.Expenses;
            return View(Expenses);
        }

        public IActionResult Delete(int id) 
        {
            var expense = _db.Expenses.Find(id);
            if (expense == null || id == 0) return NotFound();
            _db.Expenses.Remove(expense);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
