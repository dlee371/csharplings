// enums1.cs — solution

var order = new Order();
Check.Equal(OrderStatus.Pending, order.Status);

order.Advance();
Check.Equal(OrderStatus.Paid, order.Status);
order.Advance();
Check.Equal(OrderStatus.Shipped, order.Status);
order.Advance();
Check.Equal(OrderStatus.Delivered, order.Status);
order.Advance();
Check.Equal(OrderStatus.Delivered, order.Status);

var cancelled = new Order();
cancelled.Cancel();
cancelled.Advance();
Check.Equal(OrderStatus.Cancelled, cancelled.Status);

Check.Equal("Shipped", OrderStatus.Shipped.ToString());
Check.Equal(OrderStatus.Cancelled, Enum.Parse<OrderStatus>("Cancelled"));
Check.Equal(1, (int)OrderStatus.Paid);

enum OrderStatus { Pending, Paid, Shipped, Delivered, Cancelled }

class Order
{
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public void Cancel() => Status = OrderStatus.Cancelled;

    public void Advance()
    {
        switch (Status)
        {
            case OrderStatus.Pending:
                Status = OrderStatus.Paid;
                break;
            case OrderStatus.Paid:
                Status = OrderStatus.Shipped;
                break;
            case OrderStatus.Shipped:
                Status = OrderStatus.Delivered;
                break;
        }
    }
}
