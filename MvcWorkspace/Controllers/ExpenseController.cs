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
            foreach (var expense in Expenses)
            { 
                expense.ExpenseCategory = _db.ExpenseCategories.Find(expense.C_Id); 
            } 
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

        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
                return View(new Expense());
            else
                return View(_db.Expenses.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
                if (expense.Id == 0)
                {
                    _db.Add(expense);
                }
                else
                {
                    _db.Update(expense);
                }
                _db.SaveChanges();

                return RedirectToAction("Index");
        }
    }
}
