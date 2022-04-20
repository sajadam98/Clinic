using Microsoft.EntityFrameworkCore.Migrations.Operations;

public class AppointmentAppService : AppointmentService
{
    private readonly AppointmentRepository _appointmentRepository;
    private readonly PatientRepository _patientRepository;
    private readonly DoctorRepository _doctorRepository;
    private readonly UnitOfWork _unitOfWork;

    public AppointmentAppService(AppointmentRepository appointmentRepository, PatientRepository patientRepository,
        DoctorRepository doctorRepository, UnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public void Add(CreateAppointmentDto dto)
    {
        var patient = _patientRepository.Find(dto.PatientId);
        var doctor = _doctorRepository.Find(dto.DoctorId);
        var appointment = new Appointment
        {
            Date = dto.Date,
            Doctor = doctor,
            Patient = patient
        };
        var doctorsAppointmentInDay = _appointmentRepository
            .GetDoctorsAppointmentInDay(dto.DoctorId, dto.Date);
        
        if (doctorsAppointmentInDay >= doctor.PatientsPerDay)
        {
            throw new DoctorsAppointmentPerDayIsCompleted();
        }

        _appointmentRepository.AddAppointment(appointment);
        _unitOfWork.Save();
    }

    public Task<List<GetAppointmentDto>> GetAll()
    {
        return _appointmentRepository.GetAll();
    }

    public Task<List<GetDoctorAppointmentDto>> GetDoctorsAppointment(int id)
    {
        return _appointmentRepository.GetDoctorsAppointment(id);
    }

    public Task<List<GetPatientAppointmentDto>> GetPatientsAppointments(int id)
    {
        return _appointmentRepository.GetPatientsAppointments(id);
    }

    public void Delete(int id)
    {
        var appointment = _appointmentRepository.Find(id);
        if (appointment == null)
        {
            throw new AppointmentNotFoundException();
        }
        _appointmentRepository.Delete(appointment);
        _unitOfWork.Save();
    }

    public void Update(int id, UpdateAppointmentDto dto)
    {
        var appointment = _appointmentRepository.Find(id);
        if (appointment == null)
        {
            throw new AppointmentNotFoundException();
        }
        var patient = _patientRepository.Find(dto.PatientId);
        var doctor = _doctorRepository.Find(dto.DoctorId);
        var doctorsAppointmentInDay = _appointmentRepository.GetDoctorsAppointmentInDay(dto.DoctorId, dto.Date);
        if (doctorsAppointmentInDay > doctor.PatientsPerDay)
        {
            throw new DoctorsAppointmentPerDayIsCompleted();
        }

        appointment.Doctor = doctor;
        appointment.Patient = patient;
        appointment.Date = dto.Date;
        _appointmentRepository.Update(appointment);
        _unitOfWork.Save();
    }
}