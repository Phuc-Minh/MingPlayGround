using Microsoft.EntityFrameworkCore;
using MingPlayGround.Data.Interfaces;
using MingPlayGround.Models;

namespace MingPlayGround.Data.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly AppDbContext _context;

        public ExerciseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Exercice?> GetExerciseByIdAsync(int id)
        {
            return await _context.Exercices.FindAsync(id);
        }

        public async Task<List<Exercice>> GetAllExercisesAsync()
        {
            return await _context.Exercices.ToListAsync();
        }

        public async Task CreateExerciseAsync(Exercice exercice)
        {
            _context.Add(exercice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExerciseAsync(Exercice exercice)
        {
            _context.Update(exercice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(int id)
        {
            var exercice = await GetExerciseByIdAsync(id);
            if (exercice != null)
            {
                _context.Remove(exercice);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExerciceExists(int id)
            => (_context.Exercices?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
