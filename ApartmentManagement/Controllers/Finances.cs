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
            //calculate total income
            //add method in back in that has a LINQ for Income totals -> 
            _property.ModifyIncome();
            HomeIndexModel model = new HomeIndexModel();
            model.Complexes = _property.ReadAll();
            return View(model);
        }
    }
}
