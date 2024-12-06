using Microsoft.EntityFrameworkCore;
using APIFuncionarios.DataContext;
using APIFuncionarios.Service.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// faz a injeção de dependencias do IfuncionarioInterface usando os métodos do FuncionárioService
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

// conexão com o banco
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // passando as options o caminho de conexão com o banco
});

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
