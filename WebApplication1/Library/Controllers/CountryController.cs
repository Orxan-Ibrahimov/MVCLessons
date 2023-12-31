﻿using Library.DataContext;
using Library.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Library.Controllers
{
    public class CountryController : Controller
    {
        readonly LibraryDbContext _context;
        public CountryController(LibraryDbContext context)
        {
            _context = context;
        }
        // GET: CountryController
        public ActionResult Index()
        {
            List<Country> countries = _context.Countries.Include(c => c.Authors).ThenInclude(a => a.Books).ToList();
            return View(countries);

        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            Country country = _context.Countries.Find(id);

            return View(country);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(country);
                    _context.SaveChanges();
                    _context.Dispose();
                }
            }
            catch
            {
                return View();
            }

           return RedirectToAction(nameof(Index));
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _context.Countries.Find(id);

            if (country == null) return View();

            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Country country)
        {
            try
            {
                if (_context.Countries.Contains(country))
                {
                    _context.Countries.Update(country);
                    _context.SaveChanges();
                }           
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _context.Countries.Find(id);

            if (country == null) return View();

            return View(country);
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Country country)
        {
            try
            {
                if (_context.Countries.Contains(country))
                {
                    _context.Countries.Remove(country);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
