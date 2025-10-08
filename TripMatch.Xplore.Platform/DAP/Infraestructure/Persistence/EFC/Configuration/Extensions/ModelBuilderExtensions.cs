using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.DAP.Infraestructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyDapConfiguration(this ModelBuilder builder)
    {
        // IAM Context
        
        void ConfigureBaseEntity<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : BaseEntity
        {
            entity.Property(e => e.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).IsRequired();
        }
        
        builder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasIndex(c => c.Name).IsUnique();
        });

        builder.Entity<ExperienceImage>(entity =>
            {
                entity.ToTable("ExperienceImages");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(e => e.Experience)
                    .WithMany(exp => exp.ExperienceImages)
                    .HasForeignKey(e => e.ExperienceId);

                ConfigureBaseEntity(entity); 
            });

        builder.Entity<Include>(entity =>
        {
            entity.ToTable("Includes");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Description).IsRequired();

            entity.HasOne(e => e.Experience)
                .WithMany(exp => exp.Includes)
                .HasForeignKey(e => e.ExperienceId);

            ConfigureBaseEntity(entity); 
        });
        
        builder.Entity<Favorite>(entity =>
        {
            entity.ToTable("Favorites");
            entity.HasKey(f => f.Id);

            entity.Property(f => f.TouristId).IsRequired();
            entity.Property(f => f.ExperienceId).IsRequired();

            entity.HasOne(f => f.Tourist)
                .WithMany()
                .HasForeignKey(f => f.TouristId)
                .HasPrincipalKey(t => t.UserId);

            entity.HasOne(f => f.Experience)
                .WithMany()
                .HasForeignKey(f => f.ExperienceId)
                .HasPrincipalKey(e => e.Id);

            ConfigureBaseEntity(entity);
        });

        builder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedules");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Time).IsRequired();

            entity.HasOne(e => e.Experience)
                .WithMany(exp => exp.Schedules)
                .HasForeignKey(e => e.ExperienceId);

            ConfigureBaseEntity(entity); 
        });
        
        builder.Entity<Experience>(entity =>
        {
            entity.ToTable("Experiences");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasAnnotation("CheckConstraint", "LEN(Title) > 0");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasAnnotation("CheckConstraint", "LEN(Description) > 0");

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(60);

            entity.Property(e => e.Frequencies)
                .HasMaxLength(100);

            entity.Property(e => e.Duration)
                .IsRequired();

            entity.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("DECIMAL(10,2)");

            entity.HasIndex(e => e.Title)
                .IsUnique();
                
            entity.Property(e => e.AgencyUserId).IsRequired(); 
                
            entity.HasOne(e => e.Agency)
                .WithMany(a => a.Experiences) 
                .HasForeignKey(e => e.AgencyUserId) 
                .HasPrincipalKey(a => a.UserId);
                
            ConfigureBaseEntity(entity);
        });
        
        builder.Entity<Experience>()
            .HasOne(e => e.Category)
            .WithMany(c => c.Experiences)
            .HasForeignKey(e => e.CategoryId);
        
    }
}