using Microsoft.EntityFrameworkCore;

public class EFProficiencyRepository : ProficiencyRepository
{
    private readonly DbSet<Proficiency> _proficiencies;

    public EFProficiencyRepository(EFDataContext dbContext)
    {
        _proficiencies = dbContext.Set<Proficiency>();
    }

    public void AddProficiency(Proficiency proficiency)
    {
        _proficiencies.Add(proficiency);
    }

    public Task<List<GetProficiencyDto>> GetAll()
    {
        return _proficiencies.Select(_ => new GetProficiencyDto
        {
            Id = _.Id,
            Name = _.Name
        }).ToListAsync();
    }

    public Proficiency Find(int id)
    {
        var proficiency = _proficiencies.FirstOrDefault(_ => _.Id == id);
        if (proficiency == null)
        {
            throw new ProficiencyNotFoundException();
        }

        return proficiency;
    }

    public void Delete(Proficiency proficiency)
    {
        _proficiencies.Remove(proficiency);
    }

    public void Update(Proficiency proficiency)
    {
        _proficiencies.Update(proficiency);
    }

    public int ProficienciesDoctorCount(int id)
    {
        return _proficiencies.Include(_ => _.Doctors).FirstOrDefault(_ => _.Id == id).Doctors.Count();
    }
}