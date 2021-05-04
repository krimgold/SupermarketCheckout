using SupermarketCheckout.Item;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketCheckout.Discount
{
	public class DiscountManager : IDiscountManager
	{
		IDiscountProvider _discountProvider;

		public DiscountManager(IDiscountProvider discountProvider)
		{
			_discountProvider = discountProvider;
		}

		public double ApplyDiscount(List<PurchasedItem> items)
		{
			var itemsType = items.Select(i => i.ItemType).First();
			var itemRegularPrice = items.Select(i => i.Price).First();

			var discount = _discountProvider.GetDiscount(itemsType);
			
			if (discount == null || items.Count == 1)
			{
				return items.Count * itemRegularPrice;
			}

			var discountedItemstotal = items.Count / discount.NumberOfItems * discount.DiscountedPrice;
			var regularItemsTotal = items.Count % discount.NumberOfItems * itemRegularPrice;

			return discountedItemstotal + regularItemsTotal;
		}
	}
}
