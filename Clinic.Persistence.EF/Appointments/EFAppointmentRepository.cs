using Microsoft.EntityFrameworkCore;

public class EfAppointmentRepository : AppointmentRepository
{
    private readonly DbSet<Appointment> _appointments;

    public EfAppointmentRepository(EFDataContext dbContext)
    {
        _appointments = dbContext.Set<Appointment>();
    }

    public void AddAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
    }

    public int GetDoctorsAppointmentInDay(int id, DateTime date)
    {
        return _appointments.Count(_ => _.DoctorId == id && _.Date.Date == date.Date);
    }

    public Task<List<GetAppointmentDto>> GetAll()
    {
        return _appointments.Select(_ => new GetAppointmentDto
        {
            Id = _.Id,
            Date = _.Date.Date,
            Doctor = _.Doctor.FirstName + " " + _.Doctor.LastName,
            Patient = _.Patient.FirstName + " " + _.Patient.LastName
        }).ToListAsync();
    }

    public Task<List<GetDoctorAppointmentDto>> GetDoctorsAppointment(int id)
    {
        return _appointments.Where(_ => _.DoctorId == id).Select(_ => new GetDoctorAppointmentDto
        {
            Id = _.Id,
            Date = _.Date.Date,
            Patient = _.Patient.FirstName + " " + _.Patient.LastName
        }).ToListAsync();
    }

    public Task<List<GetPatientAppointmentDto>> GetPatientsAppointments(int id)
    {
        return _appointments.Where(_ => _.PatientId == id).Select(_ => new GetPatientAppointmentDto
        {
            Id = _.Id,
            Date = _.Date.Date,
            Doctor = _.Doctor.FirstName + " " + _.Doctor.LastName
        }).ToListAsync();
    }

    public Appointment Find(int id)
    {
        return _appointments.FirstOrDefault(_ => _.Id == id);
    }

    public void Delete(Appointment appointment)
    {
        _appointments.Remove(appointment);
    }

    public void Update(Appointment appointment)
    {
        _appointments.Update(appointment);
    }
}