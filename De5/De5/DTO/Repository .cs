using System;
using System.Collections.Generic;
using De5.Models;

public class Repository 
{
	private readonly OnlineShopContext _context;
	public Repository(OnlineShopContext context)
	{
		_context = context;
	}
	public List<Product> GetProducts()
	{
		var products = _context.Products.ToList();
		return products;
	}
	public List<Product> GetProductsBy()
	{
		var products = _context.Products.Where(p => p.Available == true).ToList();
		return products;
	}
	public Product FindProduct(int id)
	{
		var product = _context.Products.Find(id);
		return product;
	}
	public List<Category> GetCategories()
	{
		var categories = _context.Categories.ToList();
		return categories;
	}
	public Category FindCategory(int id)
	{
		var category = _context.Categories.Find(id);
		return category;
	}
	public List<Product> GetProductsByName(string key)
	{
		var products = _context.Products.Where(p => p.Name.Contains(key)).ToList();
		return products;
	}
	public List<Product> GetProductsByCategory(int id)
	{
		if (id == 0)
		{
			return GetProductsBy();
		}
		var products = _context.Products.Where(p => p.CategoryId == id).ToList();
		return products;
	}
}
