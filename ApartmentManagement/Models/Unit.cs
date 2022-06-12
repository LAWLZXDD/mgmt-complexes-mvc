namespace ApartmentManagement.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public int UnitNumber { get; set; }
        public string UnitLetter { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public decimal Rent { get; set; }
    }
}
