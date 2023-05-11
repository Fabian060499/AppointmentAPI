using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
