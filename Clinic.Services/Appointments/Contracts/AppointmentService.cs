public interface AppointmentService : Service
{
    public void Add(CreateAppointmentDto dto);
    public Task<List<GetAppointmentDto>> GetAll();
    public Task<List<GetDoctorAppointmentDto>> GetDoctorsAppointment(int id);
    public Task<List<GetPatientAppointmentDto>> GetPatientsAppointments(int id);
    public void Delete(int id);
    public void Update(int id, UpdateAppointmentDto dto);
}