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
            IEnumerable<ExpenseCategory> ExpenseCategory = _db.ExpenseCategories;
            return View(ExpenseCategory);
        }

        public IActionResult Delete(int id) 
        {
            var expensec = _db.ExpenseCategories.Find(id);
            if (expensec == null || id == 0) return NotFound();
            _db.ExpenseCategories.Remove(expensec);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddOrUpdate(int? id)
        {
            if(id == null) 
            {
                return View(new ExpenseCategory());
            }
            else 
            {
                var ex = _db.ExpenseCategories.Find(id);
                if(ex == null || id == 0) return NotFound(); 
                else return View(ex);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(ExpenseCategory expensec)
        {
            if (ModelState.IsValid) 
            {
                if(expensec.C_Id == 0) { }
                else 
                {
                    if (_db.ExpenseCategories.Find(expensec) == null)
                    {
                        _db.ExpenseCategories.Add(expensec);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else 
                    { 
                        _db.ExpenseCategories.Update(expensec);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                
            }

            return View(expensec);
        }
    }
}
