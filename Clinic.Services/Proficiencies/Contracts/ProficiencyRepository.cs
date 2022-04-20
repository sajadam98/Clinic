
public interface ProficiencyRepository : Repository
{
    public void AddProficiency(Proficiency proficiency);
    public Task<List<GetProficiencyDto>> GetAll();
    public Proficiency Find(int id);
    public void Delete(Proficiency proficiency);
    public void Update(Proficiency proficiency);
    public int ProficienciesDoctorCount(int id);
}