using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheHotelApp.Data;
using TheHotelApp.Models;

namespace TheHotelApp.Controllers
{
    public class ServiceListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceLists.ToListAsync());
        }

        // GET: ServiceLists/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceList = await _context.ServiceLists
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceList == null)
            {
                return NotFound();
            }

            return View(serviceList);
        }

        // GET: ServiceLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,BasePrice,Description")] ServiceList serviceList)
        {
            if (ModelState.IsValid)
            {
                serviceList.ID = Guid.NewGuid();
                _context.Add(serviceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceList);
        }

        // GET: ServiceLists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceList = await _context.ServiceLists.FindAsync(id);
            if (serviceList == null)
            {
                return NotFound();
            }
            return View(serviceList);
        }

        // POST: ServiceLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,BasePrice,Description")] ServiceList serviceList)
        {
            if (id != serviceList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceListExists(serviceList.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serviceList);
        }

        // GET: ServiceLists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceList = await _context.ServiceLists
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceList == null)
            {
                return NotFound();
            }

            return View(serviceList);
        }

        // POST: ServiceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serviceList = await _context.ServiceLists.FindAsync(id);
            _context.ServiceLists.Remove(serviceList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceListExists(Guid id)
        {
            return _context.ServiceLists.Any(e => e.ID == id);
        }
    }
}
