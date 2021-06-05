using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercise_1.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/weather")]
    [ApiController]
    public class WeatherDiaryController : ControllerBase
    {
        private readonly WeatherDiary _weatherDiary;

        public WeatherDiaryController(WeatherDiary weatherDiary) 
        {
            _weatherDiary = weatherDiary;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string time, [FromQuery] string temperature)
        {
            var timeValue = DateTime.Parse(time);
            var temperatureValue = Int32.Parse(temperature);
            WeatherDiaryEntry entry = new WeatherDiaryEntry(timeValue, temperatureValue);
            _weatherDiary.Entries.Add(entry);
            return Ok();
            // TODO: try parse
        }

        [HttpGet("readbytimeinterval")]
        public IActionResult ReadByTimeInterval(/*[FromQuery] string startInterval, [FromQuery] string endInterval*/)
        {
            return Ok(_weatherDiary.Entries);
        }

        [HttpPut("editbytime")]
        public IActionResult EditByTime([FromQuery] string time)
        {
            return Ok();
        }

        [HttpDelete("deletebytimeinterval")]
        public IActionResult DeleteByTimeInterval([FromQuery] string startInteral, [FromQuery] string endInterval)
        {
            return Ok();
        }
    }
}
