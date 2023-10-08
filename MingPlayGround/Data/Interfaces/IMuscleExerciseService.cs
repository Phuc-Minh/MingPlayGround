using MingPlayGround.Models.ConjunctionModels;

namespace MingPlayGround.Data.Interfaces
{
    public interface IMuscleExerciseService
    {
        public Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByExerciseId(int exerciseId);
        public Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByMuscleId(int muscleId);
        public Task<List<MuscleGroup_Exercice>> GetMuscleGroupExerciseByMuscleName(string muscleName);
        public Task<MuscleGroup_Exercice?> GetMuscleGroupExerciseByMuscleNameAndExerciseId(int exerciseId, string muscleName);
        
        public Task ChangeMuscleExerciseByExerciseId(int exerciseId, string[] selectedMuscleGroups);
        public Task AddMuscleExercise(int exerciseId, string[] selectedMuscleGroups);
        public Task RemoveMuscleExercise(int exerciseId, string[] selectedMuscleGroups);
    }
}
