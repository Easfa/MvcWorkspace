using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly AppDbContext _db;
        public ExpenseCategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseCategory> expenseCategories = _db.ExpenseCategories;
            return View(expenseCategories);
        }

        public IActionResult Delete(int id)
        {
            var expensec = _db.ExpenseCategories.Find(id);
            if (expensec == null || id == 0) return NotFound();
            _db.ExpenseCategories.Remove(expensec);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
                return View(new ExpenseCategory());
            else
                return View(_db.ExpenseCategories.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(ExpenseCategory expensec)
        {
            if (expensec.C_Id == 0)
            {
                _db.Add(expensec);
            }
            else
            {
                _db.Update(expensec);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
