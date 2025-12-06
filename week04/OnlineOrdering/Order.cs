using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost based on whether customer lives in USA
        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        // Packing label: list name and product id of each product
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product p in _products)
        {
            sb.AppendLine($"Product: {p.GetName()}  (ID: {p.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        // Shipping label: customer name and full address
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}
