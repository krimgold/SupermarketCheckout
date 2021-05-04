using Microsoft.Extensions.DependencyInjection;
using SupermarketCheckout.Purchase;
using SupermarketCheckout.Discount;
using System;
using SupermarketCheckout.Item;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SupermarketCheckout
{
	[ExcludeFromCodeCoverage]
	class Program
	{
		static void Main(string[] args)
		{
			if (args == null)
				return;

			var serviceProvider = new ServiceCollection()
			.AddTransient<IDiscountProvider, DiscountProvider>()
			.AddTransient<IDiscountManager, DiscountManager>()
			.AddTransient<IPurchaseManager, PurchaseManager>()
			.BuildServiceProvider();

			var purchase = new CustomerPurchase();
			var prices = new Dictionary<ItemType, double>()
			{
				{ ItemType.Apple, 0.5 },
				{ ItemType.Banana, 0.7 },
				{ ItemType.Orange, 0.45 },
			};

			foreach (var item in args)
			{
				if (Enum.TryParse(item, out ItemType type) 
					&& prices.TryGetValue(type, out double price))
				{
					purchase.AddItem(new PurchasedItem(type, price));
				}
			}

			var total = serviceProvider.GetService<IPurchaseManager>().GetPurchaseTotal(purchase);
			Console.WriteLine($"The total of purchases is: {total} pounds");
			Console.ReadKey();
		}
	}
}
