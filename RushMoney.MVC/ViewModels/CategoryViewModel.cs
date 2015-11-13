using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RushMoney.MVC.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill field Description")]
        [MaxLength(300, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]
        public string Name { get; set; }
             
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        public virtual IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}