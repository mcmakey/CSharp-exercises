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
            if (
                DateTime.TryParse(time, out DateTime timeValue) &&
                Int32.TryParse(temperature, out int temperatureValue)
            )
            {
                WeatherDiaryEntry entry = new WeatherDiaryEntry(timeValue, temperatureValue);
                _weatherDiary.Entries.Add(entry);
                return Ok();
            }

            return BadRequest("невалидные данные");
        }

        // TODO: for dev
        //[HttpGet("read")]
        //public IActionResult Read()
        //{
        //    return Ok(_weatherDiary.Entries);
        //}

        [HttpGet("readbytimeinterval")]
        public IActionResult ReadByTimeInterval([FromQuery] string start, [FromQuery] string end)
        {
            if (
                DateTime.TryParse(start, out DateTime startIntervalValue) &&
                DateTime.TryParse(end, out DateTime endIntervalValue)
            )
            {
                List<WeatherDiaryEntry> samplingByTimeInterval = new List<WeatherDiaryEntry> { };

                foreach (var entry in _weatherDiary.Entries)
                {
                    if (startIntervalValue <= entry.Time && entry.Time <= endIntervalValue)
                    {
                        samplingByTimeInterval.Add(entry);
                    }
                }

                return Ok(samplingByTimeInterval);
            }

            return BadRequest("невалидные данные");
        }

        [HttpPut("editbytime")]
        public IActionResult EditByTime([FromQuery] string time, [FromQuery] string newTemperature)
        {
            if (
                DateTime.TryParse(time, out DateTime timeValue) &&
                Int32.TryParse(newTemperature, out int newTemperatureValue)
            )
            {
                foreach (var entry in _weatherDiary.Entries)
                {
                    if (entry.Time == timeValue)
                    {
                        entry.Temperature = newTemperatureValue;
                    }
                }
                return Ok();
            }

            return BadRequest("невалидные данные");
        }

        [HttpDelete("deletebytimeinterval")]
        public IActionResult DeleteByTimeInterval([FromQuery] string start, [FromQuery] string end)
        {
            if (
                DateTime.TryParse(start, out DateTime startIntervalValue) &&
                DateTime.TryParse(end, out DateTime endIntervalValue)
            )
            {
                for (int i = 0; i < _weatherDiary.Entries.Count; i++)
                {
                    if (startIntervalValue <= _weatherDiary.Entries[i].Time &&
                        _weatherDiary.Entries[i].Time <= endIntervalValue
                    )
                    {
                        _weatherDiary.Entries.Remove(_weatherDiary.Entries[i]);
                    }
                }

                return Ok();
            }

            return BadRequest("невалидные данные");
        }
    }
}
