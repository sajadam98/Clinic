
public interface DoctorRepository : Repository
{
    public void AddDoctor(Doctor doctor);
    public Task<List<GetDoctorDto>> GetAll();
    public Doctor Find(int id);
    public void Update(Doctor doctor);
    bool IsNationalCodeExist(string nationalCode);
}