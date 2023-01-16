using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_employees")]
    public class Employees
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("last_name")]
        public String LastName { get; set; }

        [Required]
        [Column("first_name")]
        public String FirstName { get; set; }

        [Required]
        [Column("tittle")]
        public String Title { get; set; }

        [Required]
        [Column("tittle_of_courtesy")]
        public String TittleOfCourtesy { get; set; }

        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("address")]
        public String Address { get; set; }

        [Required]
        [Column("city")]
        public String City { get; set; }

        [Required]
        [Column("region")]
        public String Region { get; set; }

        [Required]
        [Column("postal_code")]
        public int PostalCode { get; set; }

        [Required]
        [Column("country")]
        public String Country { get; set; }

        [Required]
        [Column("home_phone")]
        public int HomePhone { get; set; }

        [Required]
        [Column("extension")]
        public int Extension { get; set; }

        [Required]
        [Column("notes")]
        public String Notes { get; set; }

        [Required]
        [Column("report_to")]
        public String ReportTo { get; set; }

        public ICollection<Orders> Order { get; set; }
        public Employees()
        {

        }

        public Employees(POS.ViewModel.EmployeeModel model)
        {
            LastName = model.LastName;
            FirstName = model.FirstName;
            Title = model.Title;
            TittleOfCourtesy = model.TittleOfCourtesy;
            BirthDate = model.BirthDate;
            HireDate = model.HireDate;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            HomePhone = model.HomePhone;
            Extension = model.Extension;
            Notes = model.Notes;
            ReportTo = model.ReportTo;
        }


    }
}
