public interface AppointmentRepository : Repository
{
    public void AddAppointment(Appointment appointment);
    public int GetDoctorsAppointmentInDay(int id, DateTime date);
    public Task<List<GetAppointmentDto>> GetAll();
    public Task<List<GetDoctorAppointmentDto>> GetDoctorsAppointment(int id);
    public Task<List<GetPatientAppointmentDto>> GetPatientsAppointments(int id);
    public Appointment Find(int id);
    public void Delete(Appointment appointment);
    public void Update(Appointment appointment);
}