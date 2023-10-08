using MingPlayGround.Models;

namespace MingPlayGround.Data.Interfaces
{
    public interface IExerciseService
    {
        Task<Exercice?> GetExerciseByIdAsync(int id);
        Task<List<Exercice>> GetAllExercisesAsync();
        Task CreateExerciseAsync(Exercice exercice);
        Task UpdateExerciseAsync(Exercice exercice);
        Task DeleteExerciseAsync(int id);
    }
}
