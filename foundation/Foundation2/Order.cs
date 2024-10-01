class Order
{
	private Customer _customer;
	private List<Product> _products;

	public Order(Customer customer)
	{
		_customer = customer;
		_products = new List<Product>();
	}

	public void AddProduct(Product product)
	{
		_products.Add(product);
	}

	public double CalculateTotalCost()
	{
		double totalCost = _customer.IsInUSA() ? 5 : 35;
		foreach (Product product in _products)
		{
			totalCost += (product.GetPrice() * product.GetQuantity());
		}
		return totalCost;
	}

	public string GetPackingLabel()
	{
		string label = "";
		foreach (Product product in _products)
		{
			label += $"{product.GetName()}: {product.GetProductId()}\n";
		}
		return label;
	}

	public string GetShippingLabel()
	{
		return $"Name: {_customer.GetName()}\nAddress: {_customer.GetAddress().GetAddressString()}";
	}
}