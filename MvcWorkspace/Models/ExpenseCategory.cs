using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int C_Id { get; set; }

        [Required]
        [Display(Name = "Expense Category Name")]
        public string ExpenseCName { get; set; }
    }
}
