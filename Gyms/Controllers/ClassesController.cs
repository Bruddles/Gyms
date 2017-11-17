using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gyms.Models;

namespace Gyms.Controllers
{
    public class ClassesController : Controller
    {
        private readonly GymsContext _context;

        public ClassesController(GymsContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Class.Include(c => c.Instructor).ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id, string clientSearchString)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class @class = await _context.Class.Include(c => c.Instructor)
                .Include(c => c.ClassAttendance)
                .ThenInclude(ca => ca.Client)
                .SingleOrDefaultAsync(m => m.ID == id)
                .ConfigureAwait(false);

            if (@class == null)
            {
                return NotFound();
            }

            List<Client> clients = await _context.Client
                .Where(c => (c.FirstName.Contains(clientSearchString ?? "") 
                        || c.Surname.Contains(clientSearchString ?? "")) 
                    && !@class.ClassAttendance.Any(ca => ca.ClassId == id && ca.ClientId == c.ID))
                .ToListAsync().ConfigureAwait(false);


            ViewBag.clientSearchStringName = clientSearchString;

            return View(new ClassViewModel { Class = @class, Clients = clients });
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            GetInstructorSelectList();
            return View();
        }

        

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,InstructorID,Duration,Date")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@class);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.Include(c => c.Instructor).SingleOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }
            
            GetInstructorSelectList(@class.Instructor);

            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,InstructorID,Duration,Date")] Class @class)
        {
            if (id != @class.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ID))
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
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.Include(c => c.Instructor)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Class.SingleOrDefaultAsync(m => m.ID == id);
            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.ID == id);
        }

        private void GetInstructorSelectList(Instructor selectedInstructor = null)
        {
            ViewBag.InstructorID = new SelectList(
                _context.Instructor.AsNoTracking().OrderBy(i => i.Surname).Select(i => i).ToArray(),
                "ID",
                "FullName",
                selectedInstructor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClient(int ID, int clientID)
        {
            ClassAttendance classAttendance = new ClassAttendance
            {
                Class = await _context.Class.SingleAsync(c => c.ID == ID).ConfigureAwait(false),
                Client = await _context.Client.SingleAsync(c => c.ID == clientID).ConfigureAwait(false)
            };

            _context.ClassAttendance.Add(classAttendance);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToAction(nameof(Details), new { ID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveClient(int ID, int clientID)
        {
            var classAttendance = await _context.ClassAttendance
                .SingleOrDefaultAsync(ca => ca.Class.ID == ID && ca.Client.ID == clientID).ConfigureAwait(false);
            
            _context.ClassAttendance.Remove(classAttendance);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            
            return RedirectToAction(nameof(Details), new {ID});
        }
    }
}
