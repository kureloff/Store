using System;

public class Product
{
    private string _name;

    public Product(string name)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name => _name;
}
