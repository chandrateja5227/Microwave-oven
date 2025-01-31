using System.Timers;
using Timer = System.Timers.Timer;

namespace Microwave_oven
{
    public class Microwave : IMicrowaveOvenHW
    {
        private Timer _timer;

        public bool DoorOpen { get; private set; }
        public event Action<bool> DoorOpenChanged = delegate { };
        public event EventHandler StartButtonPressed = delegate { };
        private bool IsHeaterIsOn { get; set; }

        public Microwave()
        {
            _timer = new Timer(60000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = false;
        }

        public void TurnOnHeater()
        {
            if (!DoorOpen)
            {
                if (!IsHeaterIsOn)
                {
                    IsHeaterIsOn = true;
                    Status();
                    _timer.Start();
                }
                else
                {
                    Console.WriteLine("- Heater is already on, increasing remaining time by 1 minute");
                    _timer.Interval += 60000;
                    Status();
                }
            }
            else
            {
                Status();
                Console.WriteLine("- Cannot turn on heater, door is open");
            }
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            IsHeaterIsOn = false;
            Status();
        }

        public void TurnOffHeater()
        {

                IsHeaterIsOn = false;
                _timer.Stop();
                _timer.Interval = 60000;
                Status();
            

        }

        public void OpenDoor()
        {
            DoorOpen = true;
            DoorOpenChanged?.Invoke(DoorOpen);
        }

        public void CloseDoor()
        {
            DoorOpen = false;
            DoorOpenChanged?.Invoke(DoorOpen);
        }

        public void PressStartButton()
        {
            StartButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        public void Status()
        {
            Console.Write($"- Light is {(DoorOpen ? "On " : "Off ")}");
            Console.Write($"Door is {(DoorOpen ? "Open" : "Closed")}");
            Console.WriteLine($" and Heater is {(IsHeaterIsOn ? $"On, timer {_timer.Interval}" : "Off")}");
        }
    }
}
