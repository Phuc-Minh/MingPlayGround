using Microsoft.EntityFrameworkCore;
using MingPlayGround.Data.Interfaces;
using MingPlayGround.Models;
using MingPlayGround.Models.ConjunctionModels;
using System.Linq;

namespace MingPlayGround.Data.Services
{
    public class MuscleExerciseService : IMuscleExerciseService
    {
        private readonly AppDbContext _context;
        private readonly IMuscleGroupService _muscleGroupService;
        private readonly IExerciseService _exerciseService;


        public MuscleExerciseService(AppDbContext context, IMuscleGroupService muscleGroupService, IExerciseService exerciseService)
        {
            _context = context;
            _muscleGroupService = muscleGroupService;
            _exerciseService = exerciseService;
        }

        public async Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByExerciseId(int exerciseId)
            => await _context.MuscleGroups_Exercices
                    .Include(me => me.MuscleGroup)
                    .Where(me => me.ExerciceId.Equals(exerciseId))
                    .ToListAsync();

        public async Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByMuscleId(int muscleId)
            => await _context.MuscleGroups_Exercices
                    .Include(me => me.MuscleGroup)
                    .Where(me => me.MuscleGroupId.Equals(muscleId))
                    .ToListAsync();

        public async Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByMuscleName(string muscleName)
            => await _context.MuscleGroups_Exercices
                    .Where(me => me.MuscleGroup.Name == muscleName)
                    .ToListAsync();

        public async Task<MuscleGroup_Exercice?> GetMuscleGroupExerciseByMuscleNameAndExerciseId(int exerciseId, string muscleName)
            => await _context.MuscleGroups_Exercices
                    .Where(me => me.MuscleGroup.Name == muscleName && me.ExerciceId == exerciseId)
                    .FirstOrDefaultAsync();

        public async Task ChangeMuscleExerciseByExerciseId(int exerciseId, string[] selectedMuscleGroups)
        {
            await AddMuscleExercise(exerciseId, selectedMuscleGroups);
            await RemoveMuscleExercise(exerciseId, selectedMuscleGroups);
        }

        public async Task AddMuscleExercise(int exerciseId, string[] selectedMuscleGroups)
        {
            var muscleRecords = await GetMuscleGroupExerciseByExerciseId(exerciseId);
            foreach (string selectedMuscle in selectedMuscleGroups)
            {
                if (muscleRecords.FirstOrDefault(oldItem => oldItem.MuscleGroup.Name == selectedMuscle) is null)
                {
                    _context.Add(new MuscleGroup_Exercice
                    {
                        Exercice = await _exerciseService.GetExerciseByIdAsync(exerciseId),
                        MuscleGroup = await _muscleGroupService.GetMuscleGroupByName(selectedMuscle)
                    });
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveMuscleExercise(int exerciseId, string[] selectedMuscleGroups)
        {
            var muscleRecords = await GetMuscleGroupExerciseByExerciseId(exerciseId);
            foreach (MuscleGroup_Exercice muscleRecord in muscleRecords)
            {
                if (!selectedMuscleGroups.Contains(muscleRecord.MuscleGroup.Name))
                {
                    _context.Remove(muscleRecord);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
