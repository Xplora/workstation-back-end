using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TripMatch.Xplore.Platform.ARM.Application.BookingCommandService;
using TripMatch.Xplore.Platform.ARM.Application.BookingQueryService;
using TripMatch.Xplore.Platform.ARM.Domain;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Commands;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Validators;
using TripMatch.Xplore.Platform.ARM.Domain.Services;
using TripMatch.Xplore.Platform.ARM.Infrastructure.Persistence.EFC.Repositories;
using TripMatch.Xplore.Platform.DAP.Application.Internal.CommandServices;
using TripMatch.Xplore.Platform.DAP.Application.Internal.QueryService;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Validators;
using TripMatch.Xplore.Platform.DAP.Domain.Repositories;
using TripMatch.Xplore.Platform.DAP.Domain.Services;
using TripMatch.Xplore.Platform.DAP.Infraestructure.Persistence.EFC.Repositories;
using TripMatch.Xplore.Platform.IAM.Application.SecurityCommandServices;
using TripMatch.Xplore.Platform.IAM.Application.TokenServices;
using TripMatch.Xplore.Platform.IAM.Domain.Services;
using TripMatch.Xplore.Platform.Inquiry.Application.Internal.CommandServices;
using TripMatch.Xplore.Platform.Inquiry.Application.Internal.QueryServices;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Validators;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Inquiry.Domain.Services;
using TripMatch.Xplore.Platform.Inquiry.Infraestructure.Persistence.EFC.Repositories;
using TripMatch.Xplore.Platform.Profile.Application.Internal.CommandServices;
using TripMatch.Xplore.Platform.Profile.Application.Internal.QueryServices;
using TripMatch.Xplore.Platform.Profile.Domain;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Validadors;
using TripMatch.Xplore.Platform.Profile.Domain.Services;
using TripMatch.Xplore.Platform.Profile.Infrastructure.Persistence.EFC.Repositories;
using TripMatch.Xplore.Platform.Reviews.Application.CommandService;
using TripMatch.Xplore.Platform.Reviews.Application.QueryService;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Validators;
using TripMatch.Xplore.Platform.Reviews.Domain.Repository;
using TripMatch.Xplore.Platform.Reviews.Domain.Services;
using TripMatch.Xplore.Platform.Reviews.Infrastructure.Persistence.EFC.Repositories;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Mediator.Cortex.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null) throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
    
    if (builder.Environment.IsDevelopment())
        options.LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    else
        options.LogTo(Console.WriteLine, LogLevel.Error);
});

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TripMatch.Xplore.Platform",
        Version = "v1",
        Description = "TripMatch Xplore Platform API",
        TermsOfService = new Uri("https://tripMatch-xplore.com/tos"),
        Contact = new OpenApiContact { Name = "Xplore Studios", Email = "contact@acme.com" },
        License = new OpenApiLicense { Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0") }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// CORS Policy
var MyAllowSpecificOrigins = "AllowAllPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});


// Inyección de dependencias (Shared)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IExperienceCommandService, ExperienceCommandService>();
builder.Services.AddScoped<IExperienceQueryService, ExperienceQueryService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateExperienceCommandValidator>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();
builder.Services.AddScoped<IValidator<CreateBookingCommand>, CreateBookingCommandValidator>();

builder.Services.AddScoped<IInquiryCommandService, InquiryCommandService>();
builder.Services.AddScoped<IInquiryQueryService, InquiryQueryService>();
builder.Services.AddScoped<IInquiryRepository, InquiryRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateInquiryCommandValidator>();

builder.Services.AddScoped<IResponseCommandService, ResponseCommandService>();
builder.Services.AddScoped<IResponseQueryService, ResponseQueryService>();
builder.Services.AddScoped<IResponseRepository, ResponseRepository>();
builder.Services.AddScoped<IValidator<CreateResponseCommand>, CreateResponseCommandValidator>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();
builder.Services.AddScoped<IValidator<CreateReviewCommand>, CreateReviewCommandValidator>();


builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteCommandService, FavoriteCommandService>();
builder.Services.AddScoped<IFavoriteQueryService, FavoriteQueryService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateFavoriteCommandValidator>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: new[] { typeof(Program) }, configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    });

// JWT Authentication configuration
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Ensure DB Created / Migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors("AllowAllPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
