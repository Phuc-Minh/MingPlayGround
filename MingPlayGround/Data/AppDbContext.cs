using Microsoft.EntityFrameworkCore;
using MingPlayGround.Models;
using MingPlayGround.Models.ConjunctionModels;

namespace MingPlayGround.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MuscleGroup_Exercice>().HasKey(me => new
            {
                me.MuscleGroupId,
                me.ExerciceId
            });

            modelBuilder.Entity<MuscleGroup_Exercice>().HasOne(m => m.MuscleGroup).WithMany(me => me.MuscleGroup_Exercices).HasForeignKey(m => m.MuscleGroupId);
            modelBuilder.Entity<MuscleGroup_Exercice>().HasOne(m => m.Exercice).WithMany(me => me.MuscleGroup_Exercices).HasForeignKey(m => m.ExerciceId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Exercice> Exercices { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public DbSet<MuscleGroup_Exercice> MuscleGroups_Exercices { get; set; }


    }
}
