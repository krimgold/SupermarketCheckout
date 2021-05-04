using SupermarketCheckout.Discount;
using SupermarketCheckout.Item;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutTests
{
	[ExcludeFromCodeCoverage]
	class TestDiscountProvider : IDiscountProvider
	{

		public Discount GetDiscount(ItemType type)
		{
			switch(type)
			{
				case ItemType.Banana:
					return new Discount(2, 1);
				case ItemType.Orange:
					return new Discount(3, 0.9);
				default:
					return null;
			}
		}
	}
}
