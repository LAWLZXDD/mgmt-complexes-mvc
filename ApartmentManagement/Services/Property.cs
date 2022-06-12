using ApartmentManagement.Models;
using System.Collections.Generic;

namespace ApartmentManagement.Services
{
    public class Property : IProperty
    {
        public List<Complex> Complexes { get; set; }
        public Property()
        {
            Complexes = new List<Complex>()
            {
                new Complex()
                {
                    Id = 1,
                    Name = "Great Apartments",
                    ImageName ="Complex1.jpg",
                    Location = "Houston",
                    PhoneNumber = "713-345-6789",
                    Landlord = "Doctor Landlord"
                },
                new Complex()
                {
                    Id = 2,
                    Name = "Village of Apartments",
                    ImageName ="Complex2.jpg",
                    Location = "Tuscon",
                    PhoneNumber = "520-000-0001",
                    Landlord = "Misses Landlord"
                },
                new Complex()
                {
                    Id = 3,
                    Name = "Sketchy and Cheap Apartments",
                    ImageName ="Complex3.jpg",
                    Location = "San Diego",
                    PhoneNumber = "619-000-0123",
                    Landlord = "Mister Landlord"
                },
            };
        }

        public void AddComplex(Complex complex)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteComplex(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Complex GetComplex(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Complex> ReadAll()
        {
            return Complexes;
        }

        public void UpdateComplex(Complex complex)
        {
            throw new System.NotImplementedException();
        }
    }
}
