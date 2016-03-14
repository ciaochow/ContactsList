using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Model
{
    public class Contact
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use A-Z letters only please")]
        [Required(ErrorMessage = " - Cannot be blank.")]
        //[RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [StringLength(25, ErrorMessage = "Maximum 25 characters exceeded")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use A-Z letters only please")]
        //[RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [StringLength(25, ErrorMessage = "Maximum 25 characters exceeded")]
        [Required(ErrorMessage = " - Cannot be blank.")]
        public string LastName { get; set; }

        [RegularExpression(@"^[2-9]{1}[0-9]{1}[0-9]{8}$", ErrorMessage = " - 10-digit US phone only, 1st digit can't be 0 or 1.")]
        [Required(ErrorMessage = " - Cannot be blank.")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = " - Cannot be blank.")]
        public string Email { get; set; }
    }
}
