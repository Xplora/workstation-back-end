using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyReviewConfiguration(this ModelBuilder builder)
    {
        void ConfigureBaseEntity<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : BaseEntity
        {
            entity.Property(e => e.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).IsRequired();
        }
        
        builder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews");
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Rating).IsRequired();
            entity.Property(r => r.Comment).IsRequired().HasMaxLength(1000);
            entity.Property(r => r.ReviewDate).IsRequired().HasColumnType("DATETIME");
                
            entity.Property(r => r.TouristUserId).IsRequired(); 
            entity.Property(r => r.AgencyUserId).IsRequired();  
                
            entity.HasOne(r => r.TouristUser) 
                .WithMany() 
                .HasForeignKey(r => r.TouristUserId) 
                .HasPrincipalKey(u => u.UserId);
                
            entity.HasOne(r => r.Agency) 
                .WithMany() 
                .HasForeignKey(r => r.AgencyUserId) 
                .HasPrincipalKey(a => a.UserId); 

            ConfigureBaseEntity(entity);
        });
        
    }
}