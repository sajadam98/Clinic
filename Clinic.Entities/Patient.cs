public class Patient : Person
{
    public Patient()
    {
        PatientDoctors = new List<Appointment>();
    }
    public List<Appointment> PatientDoctors { get; set; }
}