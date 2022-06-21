using ApartmentManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApartmentManagement.Services
{
    public class DBProperty : IProperty, IUnitData
    {
        public List<Complex> Complexes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<Unit> Units { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private ComplexContext complexContext;

        public DBProperty(ComplexContext _complexContext)
        {
            complexContext = _complexContext;
            
        }
        public void AddComplex(Complex complex)
        { 
           complexContext.Complexes.Add(complex);
           complexContext.SaveChanges();
        }

        public void DeleteComplex(int? id)
        {
            var comp = complexContext.Complexes.Find(id);
            if (comp != null)
            {
                complexContext.Complexes.Remove(comp);
                complexContext.SaveChanges();
            }
        }

        public Complex GetComplex(int? id)
        {
          return complexContext.Complexes.Find(id);
        }

        public void ModifyIncome()
        {

            //var unitsRent = from unit in complexContext.Units
            //                where unit.IsAvailable == false
            //                select unit.Rent;


            //complexContext.SaveChanges();


            //foreach(var unit in complexContext.Units)
            //{


            //    if(unit != null)
            //    {
            //        var complex = complexContext.Complexes.Find(unit.ComplexId);
            //        if (!unit.IsAvailable)
            //        {
            //            complex.TotalIncome += unit.Rent;
            //        }
            //    }

            //}

            var income = 0.0M;

            foreach(var comp in complexContext.Complexes)
            {
                income = 0.0M;
                foreach(var unit in complexContext.Units)
                {
                    if( unit.ComplexId == comp.Id && unit.IsAvailable == false)
                    {
                        income = income + unit.Rent;
                        comp.TotalIncome = income;
                    }
                }
            }
            complexContext.SaveChanges();


        //    var income = 0.0M;

        //    foreach (var comp in complexContext.Complexes)
        //    {
        //        income = 0.0M;
        //        if (comp.Units != null) // if unit.ComplexId == comp.Id
        //        {
        //            foreach (var units in comp.Units)
        //            {
        //                if (!units.IsAvailable)
        //                {
        //                    //if unit is rented out or not available then create a running sum
        //                    income = income + units.Rent;
        //                    comp.TotalIncome = income;
        //                    complexContext.SaveChanges();
        //                }
        //            }
        //        }
        //    }
        }

        public List<Complex> ReadAll()
        {
            return new List<Complex>(complexContext.Complexes);
        }
        public void UpdateComplex(Complex complex)
        {
            var comp = complexContext.Complexes.Find(complex.Id);
            if(comp != null)
            {
                comp.Id = complex.Id;
                comp.Name = complex.Name;
                comp.ImageName = complex.ImageName;
                comp.Location = complex.Location;
                comp.PhoneNumber = complex.PhoneNumber;
                comp.Landlord = complex.Landlord;
            }
            complexContext.SaveChanges();
        }
        
        #region Units Interface Implementation
        List<Unit> IUnitData.ReadAll()
        {
            return new List<Unit>(complexContext.Units);
        }

        public Unit GetUnit(int? id)
        {
            return complexContext.Units.Find(id);
        }

        public void AddUnit(Unit unit)
        {
            complexContext.Units.Add(unit);
            complexContext.SaveChanges();
        }

        public void DeleteUnit(int? id)
        {
            var units = complexContext.Units.Find(id);

            if (units != null)
            {
                complexContext.Units.Remove(units);
                complexContext.SaveChanges();
            }
        }

        public void UpdateUnit(Unit unit)
        {
            var unitDetails = complexContext.Units.Find(unit.Id);
            if (unitDetails != null)
            {
                unitDetails.Id = unit.Id;
                unitDetails.ComplexId = unit.ComplexId;
                unitDetails.UnitNumber = unit.UnitNumber;
                unitDetails.UnitLetter = unit.UnitLetter;
                unitDetails.Beds = unit.Beds;
                unitDetails.Baths = unit.Baths;
                unitDetails.Rent = unit.Rent;
                unitDetails.IsAvailable = unit.IsAvailable;
            }
            complexContext.SaveChanges();
        }
        #endregion
    }
}
