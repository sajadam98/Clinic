public class PatientAppService : PatientService
{
    private readonly PatientRepository _patientRepository;
    private readonly UnitOfWork _unitOfWork;

    public PatientAppService(PatientRepository patientRepository,
        UnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public void Add(CreatePatientDto dto)
    {
        var isPatientExist = _patientRepository.IsNationalCodeExist(dto.NationalCode);
        if (isPatientExist)
        {
            throw new DuplicatePatientsNationalCode();
        }

        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            PhoneNumber = dto.PhoneNumber
        };
        _patientRepository.Add(patient);
        _unitOfWork.Save();
    }

    public Task<List<GetPatientDto>> GetAll()
    {
        return _patientRepository.GetAll();
    }

    public void DeActivate(int id)
    {
        var patient = _patientRepository.Find(id);
        if (patient == null)
        {
            throw new PatientNotFoundException();
        }

        patient.IsActive = false;
        _patientRepository.Update(patient);
        _unitOfWork.Save();
    }

    public void Activate(int id)
    {
        var patient = _patientRepository.Find(id);
        if (patient == null)
        {
            throw new PatientNotFoundException();
        }

        patient.IsActive = true;
        _patientRepository.Update(patient);
        _unitOfWork.Save();
    }

    public void Update(int id, UpdatePatientDto dto)
    {
        var isPatientExist = _patientRepository.IsNationalCodeExist(dto.NationalCode);
        if (isPatientExist)
        {
            throw new DuplicatePatientsNationalCode();
        }

        var patient = _patientRepository.Find(id);
        if (patient == null)
        {
            throw new PatientNotFoundException();
        }
        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.NationalCode = dto.NationalCode;
        patient.PhoneNumber = dto.PhoneNumber;
        _patientRepository.Update(patient);
        _unitOfWork.Save();
    }
}