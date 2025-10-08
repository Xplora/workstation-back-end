using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Inquiry.Infraestructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyInquiryConfiguration(this ModelBuilder builder)
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
        
        builder.Entity<Domain.Models.Entities.Inquiry>(entity =>
        {
            entity.ToTable("Inquiries");

            entity.HasKey(i => i.Id);

            entity.Property(i => i.Question).HasMaxLength(500).IsRequired();
            entity.Property(i => i.AskedAt).IsRequired().HasColumnType("datetime");

            entity.HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId);

            entity.HasOne(i => i.Experience)
                .WithMany()
                .HasForeignKey(i => i.ExperienceId);

            entity.HasOne(i => i.Response)
                .WithOne(r => r.Inquiry)
                .HasForeignKey<Response>(r => r.InquiryId);
            ConfigureBaseEntity(entity);
        });

        builder.Entity<Response>(entity =>
        {
            entity.ToTable("Responses");

            entity.HasKey(r => r.Id);

            entity.Property(r => r.Answer).HasMaxLength(500).IsRequired();
            entity.Property(r => r.AnsweredAt).IsRequired().HasColumnType("datetime");

            entity.Property(r => r.ResponderId)
                .HasColumnType("char(36)") 
                .IsRequired();

            entity.HasOne(r => r.Responder)
                .WithMany()
                .HasForeignKey(r => r.ResponderId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Inquiry)
                .WithOne(i => i.Response)
                .HasForeignKey<Response>(r => r.InquiryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(r => r.InquiryId).IsUnique(); 
            ConfigureBaseEntity(entity);
        });
        
    }
}