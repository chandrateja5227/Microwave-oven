
namespace Microwave_oven
{
    public interface IMicrowaveOvenHW
    {
        /// Turns on the Microwave heater element
        void TurnOnHeater();

        /// Turns off the Microwave heater element
        void TurnOffHeater();

        /// Indicates if the door to the Microwave oven is open or closed        
        bool DoorOpen { get; }

        /// Signal if the Door is opened or closed,
        event Action<bool> DoorOpenChanged;
 
        /// Signals that the Start button is pressed
        event EventHandler StartButtonPressed;
    }
}
