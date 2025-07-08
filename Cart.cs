using System;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
    private Dictionary<Product, int> _goodsWarehouse;
    private Dictionary<Product, int> _goods;

    public Action<Dictionary<Product, int>> Ordered;

    public Cart(Dictionary<Product, int> goodsWarehouse)
    {
        _goodsWarehouse = goodsWarehouse;
        _goods = new Dictionary<Product, int>();
    }

    public void Add(Product product, int count)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        foreach (Product productKey in _goodsWarehouse.Keys)
        {
            if (product != productKey)
                continue;

            if (count > _goodsWarehouse[productKey])
            {
                Console.WriteLine($"Товар {productKey.Name} в количестве {count} - нет на складе");
                return;
            }

            if (_goods.ContainsKey(product))
            {
                _goods[product] += count;
                return;
            }

            _goods.Add(product, count);
        }
    }

    public Order Order()
    {
        Ordered?.Invoke(_goods.ToDictionary(item => item.Key, item => item.Value));
        _goods.Clear();

        return new Order();
    }

    public void ShowAllGoods()
    {
        foreach (Product productKey in _goods.Keys)
        {
            Console.WriteLine($"Наименование: {productKey.Name} Количество: {_goods[productKey]}");
        }
    }

    public void UpdateGoodsInfo(Dictionary<Product, int> goods)
    {
        _goodsWarehouse = goods;
    }
}