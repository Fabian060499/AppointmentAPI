namespace AppointmentAPI
{
    public class Appointment
    {
        public int Id { get; set; }
        public string patientName { get; set; } = string.Empty;
        public string age { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string priority { get; set; } = string.Empty;
        public string appointmentTime { get; set; } = string.Empty;
    }
}
