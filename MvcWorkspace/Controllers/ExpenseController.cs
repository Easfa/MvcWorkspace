using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;
using MvcWorkspace.Services;

namespace MvcWorkspace.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _service;
        public ExpenseController(IExpenseService service) 
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetExpenses());
        }

        public IActionResult Delete(int id) 
        {
            bool not = _service.Delete(id);
            if (not) return NotFound();
            return RedirectToAction("Index");
        }

        public IActionResult AddOrUpdate(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                CategoryDropdown = _service.CategorySelectListItems()

            };
            
            if (id == 0)
                return View(expenseVM);
            else 
            {
                expenseVM.Expense = _service.GetExpense(id);
                return View(expenseVM);
            }
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
                if (expense.Id == 0)
                {
                _service.Add(expense);
                }
                else
                {
                    _service.Update(expense);
                }

                return RedirectToAction("Index");
        }

        public IActionResult CategoryExpenses(int cid) 
        {
            IEnumerable<Expense> Expenses = _service.GetExpensesForCatName(cid);
            GetTotal(Expenses);
            ViewBag.ExpenseCat = _service.GetExpensesCatName(cid);
            return View(Expenses);
        }

        private void GetTotal(IEnumerable<Expense> expenses)
        {
            ViewBag.Amounts = 0;
            
            foreach (var exp in expenses) ViewBag.Amounts += exp.Amount;
        }
    }
}
