using MingPlayGround.Models.ConjunctionModels;

namespace MingPlayGround.Data.Interfaces
{
    public interface IMuscleExerciseService
    {
        Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByExerciseId(int exerciseId);
        Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByMuscleId(int muscleId);
        Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByMuscleName(string muscleName);
        Task<MuscleGroup_Exercice?> GetMuscleGroupExerciseByMuscleNameAndExerciseId(int exerciseId, string muscleName);
        
        Task ChangeMuscleExerciseByExerciseId(int exerciseId, string[] selectedMuscleGroups);
        Task AddMuscleExercise(int exerciseId, string[] selectedMuscleGroups);
        Task RemoveMuscleExercise(int exerciseId, string[] selectedMuscleGroups);

        Task<List<string>> GetTargetMuscleGroupsName(int id);
    }
}
