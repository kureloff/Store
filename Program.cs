using System;

internal class Program
{
    static void Main(string[] args)
    {
        Product iPhone12 = new Product("IPhone 12");
        Product iPhone11 = new Product("IPhone 11");

        Warehouse warehouse = new Warehouse();

        Shop shop = new Shop(warehouse);

        warehouse.AddProduct(iPhone12, 10);
        warehouse.AddProduct(iPhone11, 1);

        warehouse.ShowAllGoods();

        Cart cart = shop.CreateCart();
        cart.AddProduct(iPhone12, 4);
        cart.AddProduct(iPhone11, 3);

        cart.ShowAllGoods();

        Console.WriteLine(cart.GetOrder().Paylink);

        cart.AddProduct(iPhone12, 9);
    }
}
