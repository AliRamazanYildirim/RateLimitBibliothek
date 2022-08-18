using AspNetCoreRateLimit;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateBegerenzung"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateBegerenzungPolitiken"));
builder.Services.AddInMemoryRateLimiting();
//builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
//builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var ipPolicyStore = app.Services.GetRequiredService<IIpPolicyStore>(); 
ipPolicyStore.SeedAsync().GetAwaiter().GetResult();
var clientPolicyStore = app.Services.GetRequiredService<IClientPolicyStore>();
clientPolicyStore.SeedAsync().GetAwaiter().GetResult();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
