using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String TittleOfCourtesy { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public String Address  { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public String Region { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public String Country { get; set; }

        [Required]
        public int HomePhone { get; set; }

        [Required]
        public int Extension { get; set; }

        [Required]
        public String Notes { get; set; }

        [Required]
        public String ReportTo { get; set; }
    }
}
