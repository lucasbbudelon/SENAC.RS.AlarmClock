using System;

namespace SENACRS.ADS.AlarmClock.Model
{
   public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Time(decimal hour, decimal minute, decimal second)
        {
            Hour = Convert.ToInt32(hour);
            Minute = Convert.ToInt32(minute);
            Second = Convert.ToInt32(second);
        }

        public string TimeFormat
        {
            get
            {
                return String.Format("{0:D2}:{1:D2}:{2:D2}", Hour, Minute, Second);
            }
        }
    }
}
