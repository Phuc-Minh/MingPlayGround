using MingPlayGround.Models;

namespace MingPlayGround.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context is null)
                    return;

                context.Database.EnsureCreated();

                if (!context.MuscleGroups.Any())
                {
                    context.AddRange(new List<MuscleGroup>()
                    {
                        new MuscleGroup(){Name = "Calves"},
                        new MuscleGroup(){Name = "Hamstrings"},
                        new MuscleGroup(){Name = "Quadriceps"},
                        new MuscleGroup(){Name = "Glutes"},
                        new MuscleGroup(){Name = "Biceps"},
                        new MuscleGroup(){Name = "Triceps"},
                        new MuscleGroup(){Name = "Forearms"},
                        new MuscleGroup(){Name = "Trap"},
                        new MuscleGroup(){Name = "Lats"}
                    });
                    context.SaveChanges();
                }

                if(!context.Exercices.Any())
                {
                    context.AddRange(new List<Exercice>()
                    {
                        new Exercice()
                        {
                            Name = "Push Up",
                            ExerciceType = Enums.ExerciceType.Strength,
                            Weight = 0
                        },
                        new Exercice()
                        {
                            Name = "Squat Body Weight",
                            ExerciceType = Enums.ExerciceType.Cardio,
                            Weight = 0
                        },
                        new Exercice()
                        {
                            Name = "Dumbbell Chest Press",
                            ExerciceType = Enums.ExerciceType.Strength,
                            Weight = 35,
                            Repetitions = 20
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
