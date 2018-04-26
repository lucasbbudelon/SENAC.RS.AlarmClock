namespace SENACRS.ADS.AlarmClock.Model
{
    public class Alarm : Time
    {
        public string Message { get; set; }

        public Alarm(decimal hour, decimal minute, decimal second, string message) : base(hour, minute, second)
        {
            Message = message;
        }
    }
}
