using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RushMoney.MVC.ViewModels
{
    public class ClientViewModel
    {
        [Key]    
        public int Id { get; set; }

        [Required(ErrorMessage="Fill field First Name")]
        [MaxLength(50,ErrorMessage="Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill field LastName Name")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill field Email")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]      
        [EmailAddress(ErrorMessage= "Fill an valid Mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsActive { get; set; }


    }
}