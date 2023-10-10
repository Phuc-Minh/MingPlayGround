using MingPlayGround.Models;

namespace MingPlayGround.Data.Interfaces
{
    public interface IMuscleGroupService
    {
        Task<MuscleGroup?> GetMuscleGroupByName(string MuscleName);
        Task<List<string>> GetAllMuscleGroupsName();
        Task<List<MuscleGroup>> GetAllMuscleGroups();

        Task<MuscleGroup?> GetMuscleGroupById(int id);
        Task CreateMuscleAsync(MuscleGroup muscleGroup);
        Task UpdateMuscleAsync(MuscleGroup muscleGroup);
        Task DeleteMuscleAsync(int id);
        bool MuscleGroupExists(int id);
    }
}
