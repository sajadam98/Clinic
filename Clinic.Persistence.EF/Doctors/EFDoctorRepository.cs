using Microsoft.EntityFrameworkCore;

public class EFDoctorRepository : DoctorRepository
{
    private readonly DbSet<Doctor> _doctors;

    public EFDoctorRepository(EFDataContext dbContext)
    {
        _doctors = dbContext.Set<Doctor>();
    }

    public void AddDoctor(Doctor doctor)
    {
        _doctors.Add(doctor);
    }

    public Task<List<GetDoctorDto>> GetAll()
    {
        return _doctors.AsNoTracking().Select(_ => new GetDoctorDto
        {
            Id = _.Id,
            IsActive = _.IsActive,
            phoneNumber = _.PhoneNumber,
            FirstName = _.FirstName,
            LastName = _.LastName,
            NationalCode = _.NationalCode,
        }).ToListAsync();
    }

    public Doctor GetDoctor(int id)
    {
        throw new NotImplementedException();
    }

    public Doctor Find(int id)
    {
        return _doctors.FirstOrDefault(_ => _.Id == id);
    }

    public void Update(Doctor doctor)
    {
        _doctors.Update(doctor);
    }
    public bool IsNationalCodeExist(string nationalCode)
    {
        return _doctors.Where(_ => _.NationalCode != nationalCode)
            .Any(_ => _.NationalCode == nationalCode);
    }
}