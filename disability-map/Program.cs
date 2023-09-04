using disability_map.Data;
using disability_map.Services.PlaceService;
using disability_map.Services.ScoreService;
using disability_map.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Azure.Storage.Blobs;
using disability_map.Services.PhotoService;
using Azure.Messaging.ServiceBus;
using disability_map.Models;
using disability_map.Services.ReservationService;
using disability_map.Services.SmsService;
using disability_map.DataAnnotations;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<DbMainContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
    builder => builder.EnableRetryOnFailure()));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var result = new ValidationFailedServiceResponse(context.ModelState);

        result.ContentTypes.Add(MediaTypeNames.Application.Json);
        result.ContentTypes.Add(MediaTypeNames.Application.Xml);

        return result;
    };
});

builder.Services.AddCors();
// configure azure blob storage

builder.Services.AddScoped(_ =>
{
    return new BlobServiceClient(builder.Configuration.GetConnectionString("BlobStorage"));
});

builder.Services.AddScoped(_ =>
{
    return new ServiceBusClient(builder.Configuration.GetConnectionString("ServiceBus"));
});

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });



var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials

//add seciurity headers
//https://cheatsheetseries.owasp.org/cheatsheets/REST_Security_Cheat_Sheet.html

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Xss-Protection", "DENY");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("Content-Type", "application/json");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("Cashe-Control", "no-store");
    context.Response.Headers.Add("Feature-Policy",
    "vibrate 'self' ; " +
    "camera 'self' ; " +
    "microphone 'self' ; " +
    "speaker 'self' https://youtube.com https://www.youtube.com ;" +
    "geolocation 'self' ; " +
    "gyroscope 'self' ; " +
    "magnetometer 'self' ; " +
    "midi 'self' ; " +
    "sync-xhr 'self' ; " +
    "push 'self' ; " +
    "notifications 'self' ; " +
    "fullscreen '*' ; " +
    "payment 'self' ; ");

    context.Response.Headers.Add(
    "Content-Security-Policy",
    "frame-ancestors 'none'; "
    );
    await next();
});

// Strict-Transport-Security
app.UseHsts();


app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
        name:"default",
        pattern:"{controller=Access}/{action=Login}/{id?}"
    );

await app.RunAsync();
