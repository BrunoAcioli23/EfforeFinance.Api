var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<EfforeFinance.Api.Repositories.TransacaoRepository>(provider =>
    new EfforeFinance.Api.Repositories.TransacaoRepository(connectionString));

builder.Services.AddScoped<EfforeFinance.Api.Repositories.DashboardRepository>(provider =>
    new EfforeFinance.Api.Repositories.DashboardRepository(connectionString));

var app = builder.Build();

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
