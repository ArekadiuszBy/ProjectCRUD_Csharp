using Microsoft.AspNetCore.Mvc;
using ProjektCRUD.Data;
using ProjektCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektCRUD.Controllers
{
    public class BookController : Controller
    {
        //injeciton - przygotowanie lokalnej BD
        private readonly AppDbContext _db;

        //z Startup.cs
        public BookController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Books;

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
        public IActionResult Create(Book obj)
        {
            if (ModelState.IsValid)         //Walidacja, jeśli nie podamy REQUESTED values
            {
                _db.Books.Add(obj);                     //Dodanie itemów do BD
                _db.SaveChanges();                      //zapisywanie zmian w BD
                return RedirectToAction("Index");       //powrót do strony głównej
            }
            return View(obj);
        }

        //GET-Delete po Id
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Books.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Delete po Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Books.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

            //GET-Update po Id
            public IActionResult Update(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var obj = _db.Books.Find(id);

                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }

        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Book obj)
        {
            if (ModelState.IsValid)         //Walidacja, jeśli nie podamy REQUESTED values
            {
                _db.Books.Update(obj);                     //Dodanie itemów do BD
                _db.SaveChanges();                      //zapisywanie zmian w BD
                return RedirectToAction("Index");       //powrót do strony głównej
            }
            return View(obj);
        }
    }
}
