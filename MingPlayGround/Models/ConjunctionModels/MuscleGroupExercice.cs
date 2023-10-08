using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingPlayGround.Models.ConjunctionModels
{
    public class MuscleGroup_Exercice
    {
        [ForeignKey("Exercice")]
        public int ExerciceId { get; set; }
        public required Exercice Exercice { get; set; }

        [ForeignKey("MuscleGroup")]
        public int MuscleGroupId { get; set; }
        public required MuscleGroup MuscleGroup { get; set; }
    }
}
