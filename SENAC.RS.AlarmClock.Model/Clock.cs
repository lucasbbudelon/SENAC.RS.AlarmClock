using System.Threading;

namespace SENAC.RS.AlarmClock.Model
{
    public class Clock : Time
    {
        public int MaxHour { get; }
        public int MaxMinute { get; }
        public int MaxSecond { get; }

        public Alarm Alarm { get; set; }

        public Clock(decimal hour, decimal minute, decimal second) : base(hour, minute, second)
        {
            MaxHour = 23;
            MaxMinute = 59;
            MaxSecond = 59;
        }

        public void SpendTime()
        {
            Thread.Sleep(1000);

            Second++;

            if (Second == MaxSecond)
            {
                Second = 0;
                Minute++;
            }

            if (Minute == MaxMinute)
            {
                Minute = 0;
                Hour++;
            }

            if (Hour == MaxHour)
            {
                Hour = 0;
            }
        }

        public bool IsTimeForAlarm()
        {
            return Alarm.Hour == Hour && Alarm.Minute == Minute && Alarm.Second == Second;
        }
    }
}
