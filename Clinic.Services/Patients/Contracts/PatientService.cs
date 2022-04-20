public interface PatientService
{
    public void Add(CreatePatientDto dto);
    public Task<List<GetPatientDto>> GetAll();
    public void DeActivate(int id);
    public void Activate(int id);
    public void Update(int id, UpdatePatientDto dto);
}