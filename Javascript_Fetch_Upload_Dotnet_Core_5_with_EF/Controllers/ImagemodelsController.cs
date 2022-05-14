using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Javascript_Fetch_Upload_Dotnet_Core_5_with_EF.Data;
using Javascript_Fetch_Upload_Dotnet_Core_5_with_EF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Javascript_Fetch_Upload_Dotnet_Core_5_with_EF.Controllers
{
    public class ImagemodelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ImagemodelsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Imagemodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Imagemodels.ToListAsync());
        }

        // GET: Imagemodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagemodel = await _context.Imagemodels
                .FirstOrDefaultAsync(m => m.ImagemodelId == id);
            if (imagemodel == null)
            {
                return NotFound();
            }

            return View(imagemodel);
        }

        // GET: Imagemodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imagemodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImagemodelId,ImagemodelName,ImagemodelComment")] Imagemodel imagemodel, IFormFile Imageitself)
        {

            if (ModelState.IsValid)
            {


                if (Imageitself != null)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "Uploads", Path.GetFileName(Imageitself.FileName));
                    Imageitself.CopyTo(new FileStream(filePath, FileMode.Create));

                    var showPath = Path.Combine("/Uploads", Path.GetFileName(Imageitself.FileName));

                    imagemodel.ImagemodelName = showPath;




                    _context.Add(imagemodel);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imagemodel);





        }

        // GET: Imagemodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagemodel = await _context.Imagemodels.FindAsync(id);
            if (imagemodel == null)
            {
                return NotFound();
            }
            return View(imagemodel);
        }

        // POST: Imagemodels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagemodelId,ImagemodelName,ImagemodelComment")] Imagemodel imagemodel)
        {
            if (id != imagemodel.ImagemodelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagemodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagemodelExists(imagemodel.ImagemodelId))
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
            return View(imagemodel);
        }

        // GET: Imagemodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagemodel = await _context.Imagemodels
                .FirstOrDefaultAsync(m => m.ImagemodelId == id);
            if (imagemodel == null)
            {
                return NotFound();
            }

            return View(imagemodel);
        }

        // POST: Imagemodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagemodel = await _context.Imagemodels.FindAsync(id);
            _context.Imagemodels.Remove(imagemodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagemodelExists(int id)
        {
            return _context.Imagemodels.Any(e => e.ImagemodelId == id);
        }
    }
}
