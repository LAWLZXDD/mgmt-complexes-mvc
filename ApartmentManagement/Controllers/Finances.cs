using ApartmentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApartmentManagement.Services;
using ApartmentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.Controllers
{
    public class Finances : Controller
    {
        private IProperty _property;
        private IUnitData _unitData;

        public Finances(IProperty property, IUnitData unitdata)
        {
            _property = property;
            _unitData = unitdata;
        }
        public IActionResult Index(Complex obj)
        {
            HomeIndexModel model = new HomeIndexModel();
            model.Complexes = _property.ReadAll(); // this is a list ready to take the data from the interface that executes property.ReadAll()


            var foundUnits = new object();

            for(int i = 0; i < model.Complexes.Count; i++)
            {
                foundUnits = _unitData.Units.FindAll(x => x.ComplexId == model.Complexes[i].Id && x.IsAvailable == false);

            }

            //decimal total = 0;

            //find units that are not available within a complex
            //calculate the not available units' rent price
            //update TotalIncome to be the total running sum per complex
            //one more calculation for adding all total sums per property 



            return View(model);
        }
    }
}
