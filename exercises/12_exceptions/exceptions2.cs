// exceptions2.cs
//
// Throw exceptions when your code is used incorrectly. Fail loudly and early!
//
//     throw new ArgumentException("Amount must be positive", nameof(amount));
//     throw new ArgumentOutOfRangeException(nameof(floor), "No such floor");
//     throw new InvalidOperationException("Can't do that right now");
//
// Which one?
//   * ArgumentException (or a subclass like ArgumentOutOfRangeException or
//     ArgumentNullException) → the CALLER passed a bad argument.
//   * InvalidOperationException → the arguments are fine, but the object is in
//     the wrong state for this operation right now.
//
// `nameof(x)` gives the name of x as a string ("x") — and stays correct if you rename x.

// I AM NOT DONE

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
        // TODO: an elevator needs at least floors 0 and 1. Throw an ArgumentException if topFloor < 1.
        TopFloor = topFloor;
    }

    public void GoTo(int floor)
    {
        // TODO: throw an InvalidOperationException("Elevator is under maintenance") if in maintenance
        // TODO: throw an ArgumentOutOfRangeException if the floor doesn't exist (below 0 or above TopFloor)
        CurrentFloor = floor;
    }
}
