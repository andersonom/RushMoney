using System;
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
        
        public int AccountId { get; set; }

        public virtual AccountViewModel Account { get; set; }

        public virtual CategoryViewModel Category { get; set; }

        public int CategoryId { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]        
        public DateTime Date { get; set; }


    }
}
