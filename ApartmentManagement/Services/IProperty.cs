using ApartmentManagement.Models;
using System.Collections.Generic;

namespace ApartmentManagement.Services
{
    public interface IProperty
    {
        List<Complex> Complexes { get; set; }
        List<Complex> ReadAll();
        Complex GetComplex(int? id);
        void AddComplex(Complex complex);
        void DeleteComplex(int? id);
        void UpdateComplex(Complex complex);
        void ModifyIncome();

    }
}
