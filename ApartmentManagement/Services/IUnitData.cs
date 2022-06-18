using ApartmentManagement.Models;
using System.Collections.Generic;

namespace ApartmentManagement.Services
{
    public interface IUnitData
    {
        List<Unit> Units { get; set; }
        List<Unit> ReadAll();
        Unit GetUnit(int? id);
        void AddUnit(Unit unit);
        void DeleteUnit(int? id);
        void UpdateUnit(Unit unit);
    }
}
