using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketCheckout.Item;
using SupermarketCheckout.Purchase;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutTests
{
	[ExcludeFromCodeCoverage]
	[TestClass]
	public class CustomerPurchaseTests
	{
		CustomerPurchase _purchase;
		public CustomerPurchaseTests()
		{
			_purchase = new CustomerPurchase();
		}

		[TestMethod]
		public void AddItem_NullItem_ShouldThrow()
		{
			Assert.ThrowsException<ArgumentNullException>(() => _purchase.AddItem(null));
		}


		[TestMethod]
		public void RemoveItem_NullItem_ShouldThrow()
		{
			Assert.ThrowsException<ArgumentNullException>(() => _purchase.RemoveItem(null));
		}

		[TestMethod]
		public void RemoveItem_ShouldRemove()
		{
			var banana = new PurchasedItem(ItemType.Banana, 0.7);
			_purchase.AddItem(new PurchasedItem(ItemType.Apple, 0.5));
			_purchase.AddItem(banana);
			_purchase.AddItem(banana);
			_purchase.RemoveItem(banana);

			var items = _purchase.GetAllItems();

			Assert.AreEqual(2, items.Count);
			Assert.AreEqual(1, items.Count(i => i.ItemType == ItemType.Apple));
			Assert.AreEqual(1, items.Count(i => i.ItemType == ItemType.Banana));
		}
	}
}
