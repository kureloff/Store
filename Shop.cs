using System;
using System.Collections.Generic;

public class Shop
{
    private Warehouse _warehouse;
    private Cart _cart;

    public Shop(Warehouse warehouse)
    {
        _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        _warehouse.GoodsChanged += UpdateGoodsInfo;
    }

    public Cart GetCart()
    {
        _cart = new Cart(_warehouse.GetGoods());
        _cart.Ordered += RemoveGoods;

        return _cart;
    }

    private void RemoveGoods(Dictionary<Product, int> goods)
    {
        if (goods == null)
            throw new ArgumentNullException(nameof(goods));

        foreach (Product goodKey in goods.Keys)
        {
            _warehouse.RemoveGoods(goodKey, goods[goodKey]);
        }
    }

    private void UpdateGoodsInfo(Dictionary<Product, int> goods)
    {
        _cart.UpdateGoodsInfo(goods);
    }
}