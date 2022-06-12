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
                    ImageName ="Complex1.jpg"
                },
                new Complex()
                {
                    Id = 2,
                    Name = "Village of Apartments",
                    ImageName ="Complex2.jpg"
                },
                new Complex()
                {
                    Id = 3,
                    Name = "Sketchy and Cheap Apartments",
                    ImageName ="Complex3.jpg"
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
