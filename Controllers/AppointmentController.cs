using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektCRUD.Controllers
{

    public class AppointmentController : Controller
    {
        //TESTOWY KONTROLER, nic nie robi

        // Odwołanie do /Views/Appointment/Index.cshtml
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Details(int id)
        {
            return Ok("Podałeś ID: {id}" + id);  
        }
    }
}
