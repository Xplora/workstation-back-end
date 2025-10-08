using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.ARM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyArmConfiguration(this ModelBuilder builder)
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

        
        builder.Entity<Booking>(entity =>
        {
            entity.ToTable("Bookings"); 
            entity.HasKey(b => b.Id);   
            entity.Property(b => b.BookingDate).IsRequired().HasColumnType("DATETIME");
            entity.Property(b => b.NumberOfPeople).IsRequired();
            entity.Property(b => b.Status).IsRequired().HasMaxLength(50);
            entity.Property(b => b.Price).IsRequired(); 
            entity.Property(b => b.Time)
                .IsRequired()         
                .HasMaxLength(10); 
            entity.HasOne(b => b.Experience) 
                .WithMany() 
                .HasForeignKey(b => b.ExperienceId) 
                .IsRequired(); 
            ConfigureBaseEntity(entity);
            entity.Property(b => b.TouristId)
                .IsRequired(); 
            entity.HasOne(b => b.Tourist)
                .WithMany() 
                .HasForeignKey(b => b.TouristId);
            ConfigureBaseEntity(entity);
        }); 
    }
}