using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain 
{
    public partial class ExWebApiAutosDbContext : DbContext
    {
        public ExWebApiAutosDbContext()
        {
        }

        public ExWebApiAutosDbContext(DbContextOptions<ExWebApiAutosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuto> TAuto { get; set; }
        public virtual DbSet<TMarca> TMarca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source = ALEXJONATHAN\SQLEXPRESS; Initial Catalog = Auto; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuto>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("T_auto");

                entity.Property(e => e.AutoId)
                    .HasColumnName("auto_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutoAnioFab)
                    .IsRequired()
                    .HasColumnName("auto_anio_fab")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AutoColor)
                    .IsRequired()
                    .HasColumnName("auto_color")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AutoNroAsientos)
                    .IsRequired()
                    .HasColumnName("auto_nro_asientos")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AutoPlaca)
                    .IsRequired()
                    .HasColumnName("auto_placa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AutoTransmision)
                    .IsRequired()
                    .HasColumnName("auto_transmision")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AutoVersion)
                    .IsRequired()
                    .HasColumnName("auto_version")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaId).HasColumnName("marca_id");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TAuto)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_auto_T_marca");
            });

            modelBuilder.Entity<TMarca>(entity =>
            {
                entity.HasKey(e => e.MarcaId);

                entity.ToTable("T_marca");

                entity.Property(e => e.MarcaId)
                    .HasColumnName("marca_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarcaNombre)
                    .IsRequired()
                    .HasColumnName("marca_nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
