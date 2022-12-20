using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public interface IExpenseService
    {
        //GET EXPENSE
        Expense GetExpense(int id);
        //Expenses List 
        IEnumerable<Expense> GetExpenses();
        //Add expense
        void Add(Expense expense);
        //Update expense
        void Update(Expense expense);
        //Delete expense
        void Delete(Expense expense);
        //Category expense
        IEnumerable<Expense> GetCatExpenses(int id);
        //Expenses with catname
        IEnumerable<Expense> GetExpensesWithCatName(int id);
        //Expenses for cat
        IEnumerable<Expense> GetExpensesForCatName(int id);
        //ExpenseCategoriesForSelectList
        IEnumerable<SelectListItem> CategorySelectListItems();

    }
}
