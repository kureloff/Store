using System;
using System.Collections.Generic;
using System.Linq;

public class Warehouse
{
    private Dictionary<Product, int> _products;

    public event Action<Dictionary<Product, int>> GoodsChanged;

    public Warehouse()
    {
        _products = new Dictionary<Product, int>();
    }

    public void AddProduct(Product product, int count)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        foreach (Product productKey in _products.Keys)
        {
            if (product == productKey)
            {
                _products[productKey] += count;
                return;
            }
        }

        _products.Add(product, count);
    }

    public void ShowAllGoods()
    {
        foreach (Product productKey in _products.Keys)
            Console.WriteLine($"Наименование: {productKey.Name} Количество: {_products[productKey]}");
    }

    public Dictionary<Product, int> GetGoods()
    {
        return _products.ToDictionary(item => item.Key, item => item.Value);
    }

    public void RemoveGoods(Product product, int count)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        foreach (Product productKey in _products.Keys)
        {
            if(product == productKey)
            {
                if (_products[productKey] >= count)
                {
                    _products[productKey] -= count;
                    GoodsChanged?.Invoke(_products);
                    return;
                }

                if (_products[productKey] <= 0)
                {
                    _products.Remove(productKey);
                    GoodsChanged?.Invoke(_products);
                    return;
                }
            }
        }
    }
}
