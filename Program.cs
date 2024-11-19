using LibrarifyAPI.Data;
using LibrarifyAPI.Exception;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add<HandleException>();
});

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection not found'")
));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Loan>, LoanRepository>();
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Fee>, FeeRepository>();
builder.Services.AddScoped<IRepository<Review>, ReviewRepository>();
builder.Services.AddScoped<IRepository<Notification>, NotificationRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
