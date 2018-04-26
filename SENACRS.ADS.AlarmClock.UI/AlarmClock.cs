using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using SENACRS.ADS.AlarmClock.Model;

namespace SENACRS.ADS.AlarmClock.UI
{
    public partial class AlarmClock : Form
    {
        private delegate void ChangeClockCallback();

        private Thread ThreadAlarmClock1;
        private Thread ThreadAlarmClock2;
        private Thread ThreadAlarmClock3;

        public AlarmClock()
        {
            InitializeComponent();

            ThreadAlarmClock1 = new Thread(() =>
            {
                var clock = new Clock(numClockStartHour1.Value, numClockStartMinute1.Value, numClockStartSecond1.Value)
                {
                    Alarm = new Alarm(numAlarmHour1.Value, numAlarmMinute1.Value, numAlarmSecond1.Value, "ALARM 01!")
                };

                ProcessAlarmClock(lblClock1, clock);
            });

            ThreadAlarmClock2 = new Thread(() =>
            {
                var clock = new Clock(numClockStartHour2.Value, numClockStartMinute2.Value, numClockStartSecond2.Value)
                {
                    Alarm = new Alarm(numAlarmHour2.Value, numAlarmMinute2.Value, numAlarmSecond2.Value, "ALARM 02!")
                };

                ProcessAlarmClock(lblClock2, clock);
            });

            ThreadAlarmClock3 = new Thread(() =>
            {
                var clock = new Clock(numClockStartHour3.Value, numClockStartMinute3.Value, numClockStartSecond3.Value)
                {
                    Alarm = new Alarm(numAlarmHour3.Value, numAlarmMinute3.Value, numAlarmSecond3.Value, "ALARM 03!")
                };

                ProcessAlarmClock(lblClock3, clock);
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ThreadAlarmClock1.Start();
            ThreadAlarmClock2.Start();
            ThreadAlarmClock3.Start();

            FreezeFields();
        }

        private void ProcessAlarmClock(Label label, Clock clock)
        {
            while (clock.Second <= clock.MaxSecond && clock.Minute <= clock.MaxMinute)
            {
                clock.SpendTime();

                ChangeClockCallback changeClock = () =>
                {
                    label.Text = clock.TimeFormat;
                };
                Invoke(changeClock);

                CheckTimeAlarm(clock);
            }
        }

        public void CheckTimeAlarm(Clock clock)
        {
            if (clock.IsTimeForAlarm())
            {
                Thread threadAlarmShot = new Thread(() =>
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show($"{clock.Alarm.Message} | {clock.Alarm.TimeFormat}");
                });

                threadAlarmShot.Start();
            }
        }

        private void FreezeFields()
        {
            numClockStartHour1.Enabled = false;
            numClockStartMinute1.Enabled = false;
            numClockStartSecond1.Enabled = false;

            numAlarmHour1.Enabled = false;
            numAlarmMinute1.Enabled = false;
            numAlarmSecond1.Enabled = false;


            numClockStartHour2.Enabled = false;
            numClockStartMinute2.Enabled = false;
            numClockStartSecond2.Enabled = false;

            numAlarmHour2.Enabled = false;
            numAlarmMinute2.Enabled = false;
            numAlarmSecond2.Enabled = false;


            numClockStartHour3.Enabled = false;
            numClockStartMinute3.Enabled = false;
            numClockStartSecond3.Enabled = false;

            numAlarmHour3.Enabled = false;
            numAlarmMinute3.Enabled = false;
            numAlarmSecond3.Enabled = false;

            btnStart.Enabled = false;
        }
    }
}
