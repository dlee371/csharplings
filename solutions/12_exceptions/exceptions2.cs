// exceptions2.cs — solution

var elevator = new Elevator(topFloor: 10);
elevator.GoTo(5);
Check.Equal(5, elevator.CurrentFloor);

Check.Throws<ArgumentOutOfRangeException>(() => elevator.GoTo(11));
Check.Throws<ArgumentOutOfRangeException>(() => elevator.GoTo(-1));
Check.Equal(5, elevator.CurrentFloor);

elevator.InMaintenance = true;
var error = Check.Throws<InvalidOperationException>(() => elevator.GoTo(1));
Check.Equal("Elevator is under maintenance", error.Message);
Check.Equal(5, elevator.CurrentFloor);

Check.Throws<ArgumentException>(() => new Elevator(topFloor: 0));

class Elevator
{
    public int TopFloor { get; }
    public int CurrentFloor { get; private set; }
    public bool InMaintenance { get; set; }

    public Elevator(int topFloor)
    {
        if (topFloor < 1)
        {
            throw new ArgumentException("An elevator needs at least two floors", nameof(topFloor));
        }
        TopFloor = topFloor;
    }

    public void GoTo(int floor)
    {
        if (InMaintenance)
        {
            throw new InvalidOperationException("Elevator is under maintenance");
        }
        if (floor < 0 || floor > TopFloor)
        {
            throw new ArgumentOutOfRangeException(nameof(floor), $"Floor must be between 0 and {TopFloor}");
        }
        CurrentFloor = floor;
    }
}
