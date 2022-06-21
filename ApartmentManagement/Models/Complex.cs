using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public class Complex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string Location { get; set; }
        public string Landlord { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalIncome { get; set; }

        //Indicates 1 to many relationship: A Complex has multiple units
        public virtual ICollection<Unit> Units { get; set; }
    }
}
