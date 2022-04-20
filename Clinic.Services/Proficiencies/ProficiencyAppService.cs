public class ProficiencyAppService : ProficiencyService
{
    private readonly ProficiencyRepository _proficiencyRepository;
    private readonly UnitOfWork _unitOfWork;

    public ProficiencyAppService(ProficiencyRepository proficiencyRepository, UnitOfWork unitOfWork)
    {
        _proficiencyRepository = proficiencyRepository;
        _unitOfWork = unitOfWork;
    }

    public void Add(CreatePoficiencyDto dto)
    {
        var proficiency = new Proficiency
        {
            Name = dto.Name,
        };
        _proficiencyRepository.AddProficiency(proficiency);
        _unitOfWork.Save();
    }

    public Task<List<GetProficiencyDto>> GetAll()
    {
        return _proficiencyRepository.GetAll();
    }

    public void Delete(int id)
    {
        var proficiency = _proficiencyRepository.Find(id);
        if (proficiency == null)
        {
            throw new ProficiencyNotFoundException();
        }

        var proficienciesDoctorCount = _proficiencyRepository.ProficienciesDoctorCount(id);
        if (proficienciesDoctorCount > 0)
        {
            throw new proficiencyHasDoctorException();
        }

        _proficiencyRepository.Delete(proficiency);
        _unitOfWork.Save();
    }

    public void Update(int id, UpdateProficiencyDto dto)
    {
        var proficiency = _proficiencyRepository.Find(id);
        if (proficiency == null)
        {
            throw new ProficiencyNotFoundException();
        }

        proficiency.Name = dto.Name;
        _proficiencyRepository.Update(proficiency);
        _unitOfWork.Save();
    }
}