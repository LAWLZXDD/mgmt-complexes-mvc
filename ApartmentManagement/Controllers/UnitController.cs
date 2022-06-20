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
    public class UnitController : Controller
    {
        private IProperty _property;
        private IUnitData _unitdata;
        public UnitController(IProperty property, IUnitData unitdata)
        {
            _property = property;
            _unitdata = unitdata;
        }

        public IActionResult Index(int id)
        {
            var comp = _property.GetComplex(id); // get the id of the complex i am working with
            var compUnits = _unitdata.ReadAll(); // get a list of all my current units
            UnitIndexModel model = new UnitIndexModel(); //instantiate new model view for UnitIndex
            model.Units = compUnits.FindAll(items => comp.Id == items.ComplexId); // put the data needed into the model
            ViewBag.ComplexName = comp.Name;
            ViewBag.ComplexId = comp.Id;
            return View(model); // return the view with the model object being passed into the view
        }
        [HttpGet]
        public IActionResult UnitCreate(int complexId)
        {
            var unitInfo = _unitdata.ReadAll(); 
            var compInfo = _property.GetComplex(complexId);
            ViewBag.AddToComplex = compInfo.Name;
            ViewBag.ComplexId = complexId;
            return View();
        }
        [HttpPost]
        public IActionResult UnitCreate(Unit obj, int id)
        {
            if (ModelState.IsValid)
            {
                _unitdata.AddUnit(obj);
                id = obj.ComplexId;
            }
            return RedirectToAction("Index", "Unit", new {id});
        }

        public IActionResult UnitDetails(int? id)
        {
            var unitDetails = _unitdata.GetUnit(id);
            ViewBag.UnitName = unitDetails.UnitNumber + unitDetails.UnitLetter;
            if(unitDetails == null)
            {
                return null;
            }
            return View(unitDetails);
        }
        [HttpGet]
        public IActionResult UnitEdit(int id)
        {
            Unit obj = _unitdata.GetUnit(id);
            ViewBag.UnitName = obj.UnitNumber + obj.UnitLetter;
            return View(obj);
        }
        [HttpPost]
        public IActionResult UnitEdit(Unit obj, int id)
        {
            obj.Id = id;
            _unitdata.UpdateUnit(obj);

            return RedirectToAction("UnitDetails", new {id});
        }
        public IActionResult UnitDelete(int id)
        {
            var compUnit = _unitdata.GetUnit(id);
            _unitdata.DeleteUnit(id);
            id = compUnit.ComplexId;
            
            return RedirectToAction("Index", new {id});
        }
    }
}
