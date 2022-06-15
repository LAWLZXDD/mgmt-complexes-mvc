using ApartmentManagement.Models;
using System.Collections.Generic;

namespace ApartmentManagement.Services
{
    public class AptUnit : IUnitData
    {
        public List<Unit> Units { get; set; }

        public AptUnit()
        {
            Units = new List<Unit>()
            {
                new Unit()
                {
                    Id = 1,
                    ComplexId = 1,
                    UnitNumber = 10,
                    UnitLetter = "A",
                    Beds = 3,
                    Baths = 2,
                    Rent = 1500.00M
                },
                new Unit()
                {
                    Id = 2,
                    ComplexId = 1,
                    UnitNumber = 10,
                    UnitLetter = "B",
                    Beds = 4,
                    Baths = 3,
                    Rent = 1900.00M
                },
                new Unit()
                {
                    Id = 3,
                    ComplexId = 2,
                    UnitNumber = 20,
                    UnitLetter = "A",
                    Beds = 1,
                    Baths = 1,
                    Rent = 1200.00M
                },
                new Unit()
                {
                    Id = 4,
                    ComplexId = 3,
                    UnitNumber = 30,
                    UnitLetter = "A",
                    Beds = 1,
                    Baths = 1,
                    Rent = 3000.00M
                }

            };
        }
        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }

        public void DeleteUnit(int? unit)
        {
            throw new System.NotImplementedException();
        }

        public Unit GetUnit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return Units.Find(x => x.Id == id);
            }
        }

        public List<Unit> ReadAll()
        {
            return Units;
        }

        public void UpdateUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }
    }
}
