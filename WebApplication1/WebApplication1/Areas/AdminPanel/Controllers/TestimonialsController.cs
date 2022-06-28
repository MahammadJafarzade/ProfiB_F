using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels.TestimonialViewModel;

namespace WebApplication1.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    public class TestimonialsController : Controller
    {
        private AppDbContext _context { get; }

        public TestimonialsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Testimonials.Where(c=>!c.IsDeleted));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimonialsCreateVM testimonials)
        {
            if (!ModelState.IsValid) return View();
            Testimonials cards = new Testimonials
            {
                Img=testimonials.Img,
                Name = testimonials.Name,
                Title=testimonials.Title,
                Description=testimonials.Description,
                Stars=testimonials.Stars
            };
            await _context.Testimonials.AddAsync(cards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
