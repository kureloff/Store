public class Order
{
    private string _paylink;

    public Order()
    {
        _paylink = GeneratedPaylink();
    }

    public string Paylink => _paylink;

    private string GeneratedPaylink() =>
        "https://example.com/pay?orderId=123";
}