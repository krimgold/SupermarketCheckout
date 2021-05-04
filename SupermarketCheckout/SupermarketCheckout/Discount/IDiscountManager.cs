using SupermarketCheckout.Item;
using System.Collections.Generic;

namespace SupermarketCheckout.Discount
{
	public interface IDiscountManager
	{
		double ApplyDiscount(List<PurchasedItem> items);
	}
}
