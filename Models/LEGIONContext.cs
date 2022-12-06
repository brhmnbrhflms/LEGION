using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LEGION.Models
{
    public partial class LEGIONContext : DbContext
    {
        public LEGIONContext()
        {
        }

        public LEGIONContext(DbContextOptions<LEGIONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arendum> Arenda { get; set; } = null!;
        public virtual DbSet<Nabor> Nabors { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=lab116-p;Database=LEGION;User Id=sa;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arendum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DateArenda)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_arenda");

                entity.Property(e => e.PackId).HasColumnName("Pack_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Pack)
                    .WithMany(p => p.Arenda)
                    .HasForeignKey(d => d.PackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Arenda_Nabor");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Arenda)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Arenda_User");
            });

            modelBuilder.Entity<Nabor>(entity =>
            {
                entity.ToTable("Nabor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArendaComputer)
                    .HasMaxLength(50)
                    .HasColumnName("Arenda_computer");

                entity.Property(e => e.DayBegin).HasColumnName("Day_begin");

                entity.Property(e => e.DayEnd).HasColumnName("Day_end");

                entity.Property(e => e.TimeBegin)
                    .HasColumnType("time(0)")
                    .HasColumnName("Time_begin");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("time(0)")
                    .HasColumnName("Time_out");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Card).HasMaxLength(16);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(16);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(11);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
