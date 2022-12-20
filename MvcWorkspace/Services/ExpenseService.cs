using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;

namespace MvcWorkspace.Services
{
    public class ExpenseService : IExpenseService
    {
        private AppDbContext _db;
        public ExpenseService(AppDbContext db) 
        {
            _db = db;
        }
        public void Add(Expense expense)
        {
            _db.Add(expense);
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> CategorySelectListItems()
        {

            return _db.ExpenseCategories.Select(x => new SelectListItem { Value = x.C_Id.ToString(), Text = x.ExpenseCName });

        }

        public bool Delete(int id)
        {
            var expense = _db.Expenses.Find(id);
            if (expense == null || id == 0) return false;
            _db.Expenses.Remove(expense);
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<Expense> GetCatExpenses(int id)
        {
              return _db.Expenses.Where(x => x.C_Id == id);
        }

        public Expense GetExpense(int id)
        {
            return _db.Expenses.Find(id);
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return _db.Expenses.Select(x => x);
        }

        public IEnumerable<Expense> GetExpensesForCatName()
        {
            return _db.Expenses.Include(x => x.ExpenseCategory);
        }

        public string GetExpensesCatName(int id)
        {
            return _db.ExpenseCategories.Find(id).ExpenseCName;
        }

        public void Update(Expense expense)
        {
            _db.Update(expense);
            _db.SaveChanges();
        }
    }
}
