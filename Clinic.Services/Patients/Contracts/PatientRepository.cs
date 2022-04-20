public interface PatientRepository : Repository
{
    public void Add(Patient patient);
    public Task<List<GetPatientDto>> GetAll();
    public Patient Find(int id);
    public void Update(Patient patient);
    bool IsNationalCodeExist(string nationalCode);
}