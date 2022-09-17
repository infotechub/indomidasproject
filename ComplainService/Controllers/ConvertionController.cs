using Complaintservice.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainService.Controllers
{
    [Authorize]
    [Route("api/convertion")]
    [ApiController]
    public class ConvertionController : ControllerBase
    {
        private IApplicationDbContext _context;
        public ConvertionController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claims = User.Claims;
            var conv =  await _context.ConvertMeasurement.ToListAsync();
            if (conv == null) return NotFound();
            return Ok(conv);
        }

        [HttpGet("MeasurementType={MeasurementType}&MeasurementValue={MeasurementValue}&From={From}&To={To}")]
        public async Task<IActionResult> ConvertMeasurement(string MeasurementType, int MeasurementValue, string From, string To)
        {
            var formulatt = await _context.ConvertMeasurement.Where(x => x.ConvertFrom == From && x.ConvertTo == To).FirstOrDefaultAsync();

            if (From == To)
            {
                var err = "You can not convert from" + From + "to" + To;
            }
            if (MeasurementType == "Temperature")
            {
                if (From == "Celsius" && To == "Fahrenheit")
                {
                    var answ = formulatt.Metric2imperial;
                }
                else
                {
                    var answ = formulatt.Imperial2Metric;
                }
            }
            if (MeasurementType == "Speed")
            {
                if (From == "Kilometer" && To == "Meter")
                {
                    var answ = formulatt.Metric2imperial;
                }
                else
                {
                    var answ = formulatt.Imperial2Metric;
                }
            }
            if (MeasurementType == "Volume")
            {
                if (From == "Litre" && To == "Gallon")
                {
                    var answ = formulatt.Metric2imperial;
                }
                else
                {
                    var answ = formulatt.Imperial2Metric;
                }
            }

            if (MeasurementType == "Mass")
            {
                if (From == "Kilogram" && To == "Pound")
                {
                    var answ = formulatt.Metric2imperial;
                }
                else
                {
                    var answ = formulatt.Imperial2Metric;
                }
            }
            if (MeasurementType == "Mass")
            {
                if (From == "Ounce" && To == "Kilogram")
                {
                    var answ = formulatt.Metric2imperial;
                }
                else
                {
                    var answ = formulatt.Imperial2Metric;
                }
            }
            else
            {
                var err = "Kindly input valid input";
            }


            return Ok();
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> ConvMeasurement(int Id)
        {
            var formulatt = await _context.ConvertMeasurement.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (formulatt == null)
            {
                var err = "This information does not exist";
            }
            


            return Ok(formulatt);
        }
    }
}
