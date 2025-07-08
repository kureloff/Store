using System;
using System.Collections.Generic;
using System.Linq;

public class Warehouse
{
    private Dictionary<Product, int> _goods;

    public event Action<Dictionary<Product, int>> GoodsChanged;

    public Warehouse()
    {
        _goods = new Dictionary<Product, int>();
    }

    public void Delive(Product good, int count)
    {
        if (good == null)
            throw new ArgumentNullException(nameof(good));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        foreach (Product goodKey in _goods.Keys)
        {
            if (good == goodKey)
            {
                _goods[goodKey] += count;
                return;
            }
        }

        _goods.Add(good, count);
    }

    public void ShowAllGoods()
    {
        foreach (Product goodKey in _goods.Keys)
            Console.WriteLine($"Наименование: {goodKey.Name} Количество: {_goods[goodKey]}");
    }

    public Dictionary<Product, int> GetGoods()
    {
        return _goods.ToDictionary(item => item.Key, item => item.Value);
    }

    public void RemoveGoods(Product good, int count)
    {
        if (good == null)
            throw new ArgumentNullException(nameof(good));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        foreach (Product goodKey in _goods.Keys)
        {
            if(good == goodKey)
            {
                if (_goods[goodKey] >= count)
                {
                    _goods[goodKey] -= count;
                    GoodsChanged?.Invoke(_goods);
                    return;
                }

                if (_goods[goodKey] <= 0)
                {
                    _goods.Remove(goodKey);
                    GoodsChanged?.Invoke(_goods);
                    return;
                }
            }
        }
    }
}
