using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.Item
{
	public class PurchasedItem
	{
		public readonly ItemType ItemType;
		public readonly double Price;

		public PurchasedItem(ItemType type, double price)
		{
			ItemType = type;
			Price = price;
		}
	}
}
