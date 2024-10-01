class Product
{
	private string _name;
	private int _productId;
	private double _price;
	private int _quantity;

	public Product(string name, int productId, double price, int quantity)
	{
		_name = name;
		_productId = productId;
		_price = price;
		_quantity = quantity;
	}

	public string GetName()
	{
		return _name;
	}

	public int GetProductId()
	{
		return _productId;
	}

	public double GetPrice()
	{
		return _price;
	}

	public int GetQuantity()
	{
		return _quantity;
	}
}