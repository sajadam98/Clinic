namespace Clinic.Services.Doctors;

public interface DoctorService: Service
{
    public void Add(CreateDoctorDto dto);
    public Task<List<GetDoctorDto>> GetAll();
    public void DeActivate(int id);
    public void Activate(int id);
    public void Update(int id, UpdateDoctorDto dto);
}