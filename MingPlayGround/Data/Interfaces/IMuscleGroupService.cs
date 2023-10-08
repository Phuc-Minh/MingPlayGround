using MingPlayGround.Models;

namespace MingPlayGround.Data.Interfaces
{
    public interface IMuscleGroupService
    {
        public Task<MuscleGroup?> GetMuscleGroupByName(string MuscleName);
    }
}
