
public interface ProficiencyService : Service
{
    public void Add(CreatePoficiencyDto dto);
    public Task<List<GetProficiencyDto>> GetAll();
    public void Delete(int id);
    public void Update(int id, UpdateProficiencyDto dto);
}