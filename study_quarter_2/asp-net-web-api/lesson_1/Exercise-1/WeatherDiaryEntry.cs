using System;

namespace Exercise_1
{
    public class WeatherDiaryEntry
    {
        private DateTime _time;
        private sbyte _temperature;

        public WeatherDiaryEntry(DateTime time, sbyte temperature)
        {
            _time = time;
            _temperature = temperature;
        }

        public DateTime Time
        {
            get => _time;
        }

        public sbyte Temperature
        {
            get => _temperature;
        }
    }
}
