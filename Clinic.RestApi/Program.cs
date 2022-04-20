using Autofac;
using Clinic.Services.Doctors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EFDataContext>(_ =>
    _.UseSqlServer("Server=localhost;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=Yes;"));
builder.Services.AddScoped<DoctorRepository, EFDoctorRepository>();
builder.Services.AddScoped<DoctorService, DoctorAppService>();
builder.Services.AddScoped<ProficiencyRepository, EFProficiencyRepository>();
builder.Services.AddScoped<ProficiencyService, ProficiencyAppService>();
builder.Services.AddScoped<PatientRepository, EFPatientRepository>();
builder.Services.AddScoped<PatientService, PatientAppService>();
builder.Services.AddScoped<AppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<AppointmentService, AppointmentAppService>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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