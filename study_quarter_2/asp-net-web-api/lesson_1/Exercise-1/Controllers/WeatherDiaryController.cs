using Microsoft.AspNetCore.Mvc;

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
            return Ok();
        }

        [HttpGet("readbytimeinterval")]
        public IActionResult ReadByTimeInterval([FromQuery] string startInterval, [FromQuery] string endInterval)
        {
            return Ok("readbytimeinterval");
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
