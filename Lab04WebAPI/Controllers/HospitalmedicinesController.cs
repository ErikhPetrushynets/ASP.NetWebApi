using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab04WebAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using Lab04WebAPI.ViewModels;
using AutoMapper;

namespace Lab04WebAPI.Controllers
{
    [ApiController]
    [Route("api/HospitalMedicines")]
    public class HospitalmedicinesController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;


        public HospitalmedicinesController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        // GET: Hospitalmedicines
        [HttpGet]
        [SwaggerOperation("GetAllHospitalMedicines")] 

        public async Task<IActionResult> Index()
        {
            if (_context.Hospitalmedicines != null)
            {
                var Hospitalmedicines = await _context.Hospitalmedicines.ToListAsync();
                var hospitalMedicinesViewModels = _mapper.Map<List<HospitalmedicineViewModel>>(Hospitalmedicines);

                return Json(hospitalMedicinesViewModels);
            }
            else
            {
                return Problem("Entity set 'Context.Hospitalmedicines' is null.");
            }
        }

        // GET: Hospitalmedicines/Details/5
     
        [HttpGet("Details/{id}")]
        [SwaggerOperation("GetHospitalMedicineById")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospitalmedicines == null)
            {
                return NotFound();
            }

            var hospitalmedicine = await _context.Hospitalmedicines
                .FirstOrDefaultAsync(m => m.MedicineId == id);
            if (hospitalmedicine == null)
            {
                return NotFound();
            }
            var hospitalmedicineVM = _mapper.Map<HospitalmedicineViewModel>(hospitalmedicine);

            return Json(hospitalmedicineVM);
        }
        [HttpGet("Create")]
        // GET: Hospitalmedicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospitalmedicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // GET api/values
        
        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Get Hospital Medicine by ID", Description = "Get details of a specific hospital medicine by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully added!", typeof(HospitalmedicineViewModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request, problem somewhere")]
        public async Task<IActionResult> Create([FromBody] HospitalmedicineViewModel hospitalmedicineVM){

            var hospitalmedicine = _mapper.Map<Hospitalmedicines>(hospitalmedicineVM);

            if (ModelState.IsValid)
            {
                _context.Add(hospitalmedicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Json(hospitalmedicineVM);
        }

        // GET: Hospitalmedicines/Edit/5
        [HttpGet("Edit/{id}")]
        [SwaggerOperation("GetUpdateHospitalMedicineById")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospitalmedicines == null)
            {
                return NotFound();
            }

            var hospitalmedicine = await _context.Hospitalmedicines.FindAsync(id);
            if (hospitalmedicine == null)
            {
                return NotFound();
            }
            var hospitalmedicineVM = _mapper.Map<HospitalmedicineViewModel>(hospitalmedicine);

            return Json(hospitalmedicineVM);
        }

        // POST: Hospitalmedicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [SwaggerOperation("UpdateHospitalMedicine")]
        public async Task<IActionResult> Edit(int id, [FromBody] HospitalmedicineViewModel hospitalmedicineVM)
        {
            if (id != hospitalmedicineVM.MedicineId)
            {
                return NotFound();
            }
            var hospitalmedicine = _mapper.Map<Hospitalmedicines>(hospitalmedicineVM);


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitalmedicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalmedicineExists(hospitalmedicine.MedicineId))
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
            return Json(hospitalmedicineVM);
        }

        // GET: Hospitalmedicines/Delete/5
        [HttpGet("Delete/{id}")]
        [SwaggerOperation("DeleteHospitalMedicine")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospitalmedicines == null)
            {
                return NotFound();
            }

            var hospitalmedicine = await _context.Hospitalmedicines
                .FirstOrDefaultAsync(m => m.MedicineId == id);
            if (hospitalmedicine == null)
            {
                return NotFound();
            }
            var hospitalmedicineVM = _mapper.Map<HospitalmedicineViewModel>(hospitalmedicine);


            return Json(hospitalmedicineVM);
        }

        // POST: Hospitalmedicines/Delete/5
        [HttpPost("Delete/{id}")]
        [SwaggerOperation("DeleteConfirmedHospitalMedicine")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospitalmedicines == null)
            {
                return Problem("Entity set 'Context.Hospitalmedicines' is null.");
            }
            var hospitalmedicine = await _context.Hospitalmedicines.FindAsync(id);
            if (hospitalmedicine != null)
            {
                _context.Hospitalmedicines.Remove(hospitalmedicine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [NonAction]
        private bool HospitalmedicineExists(int id)
        {
          return (_context.Hospitalmedicines?.Any(e => e.MedicineId == id)).GetValueOrDefault();
        }
    }
}
