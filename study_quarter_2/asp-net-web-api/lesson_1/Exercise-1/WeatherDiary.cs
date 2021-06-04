using System.Collections.Generic;

namespace Exercise_1
{
    public class WeatherDiary
    {
        public List<WeatherDiaryEntry> Entries { get; set; }

        public WeatherDiary()
        {
            Entries = new List<WeatherDiaryEntry> { };
        }
    }
}
