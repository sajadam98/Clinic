using System.Xml;
using Clinic.Services.Doctors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/doctors")]
public class DoctorController : Controller
{
    private readonly DoctorService _doctorService;

    public DoctorController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost]
    public void CreateDoctor(CreateDoctorDto dto)
    {
        _doctorService.Add(dto);
    }

    [HttpGet]
    public Task<List<GetDoctorDto>> GetAll()
    {
        return _doctorService.GetAll();
    }

    [HttpPut("{id}")]
    public void Update(int id, UpdateDoctorDto dto)
    {
        _doctorService.Update(id, dto);
    }
    
    [HttpPatch("{id}/deactivate")]
    public void DeActivate(int id)
    {
        _doctorService.DeActivate(id);
    }
    
    [HttpPatch("{id}/activate")]
    public void Activate(int id)
    {
        _doctorService.Activate(id);
    }
}