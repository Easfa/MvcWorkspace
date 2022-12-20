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
        bool Delete(int id);
        //Category expense
        IEnumerable<Expense> GetCatExpenses();
        //Expenses with catname
        string GetExpensesCatName(int id);
        //Expenses for cat
        IEnumerable<Expense> GetExpensesForCatName();
        //ExpenseCategoriesForSelectList
        IEnumerable<SelectListItem> CategorySelectListItems();

    }
}
