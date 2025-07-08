using System;

internal class Program
{
    static void Main(string[] args)
    {
        Product iPhone12 = new Product("IPhone 12");
        Product iPhone11 = new Product("IPhone 11");

        Warehouse warehouse = new Warehouse();

        Shop shop = new Shop(warehouse);

        warehouse.Delive(iPhone12, 10);
        warehouse.Delive(iPhone11, 1);

        warehouse.ShowAllGoods();

        Cart cart = shop.Cart();
        cart.Add(iPhone12, 4);
        cart.Add(iPhone11, 3);

        cart.ShowAllGoods();

        Console.WriteLine(cart.Order().Paylink);

        cart.Add(iPhone12, 9);
    }
}
