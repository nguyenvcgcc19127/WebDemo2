namespace WebDemo2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Training : DbContext
    {
        public Training()
            : base("name=Training")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Trainee_Course> Trainee_Course { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Trainer_Course> Trainer_Course { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Category_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Category_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Course_Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Course_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Course_Category)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Trainee_Course)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Trainer_Course)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Staff_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Staff_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Topic_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Topic_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Trainee_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Trainee_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Education)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .HasMany(e => e.Trainee_Course)
                .WithRequired(e => e.Trainee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainee_Course>()
                .Property(e => e.No)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee_Course>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee_Course>()
                .Property(e => e.Trainee_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee_Course>()
                .Property(e => e.Trainee_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Trainer_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Trainer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Specialty)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.Trainer_Course)
                .WithRequired(e => e.Trainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer_Course>()
                .Property(e => e.No)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer_Course>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer_Course>()
                .Property(e => e.Trainer_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer_Course>()
                .Property(e => e.Trainer_Name)
                .IsUnicode(false);
        }
    }
}
