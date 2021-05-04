using SupermarketCheckout.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.Discount
{
	public class DiscountProvider : IDiscountProvider
	{

		Dictionary<ItemType, Discount> _discounts = new Dictionary<ItemType, Discount>
		{
			{ ItemType.Banana, new Discount(2, 1) },
			{ ItemType.Orange, new Discount(3, 0.9) }
		};
		public Discount GetDiscount(ItemType type)
		{
			_discounts.TryGetValue(type, out Discount discount);
			return discount;
		}
	}
}
