public class Doctor : Person
{
    public Doctor()
    {
        DoctorPatients = new List<Appointment>();
    }
    public int PatientsPerDay { get; set; }
    public int ProficiencyId { get; set; }
    public Proficiency Proficiency { get; set; }
    public List<Appointment> DoctorPatients { get; set; }
}