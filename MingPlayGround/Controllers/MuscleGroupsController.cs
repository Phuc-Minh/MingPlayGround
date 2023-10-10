using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MingPlayGround.Data;
using MingPlayGround.Data.Interfaces;
using MingPlayGround.Data.Services;
using MingPlayGround.Models;

namespace MingPlayGround.Controllers
{
    public class MuscleGroupsController : Controller
    {
        private readonly IMuscleGroupService _muscleGroupService;

        public MuscleGroupsController(IMuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }

        // GET: MuscleGroups
        public async Task<IActionResult> Index()
        {
              return _muscleGroupService != null ? 
                          View(await _muscleGroupService.GetAllMuscleGroups()) :
                          Problem("Entity set '_muscleGroupService'  is null.");
        }

        // GET: MuscleGroups/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (_muscleGroupService == null)
                return NotFound();

            var muscleGroup = await _muscleGroupService.GetMuscleGroupById(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            return View(muscleGroup);
        }

        // GET: MuscleGroups/Create
        public IActionResult Create()
            => View();

        // POST: MuscleGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MuscleGroup muscleGroup)
        {
            if (ModelState.IsValid)
            {
                await  _muscleGroupService.CreateMuscleAsync(muscleGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(muscleGroup);
        }

        // GET: MuscleGroups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (_muscleGroupService == null)
                return NotFound();

            var muscleGroup = await _muscleGroupService.GetMuscleGroupById(id);
            if (muscleGroup == null)
                return NotFound();

            return View(muscleGroup);
        }

        // POST: MuscleGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MuscleGroup muscleGroup)
        {
            if (id != muscleGroup.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _muscleGroupService.UpdateMuscleAsync(muscleGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_muscleGroupService.MuscleGroupExists(muscleGroup.Id))
                        return NotFound();
                    else
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(muscleGroup);
        }

        // GET: MuscleGroups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_muscleGroupService == null)
                return NotFound();

            var muscleGroup = await _muscleGroupService.GetMuscleGroupById(id);

            if (muscleGroup == null)
                return NotFound();

            return View(muscleGroup);
        }

        // POST: MuscleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_muscleGroupService == null)
                return Problem("Entity set '_muscleGroupService'  is null.");

            await _muscleGroupService.DeleteMuscleAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
