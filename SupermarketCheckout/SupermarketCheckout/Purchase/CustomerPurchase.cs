using SupermarketCheckout.Item;
using System;
using System.Collections.Generic;

namespace SupermarketCheckout.Purchase
{
	public class CustomerPurchase
	{
		List<PurchasedItem> _items = new List<PurchasedItem>();

		public void AddItem(PurchasedItem item)
		{
			if (item is null)
			{
				throw new ArgumentNullException();
			}

			_items.Add(item);
		}

		public void RemoveItem(PurchasedItem item)
		{
			if (item is null)
			{
				throw new ArgumentNullException();
			}

			_items.Remove(item);
		}

		public List<PurchasedItem> GetAllItems()
		{
			return _items;
		}
	}
}
