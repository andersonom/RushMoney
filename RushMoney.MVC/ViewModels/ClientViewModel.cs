
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RushMoney.MVC.ViewModels
{
    public class ClientViewModel
    {
        [Key]    
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill field First Name")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]        
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill field Last Name")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill field E-mail")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Maximum {0} characters")]
        [EmailAddress(ErrorMessage = "Fill an valid Mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }

        [DisplayName("Last Login")]
        public DateTime LastLogin { get; set; }


        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        public virtual IEnumerable<AccountViewModel> Accounts { get; set; }

    }
}