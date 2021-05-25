using Microsoft.AspNetCore.Mvc;
using ProjektCRUD.Data;
using ProjektCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektCRUD.Controllers
{
    public class ItemController : Controller
    {
        //injeciton - przygotowanie lokalnej BD
        private readonly AppDbContext _db;

        //z Startup.cs
        public ItemController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;

            //wyświetlanie itemów z DB
            return View(objList);   //by sprawdić czy działa -> PPM/Breakpoint - odpalić apke na odpowiedniej podstronie, F10 (next step) - wyświetli się objList o naszej DB
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

            //POST-Create (z Create.cshtml)
        [HttpPost]
            //Walidacja - Wywoływanie funkcji wyłącznie jeśli jesteśmy zalogowani
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)         //Walidacja, jeśli nie podamy REQUESTED values lub ujemne wartości
            {
                _db.Items.Add(obj);                     //Dodanie itemów do BD
                _db.SaveChanges();                      //zapisywanie zmian w BD
                return RedirectToAction("Index");       //powrót do strony głównej
            }
            return View(obj);
        }
    }
}
