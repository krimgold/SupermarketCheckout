using SupermarketCheckout.Discount;
using System;
using System.Linq;

namespace SupermarketCheckout.Purchase
{
	public class PurchaseManager : IPurchaseManager
	{
		IDiscountManager _discount;
		public PurchaseManager(IDiscountManager discount)
		{
			_discount = discount;
		}

		public double GetPurchaseTotal(CustomerPurchase purchase)
		{
			if (purchase is null)
			{
				throw new ArgumentNullException();
			}

			var purchaseTotal = purchase.GetAllItems()
				.GroupBy(i => i.ItemType)
				.Sum(g => _discount.ApplyDiscount(g.ToList()));

			return purchaseTotal;
		}
	}
}
