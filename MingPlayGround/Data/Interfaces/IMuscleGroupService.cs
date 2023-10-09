using MingPlayGround.Models;

namespace MingPlayGround.Data.Interfaces
{
    public interface IMuscleGroupService
    {
        Task<MuscleGroup?> GetMuscleGroupByName(string MuscleName);
        Task<List<string>> GetAllMuscleGroupsName();
    }
}
