using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly DataContext context;

        public AppointmentController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> Get()
        {
            return Ok(await this.context.Appointments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            var pacient =await this.context.Appointments.FindAsync(id);
            if (pacient == null)
                return BadRequest("Pacient not found!");

            return Ok(pacient);
        }

        [HttpPost]
        public async Task<ActionResult<List<Appointment>>> AddPacient(Appointment pacient)
        {
            this.context.Appointments.Add(pacient);
            await this.context.SaveChangesAsync();
            
            return Ok(await this.context.Appointments.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Appointment>>> UpdatePacient(Appointment request)
        {
            var dbpacient = await this.context.Appointments.FindAsync(request.Id);
            if (dbpacient == null)
                return BadRequest("Pacient not found!");

            dbpacient.patientName = request.patientName;
            dbpacient.age = request.age;
            dbpacient.phoneNumber = request.phoneNumber;
            dbpacient.priority = request.priority;
            dbpacient.status = request.status;
            dbpacient.appointmentTime = request.appointmentTime;

            await this.context.SaveChangesAsync();
            return Ok(await this.context.Appointments.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Appointment>>> Delete(int id)
        {
            var dbpacient = await this.context.Appointments.FindAsync(id);
            if (dbpacient == null)
                return BadRequest("Pacient not found!");

            this.context.Appointments.Remove(dbpacient);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Appointments.ToListAsync());
        }
    }
}
