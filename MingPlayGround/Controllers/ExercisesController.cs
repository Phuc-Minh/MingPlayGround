﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MingPlayGround.Data;
using MingPlayGround.Data.Interfaces;
using MingPlayGround.Data.Services;
using MingPlayGround.Models;
using Utility = MingPlayGround.Utilities.Utility;

namespace MingPlayGround.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMuscleGroupService _muscleGroupService;
        private readonly IMuscleExerciseService _muscleExerciseService;


        public ExercisesController(IExerciseService exerciceService, IMuscleGroupService muscleGroupService, IMuscleExerciseService muscleExerciseService)
        {
            _exerciseService = exerciceService;
            _muscleGroupService = muscleGroupService;
            _muscleExerciseService = muscleExerciseService;
        }

        // GET: Exercices
        public async Task<IActionResult> Index()
        {
            GetExerciceTypes();

            return View(await _exerciseService.GetAllExercisesAsync());
        }

        // GET: Exercices/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var exercice = await _exerciseService.GetExerciseByIdAsync(id);

            return exercice == null ? NotFound() : View(exercice);
        }

        // GET: Exercices/Create
        public IActionResult Create()
        {
            GetExerciceTypes();
            return View();
        }

        // POST: Exercices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DurationSecondes,Repetitions,ExerciceType,Weight,Notes")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                await _exerciseService.CreateExerciseAsync(exercice);
                return RedirectToAction(nameof(Index));
            }
            return View(exercice);
        }

        // GET: Exercices/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var exercice = await _exerciseService.GetExerciseByIdAsync(id);
            if (exercice == null)
                return NotFound();

            GetExerciceTypes();
            await GetMuscleGroups();
            await GetTargetMuscleGroups(id);

            return View(exercice);
        }

        // POST: Exercices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DurationSecondes,Repetitions,ExerciceType,Weight,Notes")] Exercice exercice, string[] selectedMuscleGroups)
        {
            if (id != exercice.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _exerciseService.UpdateExerciseAsync(exercice);

                    await _muscleExerciseService.ChangeMuscleExerciseByExerciseId(id, selectedMuscleGroups);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_exerciseService.ExerciceExists(exercice.Id)) 
                        return NotFound();
                    else
                        throw;
                }

                

                return RedirectToAction(nameof(Index));
            }
            return View(exercice);
        }

        // GET: Exercices/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var exercice = await _exerciseService.GetExerciseByIdAsync(id);
            if (exercice == null)
                return NotFound();

            return View(exercice);
        }

        // POST: Exercices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_exerciseService == null)
                return Problem("Entity set '_exerciseService'  is null.");

            await _exerciseService.DeleteExerciseAsync(id);
            
            return RedirectToAction(nameof(Index));
        }

        private async Task GetMuscleGroups()
            => ViewBag.MuscleGroupNames = await _muscleGroupService.GetAllMuscleGroupsName();
        
        private void GetExerciceTypes()
            => ViewBag.ExerciseType = GetEnumSelectList<MingPlayGround.Data.Enums.ExerciceType>();

        private async Task GetTargetMuscleGroups(int id)
            => ViewBag.TargetMuscleGroups = await _muscleExerciseService.GetTargetMuscleGroupsName(id);

        public static List<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();
        }
    }
}
