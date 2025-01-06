using System.Text.Json.Serialization;
using System.Text;
using AspNetCoreRateLimit;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Http.Features;
using BUSINESS_LOGIC;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using MODELS;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.WriteIndented = true;
})
.AddXmlDataContractSerializerFormatters();
builder.Services.AddTransient<RETURN_MESSAGE>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddInfrastructure();
builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 2 GB
    options.MultipartBodyLengthLimit = 2147483648;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("ConnectionStrings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = async context =>
        {
            // Call this to skip the default logic and avoid using the default response
            context.HandleResponse();

            // Construct the JSON response object
            var responseObj = new
            {
                Status_Code = StatusCodes.Status401Unauthorized.ToString(),
                Message = "Unauthorized"
            };

            // Serialize the JSON object to a string
            var jsonResponse = JsonConvert.SerializeObject(responseObj);

            // Set the appropriate headers
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers.Append("Content-Type", "application/json");

            // Write the JSON response to the response body
            await context.Response.WriteAsync(jsonResponse);
        }
    };
});

var app = builder.Build();
 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DLF_API");
    });
}
app.UseCors("NgOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.UseIpRateLimiting();
app.MapControllers();
 
app.UseHttpsRedirection();


app.Run();
app.Use(async (context, next) =>
{

    await next.Invoke();
    context.Response.Headers.Remove("ETag");
    await next();

});


