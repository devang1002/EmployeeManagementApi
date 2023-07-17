using EmployeeManagement.BL;
using EmployeeManagement.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<EmployeeBL>();
builder.Services.AddTransient<EmployeeRepository>();
builder.Services.AddTransient<EmployeeAddressBL>();

builder.Services.AddTransient<EmployeeAddressRepository>();
builder.Services.AddTransient<AddressTypeBL>();
builder.Services.AddTransient<AddressTypeRepository>();
builder.Services.AddTransient<EmployeeFamilyDetailBL>();
builder.Services.AddTransient<EmployeeFamilyDetailRepository>();
builder.Services.AddTransient<EmployeeRelationBL>();
builder.Services.AddTransient<EmployeeRelationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
