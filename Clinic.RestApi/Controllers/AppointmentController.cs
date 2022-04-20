using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : Controller
{
    private readonly AppointmentService _service;

    public AppointmentController(AppointmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public void CreateAppointment(CreateAppointmentDto dto)
    {
        _service.Add(dto);
    }

    [HttpGet]
    public Task<List<GetAppointmentDto>> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPut("{id}")]
    public void Update(int id, UpdateAppointmentDto dto)
    {
        _service.Update(id, dto);
    }
    
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}