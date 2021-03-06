



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region DIServices
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddTransient<IPlatfromQueryService, PlatfromQueryService>();
builder.Services.AddTransient<IPlatfromCommandService, PlatfromCommandService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
#endregion
#region AddInMemDb
if(builder.WebHost.Production)
{

}
builder.Services.AddDbContext<AppDbContext>(a =>
a.UseInMemoryDatabase("InMem"));
#endregion
#region AddHttpClientService
builder.Services.AddHttpClient<ICommandDataClientService, CommandDataClientService>();

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Seed Data
PrepDb.PrepPopulation(builder.Services);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();