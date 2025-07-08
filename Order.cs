public class Order
{
    private string _paylink;

    public Order()
    {
        _paylink = "https://example.com/pay?orderId=123";
    }

    public string Paylink => _paylink;
}