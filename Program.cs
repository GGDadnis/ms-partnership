using System.ComponentModel;
using System.Text;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ms_partnership.Data;
using ms_partnership.Domain;
using ms_partnership.Exceptions;
using ms_partnership.Exceptions.InterfacesExceptions;
using ms_partnership.Exceptions.PaginationExceptions;
using ms_partnership.Interfaces;
using ms_partnership.Interfaces.PaginationInterfaces;
using ms_partnership.Service;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUser, UserDomain>();
builder.Services.AddScoped<ICompany, CompanyDomain>();
builder.Services.AddScoped<IReview, ReviewDomain>();
builder.Services.AddScoped<IPromo, PromoDomain>();
builder.Services.AddScoped<IAddress, AddressDomain>();
builder.Services.AddScoped<ICategory, CategoryDomain>();
builder.Services.AddScoped<ILogin, LoginDomain>();
builder.Services.AddScoped<IPromoPaginationExceptions, PromoPaginationExceptions>();
builder.Services.AddScoped<ILoginExceptions, LoginExceptions>();
builder.Services.AddScoped<IPromoExceptions, PromoExceptions>();
builder.Services.AddScoped<IReviewExceptions, ReviewExceptions>();


// Add services to the container.
// AddDbContext -> postgres  
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    assembly => assembly.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
    );
});

//AddCors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8080")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin();
                          });
});

// AddAutoMapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//AddAuthentication
builder.Services.AddAuthentication(x =>
{	
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

//AddJwtBearer
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
       ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "You need an accessToken \"api/Authenticate/login\""
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//If some URI is duplicated, you can use this to resolve the conflict
// builder.Services.AddSwaggerGen(c =>
// {
//      c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
// });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Amazon S3 Configuration
var awsOptions = builder.Configuration.GetAWSOptions();
awsOptions.Credentials = new BasicAWSCredentials(
    builder.Configuration["AWS:Key"],
    builder.Configuration["AWS:Secret"]
);
awsOptions.Region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]);
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddTransient<AmazonS3Service>(provider => new AmazonS3Service(
    provider.GetService<IAmazonS3>(),
    builder.Configuration["AWS:Bucketname"]
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
