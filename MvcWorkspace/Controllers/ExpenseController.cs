using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;

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
            //IEnumerable<Expense> Expenses = _db.Expenses;
            //foreach (var expense in Expenses)
            //{
            //expense.ExpenseCategory = _db.ExpenseCategories.Find(expense.C_Id); 
            //}

            IEnumerable<Expense> Expenses = _db.Expenses.Include(x => x.ExpenseCategory);

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
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                CategoryDropdown = _db.ExpenseCategories.Select(x => new SelectListItem { Value = x.C_Id.ToString(), Text = x.ExpenseCName })

            };
            
            if (id == 0)
                return View(expenseVM);
            else 
            {
                expenseVM.Expense = _db.Expenses.Find(id);
                return View(expenseVM);
            }
                
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
