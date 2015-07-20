using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace RushMoney.MVC.ViewModels
{
    public class TransactionViewModel
    {
        [Key ]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill field Description")]
        [MaxLength(300, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Fill field value")]        
        [Range(typeof(decimal), "0", "999999999999")]
        public decimal Value { get; set; }
      
        [DisplayName("Active?")]
        public bool IsActive { get; set; }
        
        public int ClientId { get; set; }

        public virtual ClientViewModel Client { get; set; }
    }
}
