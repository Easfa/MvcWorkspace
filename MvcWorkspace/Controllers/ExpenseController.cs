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

        public IActionResult AddOrUpdate(int? id)
        {
            if(id == null) 
            {
                return View(new Expense());
            }
            else 
            {
                var ex = _db.Expenses.Find(id);
                if(ex == null || id == 0) return NotFound(); 
                else return View(ex);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
            if (ModelState.IsValid) 
            {
                if(expense.Id == 0) { }
                else 
                {
                    if (_db.Expenses.Find(expense) == null)
                    {
                        _db.Expenses.Add(expense);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else 
                    { 
                        _db.Expenses.Update(expense);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                
            }

            return View(expense);
        }
    }
}
