using Microwave_oven;

Microwave microwave = new Microwave();

microwave.DoorOpenChanged += Microwave_DoorOpenChanged;
microwave.StartButtonPressed += Microwave_StartButtonPressed;
microwave.Status();
Console.WriteLine();
Console.WriteLine("Options:");
Console.WriteLine("open - Open the microwave door");
Console.WriteLine("close - Close the microwave door");
Console.WriteLine("start - Press the start button");
Console.WriteLine("stop - Stop the oven");
Console.WriteLine("exit - Exit the program");
while (true)
{


    string? command = Console.ReadLine();
    switch (command)
    {
        case "open":
            microwave.OpenDoor();
            break;
        case "close":
            microwave.CloseDoor();
            break;
        case "start":
            microwave.PressStartButton();
            break;
        case "stop":
            microwave.TurnOffHeater();
            break;
        case "exit":
            return;
        default:
            Console.WriteLine("- Invalid command");
            break;
    }
}

void Microwave_DoorOpenChanged(bool isOpen)
{
    if (isOpen)
    {

        microwave.TurnOffHeater();
        
    }
    else
    {
        microwave.Status();
    }
}

void Microwave_StartButtonPressed(object? sender, EventArgs args)
{    
    
    Console.WriteLine("- Start button pressed");
    microwave.TurnOnHeater();

}