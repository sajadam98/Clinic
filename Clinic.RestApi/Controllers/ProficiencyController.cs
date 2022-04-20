using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Proficiencies")]
public class ProficiencyController : Controller
{
    private readonly ProficiencyService _service;

    public ProficiencyController(ProficiencyService service)
    {
        _service = service;
    }

    [HttpPost]
    public void CreateProficiency(CreatePoficiencyDto dto)
    {
        _service.Add(dto);
    }

    [HttpGet]
    public Task<List<GetProficiencyDto>> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPut("{id}")]
    public void Update(int id, UpdateProficiencyDto dto)
    {
        _service.Update(id,  dto);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}