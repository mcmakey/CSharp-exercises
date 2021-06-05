using System;

namespace Exercise_1
{
    public class WeatherDiaryEntry
    {
        private DateTime _time;
        private int _temperature;

        public WeatherDiaryEntry(DateTime time, int temperature)
        {
            _time = time;
            _temperature = temperature;
        }

        public DateTime Time
        {
            get => _time;
        }

        public int Temperature
        {
            get => _temperature;
        }
    }
}
