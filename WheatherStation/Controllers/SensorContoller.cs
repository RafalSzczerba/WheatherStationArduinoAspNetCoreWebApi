using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheatherStation.DAL.Entities;
using WheatherStation.DAL.Repositiories;
using WheatherStation.Services;

namespace WheatherStation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorContoller : Controller
    {
        private IArduinoDbService _arduinoDbService;        
        public SensorContoller(IArduinoDbService arduinoDbService)
        {
            _arduinoDbService = arduinoDbService;
        }     

        // GET: SensorContoller/Details/5
        [HttpPost]
        [Route("writeData")]
        public async Task<ActionResult> WriteDataTODataBase(uint milliseconds, double speed)
        {           
            await _arduinoDbService.AddData(new Arduino { Tempetature = milliseconds.ToString(), Pressure = speed.ToString()});
            return StatusCode(200);
        }
        [HttpGet]
        [Route("getDataByDate")]
        public async Task<ActionResult> GetDataByDate([FromQuery] string startDate, [FromQuery] string endDate)
        {

            var link = $"https://localhost:5001/sensor/getDataByDate?dateFrom={DateTime.Now.AddDays(-1):dd-MM-yyyy}&dateTo={DateTime.Now.AddDays(1):dd-MM-yyyy}";
            if (!DateTime.TryParse(startDate, out var apiDateFrom))
            {
                return Ok(await _arduinoDbService.GetAllArduinoData());
            };

            if (!DateTime.TryParse(endDate, out var apiDateTo))
            {
                return Ok(await _arduinoDbService.GetAllArduinoData());
            };
            return Ok(await _arduinoDbService.GetDataByDate(apiDateFrom, apiDateTo));
        }
        [HttpGet]
        [Route("getLastData")]
        public async Task<ActionResult> GetLastData()
        {

            return Ok(await _arduinoDbService.GetLastData());            
        }
    }
}
