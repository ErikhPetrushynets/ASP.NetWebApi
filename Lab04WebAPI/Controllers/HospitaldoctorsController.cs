using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab04WebAPI.Models;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Lab04WebAPI.ViewModels;

namespace Lab04WebAPI.Controllers
{
    //[ApiController]
    [Route("api/HospitalDoctors")]
    public class HospitaldoctorsController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;


        public HospitaldoctorsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Hospitaldoctors
        [HttpGet]
        [SwaggerOperation("GetAllHospitalDoctors")] 
        public async Task<IActionResult> Index()
        {
            if (_context.Hospitaldoctors != null)
            {
                var hospitalDoctors = await _context.Hospitaldoctors.ToListAsync();
                var hospitalDoctorViewModels = _mapper.Map<List<HospitaldoctorViewModel>>(hospitalDoctors);

                return View(hospitalDoctorViewModels);
            }
            else
            {
                return Problem("Entity set 'Context.Hospitaldoctors' is null.");
            }
        }

        // GET: Hospitaldoctors/Details/5
        [HttpGet("Details/{id}")]
        [SwaggerOperation("GetHospitalDoctorById")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospitaldoctors == null)
            {
                return NotFound();
            }

            var hospitaldoctors = await _context.Hospitaldoctors
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (hospitaldoctors == null)
            {
                return NotFound();
            }
            var hospitaldoctorsVM = _mapper.Map<HospitaldoctorViewModel>(hospitaldoctors);

            return View(hospitaldoctorsVM);
        }

        // GET: Hospitaldoctors/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospitaldoctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [SwaggerOperation("CreateHospitalDoctor")]
        [SwaggerResponse(200, "Created", typeof(HospitaldoctorViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> Create([FromForm] HospitaldoctorViewModel hospitaldoctorVM)
        {
            var hospitaldoctors = _mapper.Map<Hospitaldoctors>(hospitaldoctorVM);

            if (ModelState.IsValid)
            {
                _context.Add(hospitaldoctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitaldoctorVM);
        }

        // GET: Hospitaldoctors/Edit/5
        [HttpGet("Edit/{id}")]
        [SwaggerOperation("GetUpdateHospitalDoctorById")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospitaldoctors == null)
            {
                return NotFound();
            }

            var hospitaldoctors = await _context.Hospitaldoctors.FindAsync(id);
            if (hospitaldoctors == null)
            {
                return NotFound();
            }
            var hospitaldoctorsVM = _mapper.Map<HospitaldoctorViewModel>(hospitaldoctors);

            return View(hospitaldoctorsVM);
        }

        // POST: Hospitaldoctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [SwaggerOperation("UpdateHospitalDoctor")]
        public async Task<IActionResult> Edit(int id, [FromForm] HospitaldoctorViewModel hospitaldoctorVM)
        {
            if (id != hospitaldoctorVM.DoctorId)
            {
                return NotFound();
            }
            var hospitaldoctors = _mapper.Map<Hospitaldoctors>(hospitaldoctorVM);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitaldoctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitaldoctorsExists(hospitaldoctors.DoctorId))
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
            return View(hospitaldoctorVM);
        }

        // GET: Hospitaldoctors/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospitaldoctors == null)
            {
                return NotFound();
            }

            var hospitaldoctors = await _context.Hospitaldoctors
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (hospitaldoctors == null)
            {
                return NotFound();
            }
            var hospitaldoctorsVM = _mapper.Map<HospitaldoctorViewModel>(hospitaldoctors);

            return View(hospitaldoctorsVM);
        }

        // POST: Hospitaldoctors/Delete/5
        [HttpPost("Delete/{id}")]
        [SwaggerOperation("DeleteConfirmedHospitalDoctor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospitaldoctors == null)
            {
                return Problem("Entity set 'Context.Hospitaldoctors'  is null.");
            }
            var hospitaldoctors = await _context.Hospitaldoctors.FindAsync(id);
            if (hospitaldoctors != null)
            {
                _context.Hospitaldoctors.Remove(hospitaldoctors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [NonAction]

        private bool HospitaldoctorsExists(int id)
        {
          return (_context.Hospitaldoctors?.Any(e => e.DoctorId == id)).GetValueOrDefault();
        }
    }
}
