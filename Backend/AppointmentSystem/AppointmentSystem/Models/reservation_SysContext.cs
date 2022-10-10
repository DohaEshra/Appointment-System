using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppointmentSystem.Models
{
    public partial class reservation_SysContext : DbContext
    {
        public reservation_SysContext()
        {
        }

        public reservation_SysContext(DbContextOptions<reservation_SysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=reservation_Sys;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppId);//.HasAnnotation("SqlServer:Identity", "100, 1");

                entity.ToTable("appointment");

                entity.Property(e => e.AppId).HasColumnName("app_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.SpecialityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_appointment_speciality");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_appointment_user");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.SpecialityId);
                entity.ToTable("speciality");

                entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");

                entity.Property(e => e.SpecialityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("speciality_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("F_name");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("l_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
