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

        [Column("last_name")]
        public String LastName { get; set; }

        [Column("first_name")]
        public String FirstName { get; set; }

        [Column("tittle")]
        public String Title { get; set; }

        [Column("tittle_of_courtesy")]
        public String TittleOfCourtesy { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("address")]
        public String Address { get; set; }

        [Column("city")]
        public String City { get; set; }

        [Column("region")]
        public String Region { get; set; }

        [Column("postal_code")]
        public int PostalCode { get; set; }

        [Column("country")]
        public String Country { get; set; }

        [Column("home_phone")]
        public int HomePhone { get; set; }

        [Column("extension")]
        public int Extension { get; set; }

        [Column("notes")]
        public String Notes { get; set; }

        [Column("report_to")]
        public String ReportTo { get; set; }

        public ICollection<Orders> Order { get; set; }



    }
}
