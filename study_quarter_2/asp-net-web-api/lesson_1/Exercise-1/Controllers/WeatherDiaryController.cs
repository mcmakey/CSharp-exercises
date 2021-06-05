using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            // TODO: try parse
            var timeValue = DateTime.Parse(time);
            var temperatureValue = Int32.Parse(temperature);
            WeatherDiaryEntry entry = new WeatherDiaryEntry(timeValue, temperatureValue);
            _weatherDiary.Entries.Add(entry);
            return Ok();
        }

        // TODO: for dev
        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_weatherDiary.Entries);
        }

        [HttpGet("readbytimeinterval")]
        public IActionResult ReadByTimeInterval([FromQuery] string start, [FromQuery] string end)
        {
            // TODO: try parse
            var startIntervalValue = DateTime.Parse(start);
            var endIntervalValue = DateTime.Parse(end);

            List<WeatherDiaryEntry> samplingByTimeInterval = new List<WeatherDiaryEntry> { };

            foreach (var entry in _weatherDiary.Entries)
            {
                if ( startIntervalValue <= entry.Time && entry.Time <= endIntervalValue)
                {
                    samplingByTimeInterval.Add(entry);
                }
            }

            return Ok(samplingByTimeInterval);
        }

        [HttpPut("editbytime")]
        public IActionResult EditByTime([FromQuery] string time, [FromQuery] string newTemperature)
        {
            // TODO: try parse
            var timeValue = DateTime.Parse(time);
            var newTemperatureValue = int.Parse(newTemperature);
            foreach (var entry in _weatherDiary.Entries)
            {
                if (entry.Time == timeValue)
                {
                    entry.Temperature = newTemperatureValue;
                }
            }
            return Ok();
        }

        [HttpDelete("deletebytimeinterval")]
        public IActionResult DeleteByTimeInterval([FromQuery] string startInteral, [FromQuery] string endInterval)
        {
            return Ok();
        }
    }
}
