using Microsoft.AspNetCore.Mvc;
using ApartmentManagement.Models;
using ApartmentManagement.ViewModels;
using ApartmentManagement.Services;

namespace ApartmentManagement.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
