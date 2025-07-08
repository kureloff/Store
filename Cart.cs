using System;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
    private Dictionary<Product, int> _productsWarehouse;
    private Dictionary<Product, int> _products;

    public Action<Dictionary<Product, int>> OrderPurchased;

    public Cart(Dictionary<Product, int> goodsWarehouse)
    {
        _productsWarehouse = goodsWarehouse ?? throw new ArgumentNullException(nameof(goodsWarehouse));
        _products = new Dictionary<Product, int>();
    }

    public void AddProduct(Product product, int count)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        foreach (Product productKey in _productsWarehouse.Keys)
        {
            if (product != productKey)
                continue;

            if (count > _productsWarehouse[productKey])
            {
                Console.WriteLine($"Товар {productKey.Name} в количестве {count} - нет на складе");
                return;
            }

            if (_products.ContainsKey(product))
            {
                _products[product] += count;
                return;
            }

            _products.Add(product, count);
        }
    }

    public Order GetOrder()
    {
        OrderPurchased?.Invoke(_products.ToDictionary(item => item.Key, item => item.Value));
        _products.Clear();

        return new Order();
    }

    public void ShowAllGoods()
    {
        foreach (Product productKey in _products.Keys)
        {
            Console.WriteLine($"Наименование: {productKey.Name} Количество: {_products[productKey]}");
        }
    }

    public void UpdateGoodsInfo(Dictionary<Product, int> products)
    {
        _productsWarehouse = products ?? throw new ArgumentNullException(nameof(products));
    }
}