// enums1.cs
//
// An enum is a type with a fixed set of named values:
//
//     enum Direction { North, East, South, West }
//
//     Direction d = Direction.North;
//     d.ToString()                      // "North"
//     (int)d                            // 0 — enums are numbers under the hood
//     Enum.Parse<Direction>("West")     // Direction.West
//
// Prefer enums over "magic strings" like "pending" — the compiler catches typos for you.

// I AM NOT DONE

var order = new Order();
Check.Equal(OrderStatus.Pending, order.Status);

order.Advance();
Check.Equal(OrderStatus.Paid, order.Status);
order.Advance();
Check.Equal(OrderStatus.Shipped, order.Status);
order.Advance();
Check.Equal(OrderStatus.Delivered, order.Status);
order.Advance();   // already delivered: nothing changes
Check.Equal(OrderStatus.Delivered, order.Status);

var cancelled = new Order();
cancelled.Cancel();
cancelled.Advance();   // cancelled orders stay cancelled
Check.Equal(OrderStatus.Cancelled, cancelled.Status);

Check.Equal("Shipped", OrderStatus.Shipped.ToString());
Check.Equal(OrderStatus.Cancelled, Enum.Parse<OrderStatus>("Cancelled"));
Check.Equal(1, (int)OrderStatus.Paid);

// TODO: define the OrderStatus enum: Pending, Paid, Shipped, Delivered, Cancelled

class Order
{
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public void Cancel() => Status = OrderStatus.Cancelled;

    public void Advance()
    {
        // TODO: use a switch statement on Status to move to the next status.
        //       Pending → Paid → Shipped → Delivered.
        //       Delivered and Cancelled orders stay as they are.
    }
}
