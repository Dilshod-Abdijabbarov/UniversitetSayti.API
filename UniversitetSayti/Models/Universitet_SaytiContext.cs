using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Universitet_SaytiContext : DbContext
    {
        public Universitet_SaytiContext()
        {
        }

        public Universitet_SaytiContext(DbContextOptions<Universitet_SaytiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chair> Chairs { get; set; }
        public virtual DbSet<ChairEmployee> ChairEmployees { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Science> Sciences { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CJI1HH3\\SQLEXPRESS;Database=Universitet_Sayti;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Chair>(entity =>
            {
                entity.Property(e => e.Chairid).HasColumnName("chairid");

                entity.Property(e => e.Chairemployeeid).HasColumnName("chairemployeeid");

                entity.Property(e => e.Information).HasMaxLength(256);

                entity.Property(e => e.Scienceid).HasColumnName("scienceid");

                entity.HasOne(d => d.Chairemployee)
                    .WithMany(p => p.Chairs)
                    .HasForeignKey(d => d.Chairemployeeid)
                    .HasConstraintName("FK_ChairEmployeesChairs");

                entity.HasOne(d => d.Science)
                    .WithMany(p => p.Chairs)
                    .HasForeignKey(d => d.Scienceid)
                    .HasConstraintName("FK_SciencesChairs");
            });

            modelBuilder.Entity<ChairEmployee>(entity =>
            {
                entity.Property(e => e.Chairemployeeid).HasColumnName("chairemployeeid");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phonenumber).HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rank).HasMaxLength(50);
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.Directionid).HasColumnName("directionid");

                entity.Property(e => e.Chairid).HasColumnName("chairid");

                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Chair)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.Chairid)
                    .HasConstraintName("FK_ChairsDirections");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("FK_GroupsDirections");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Facultyid).HasColumnName("facultyid");

                entity.Property(e => e.Directionid).HasColumnName("directionid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.News).HasMaxLength(250);

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.Directionid)
                    .HasConstraintName("FK_DirectionsFaculties");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("FK_StudentsGroups");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Newsid).HasColumnName("newsid");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.Video).HasMaxLength(250);
            });

            modelBuilder.Entity<Science>(entity =>
            {
                entity.Property(e => e.Scienceid).HasColumnName("scienceid");

                entity.Property(e => e.Information).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Addres).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PasportSeria).HasMaxLength(2);

                entity.Property(e => e.Phonenumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Workerid).HasColumnName("workerid");

                entity.Property(e => e.Addres).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phonenumber).HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
