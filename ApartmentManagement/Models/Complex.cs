using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagement.Models
{
    public class Complex
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string Location { get; set; }
        public string Landlord { get; set; }
        public string PhoneNumber { get; set; }
    }
}
