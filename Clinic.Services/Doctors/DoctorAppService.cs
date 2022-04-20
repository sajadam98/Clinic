using Clinic.Services.Doctors;

public class DoctorAppService : DoctorService
{
    private readonly DoctorRepository _doctorRepository;
    private readonly ProficiencyRepository _proficiencyRepository;
    private readonly UnitOfWork _unitOfWork;

    public DoctorAppService(DoctorRepository doctorRepository,
        UnitOfWork unitOfWork,
        ProficiencyRepository proficiencyRepository)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
        _proficiencyRepository = proficiencyRepository;
    }

    public void Add(CreateDoctorDto dto)
    {
        if (dto.PatientPerDay < 1)
        {
            throw new InvalidPatientsPerDay();
        }

        var isNationalCodeExist = _doctorRepository.IsNationalCodeExist(dto.NationalCode);
        if (isNationalCodeExist)
        {
            throw new DuplicateDoctorsNationalCode();
        }

        var proficiency = _proficiencyRepository.Find(dto.ProficiencyId);
        var doctor = new Doctor
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            PhoneNumber = dto.phoneNumber,
            PatientsPerDay = dto.PatientPerDay,
            Proficiency = proficiency
        };
        _doctorRepository.AddDoctor(doctor);
        _unitOfWork.Save();
    }

    public Task<List<GetDoctorDto>> GetAll()
    {
        return _doctorRepository.GetAll();
    }

    public void DeActivate(int id)
    {
        var doctor = _doctorRepository.Find(id);
        if (doctor == null)
        {
            throw new DoctorNotFoundException();
        }

        doctor.IsActive = false;
        _doctorRepository.Update(doctor);
        _unitOfWork.Save();
    }

    public void Activate(int id)
    {
        var doctor = _doctorRepository.Find(id);
        if (doctor == null)
        {
            throw new DoctorNotFoundException();
        }

        doctor.IsActive = true;
        _doctorRepository.Update(doctor);
        _unitOfWork.Save();
    }

    public void Update(int id, UpdateDoctorDto dto)
    {
        var doctor = _doctorRepository.Find(id);
        if (doctor == null)
        {
            throw new DoctorNotFoundException();
        }

        if (dto.PatientPerDay < 1)
        {
            throw new InvalidPatientsPerDay();
        }

        var isNationalCodeExist = _doctorRepository.IsNationalCodeExist(dto.NationalCode);
        if (isNationalCodeExist)
        {
            throw new DuplicateDoctorsNationalCode();
        }

        var proficiency = _proficiencyRepository.Find(dto.ProficiencyId);
        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.PhoneNumber = dto.phoneNumber;
        doctor.NationalCode = dto.NationalCode;
        doctor.PatientsPerDay = dto.PatientPerDay;
        doctor.Proficiency = proficiency;
        _doctorRepository.Update(doctor);
        _unitOfWork.Save();
    }
}