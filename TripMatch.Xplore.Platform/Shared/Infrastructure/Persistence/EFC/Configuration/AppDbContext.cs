using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripMatch.Xplore.Platform.ARM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TripMatch.Xplore.Platform.DAP.Infraestructure.Persistence.EFC.Configuration.Extensions;
using TripMatch.Xplore.Platform.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TripMatch.Xplore.Platform.Inquiry.Infraestructure.Persistence.EFC.Configuration.Extensions;
using TripMatch.Xplore.Platform.Profile.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TripMatch.Xplore.Platform.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;


namespace TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyArmConfiguration();
        builder.ApplyDapConfiguration();
        builder.ApplyInquiryConfiguration();
        builder.ApplyIamConfiguration();
        builder.ApplyReviewConfiguration();
        builder.ApplyProfileConfiguration();

        builder.UseSnakeCaseNamingConvention();
    }
}
