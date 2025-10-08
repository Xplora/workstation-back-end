using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Profile.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProfileConfiguration(this ModelBuilder builder)
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
        
        
        
         builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).IsRequired();

              
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Number).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(500);


                entity.HasIndex(e => e.Email).IsUnique();

                // Relación 1:1 User <-> Agency
                entity.HasOne(u => u.Agency)
                    .WithOne(a => a.User)
                    .HasForeignKey<Agency>(a => a.UserId);

                // Relación 1:1 User <-> Tourist
                entity.HasOne(u => u.Tourist)
                    .WithOne(t => t.User)
                    .HasForeignKey<Tourist>(t => t.UserId);
                ConfigureBaseEntity(entity);
            });

            // Agency
            builder.Entity<Agency>(entity =>
            {
                entity.ToTable("Agencies");
                
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).IsRequired(); 
                

                entity.Property(e => e.AgencyName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Ruc).IsRequired().HasMaxLength(11);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Rating);
                entity.Property(e => e.ReviewCount);
                entity.Property(e => e.ReservationCount);
                entity.Property(e => e.AvatarUrl).HasMaxLength(700);
                entity.Property(e => e.ContactEmail).HasMaxLength(100);
                entity.Property(e => e.ContactPhone).HasMaxLength(20);
                entity.Property(e => e.SocialLinkFacebook).HasMaxLength(100);
                entity.Property(e => e.SocialLinkInstagram).HasMaxLength(100);
                entity.Property(e => e.SocialLinkWhatsapp).HasMaxLength(100);
                ConfigureBaseEntity(entity); 
                
                entity.HasOne(a => a.User)
                    .WithOne(u => u.Agency)
                    .HasForeignKey<Agency>(a => a.UserId) 
                    .HasPrincipalKey<User>(u => u.UserId); 
            });


            // Tourist
            builder.Entity<Tourist>(entity =>
            {
                entity.ToTable("Tourists");
                
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).IsRequired(); 
                

                entity.Property(e => e.AvatarUrl).HasMaxLength(255);
                ConfigureBaseEntity(entity);
                
                entity.HasOne(t => t.User)
                    .WithOne(u => u.Tourist)
                    .HasForeignKey<Tourist>(t => t.UserId) 
                    .HasPrincipalKey<User>(u => u.UserId); 
            });

    }
}