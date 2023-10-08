using MingPlayGround.Data.Enums;
using MingPlayGround.Models.ConjunctionModels;
using System.ComponentModel.DataAnnotations;
namespace MingPlayGround.Models
{
    public class Exercice
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an exercice name.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Exercice name must be between 3 and 255 characters.")]
        public required string Name { get; set; }

        [Range(0, 1000, ErrorMessage = "Duration must be between 0 and 1000 secondes.")]
        public int? DurationSecondes { get; set; }

        [Range(0, 1000, ErrorMessage = "Duration must be between 0 and 1000 secondes.")]
        public int? Repetitions { get; set; }

        [Required(ErrorMessage = "Please select the exercice type.")]
        public required ExerciceType ExerciceType { get; set; }

        [Required(ErrorMessage = "Please add a weight.")]
        [Range(0, 1000, ErrorMessage = "Weight must be between 0(body weight) and 1000lb")]
        public required int Weight { get; set; }

        [Display(Name = "Notes")]
        [StringLength(1000, ErrorMessage = "Notes can have a maximum of 1000 characters.")]
        public string? Notes { get; set; }

        public List<MuscleGroup_Exercice>? MuscleGroup_Exercices { get; set; }
    }
}
