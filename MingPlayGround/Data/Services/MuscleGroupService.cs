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

        public async Task<List<string>> GetAllMuscleGroupsName()
            => await _context.MuscleGroups.Select(item => item.Name).ToListAsync();
        public async Task<MuscleGroup?> GetMuscleGroupByName(string MuscleName)
            => await _context.MuscleGroups.Where(mg => mg.Name.Equals(MuscleName)).FirstOrDefaultAsync();
    }
}
