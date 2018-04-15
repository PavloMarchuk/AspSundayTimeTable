using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbLayer.Models
{
    public partial class TimeTable_DataContext : DbContext
    {
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<TeachersInSubjects> TeachersInSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TimeTable_Data;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupId).HasColumnName("Group_id");

                entity.Property(e => e.CourseName)
                    .HasColumnName("Course_Name")
                    .HasMaxLength(64);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("Group_Name")
                    .HasMaxLength(64);

                entity.Property(e => e.Specialization).HasMaxLength(64);
            });

            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.HasKey(e => e.LessonId);

                entity.Property(e => e.LessonId).HasColumnName("Lesson_Id");

                entity.Property(e => e.Cabinet)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.GroupId).HasColumnName("Group_id");

                entity.Property(e => e.LessoDatetime)
                    .HasColumnName("Lesso_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lessons__Group_i__31EC6D26");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lessons__Subject__300424B4");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lessons__Teacher__30F848ED");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.GroupId).HasColumnName("Group_id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__Group___25869641");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("Subject_Name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<TeachersInSubjects>(entity =>
            {
                entity.Property(e => e.TeachersInSubjectsId).HasColumnName("TeachersInSubjects_Id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeachersInSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeachersI__Subje__2D27B809");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachersInSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeachersI__Teach__2C3393D0");
            });
        }
    }
}
