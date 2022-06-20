using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagement.Models
{
    public class Unit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ComplexId { get; set; } //This is my Foreign Key
        public int UnitNumber { get; set; }
        public string UnitLetter { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        [DataType(DataType.Currency)]
        public decimal Rent { get; set; } 
        public bool IsAvailable { get; set; }
    }
}
