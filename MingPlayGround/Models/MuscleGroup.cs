using MingPlayGround.Models.ConjunctionModels;
using System.ComponentModel.DataAnnotations;

namespace MingPlayGround.Models
{
    public class MuscleGroup
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<MuscleGroup_Exercice>? MuscleGroup_Exercices { get; set; }
    }
}
