using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.Discount
{
	public class Discount
	{
		public readonly int NumberOfItems;

		public readonly double DiscountedPrice;
		public Discount(int items, double price)
		{
			NumberOfItems = items;
			DiscountedPrice = price;
		}
	}
}
