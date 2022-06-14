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
    public class HomeController : Controller
    {
        private IProperty _property;
        private IUnitData _unitdata;

        public HomeController(IProperty property, IUnitData unitdata)
        {
            _property = property;
            _unitdata = unitdata;
        }

        public IActionResult Index()
        {
            HomeIndexModel model = new HomeIndexModel();
            model.Complexes = _property.ReadAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Complex obj)
        {
            if (ModelState.IsValid)
            {
                _property.AddComplex(obj);
                ViewBag.Message = "Property successfully added";
            }
            return RedirectToAction("Index");
        }
        //TODO
        //Details Will be Redirected to the Unit Controller
        //Will eventually need to query Database to return only units with the matching complex Id number
        [HttpGet]
        public IActionResult Details(int id)
        {
            var comp = _property.GetComplex(id); // get the id of the complex i am working with
            var compUnits = _unitdata.ReadAll(); // get a list of all my current units
            UnitIndexModel model = new UnitIndexModel(); //instantiate new model view for UnitIndex
            model.Units = compUnits.FindAll(items => comp.Id == items.ComplexId); // put the data needed into the model
            ViewBag.ComplexName = comp.Name;
            return View(model); // send it to the view with the model object being passed into the view
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Complex obj = _property.GetComplex(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Complex obj, int id)
        {
            obj.Id = id;
            _property.UpdateComplex(obj);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Complex obj = _property.GetComplex(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Complex obj, int id)
        {
            if(obj.Id == id)
            {
                _property.DeleteComplex(id);
            }
            return RedirectToAction("Index");
        }

        //Error Response
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
