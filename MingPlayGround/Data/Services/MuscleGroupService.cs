using Microsoft.EntityFrameworkCore;
using MingPlayGround.Data.Interfaces;
using MingPlayGround.Models;

namespace MingPlayGround.Data.Services
{
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly AppDbContext _context;

        public MuscleGroupService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateMuscleAsync(MuscleGroup muscleGroup)
        {
            _context.Add(muscleGroup);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMuscleAsync(int id)
        {
            var muscleGroup = await GetMuscleGroupById(id);
            if (muscleGroup != null)
            {
                _context.MuscleGroups.Remove(muscleGroup);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MuscleGroup>> GetAllMuscleGroups()
            => await _context.MuscleGroups.ToListAsync();

        public async Task<List<string>> GetAllMuscleGroupsName()
            => await _context.MuscleGroups.Select(item => item.Name).ToListAsync();

        public async Task<MuscleGroup?> GetMuscleGroupById(int id)
            => await _context.MuscleGroups
                .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<MuscleGroup?> GetMuscleGroupByName(string MuscleName)
            => await _context.MuscleGroups.Where(mg => mg.Name.Equals(MuscleName)).FirstOrDefaultAsync();

        public bool MuscleGroupExists(int id)
            => (_context.MuscleGroups?.Any(e => e.Id == id)).GetValueOrDefault();

        public async Task UpdateMuscleAsync(MuscleGroup muscleGroup)
        {
            _context.Update(muscleGroup);
            await _context.SaveChangesAsync();
        }
    }
}
