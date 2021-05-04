using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SupermarketCheckout.Discount;
using SupermarketCheckout.Item;
using SupermarketCheckout.Purchase;
using System;
using System.Diagnostics.CodeAnalysis;

namespace SupermarketCheckoutTests
{
	[ExcludeFromCodeCoverage]
	[TestClass]
	public class PurchaseManagerTests
	{
		readonly CustomerPurchase _purchase;
		readonly DiscountManager _discountManager;
		readonly PurchaseManager _purchaseManager;

		public PurchaseManagerTests()
		{
			_purchase = new CustomerPurchase();
			_discountManager = new DiscountManager(new TestDiscountProvider());
			_purchaseManager = new PurchaseManager(_discountManager);
		}

		[TestMethod]
		public void GetPurchaseTotal_NoDiscount()
		{
			_purchase.AddItem(new PurchasedItem(ItemType.Apple, 0.5));
			_purchase.AddItem(new PurchasedItem(ItemType.Apple, 0.5));
			_purchase.AddItem(new PurchasedItem(ItemType.Apple, 0.5));

			var total = _purchaseManager.GetPurchaseTotal(_purchase);

			Assert.AreEqual(1.5, total);
		}

		[TestMethod]
		public void GetPurchaseTotal_NoPurchasedItems()
		{
			var total = _purchaseManager.GetPurchaseTotal(_purchase);

			Assert.AreEqual(0, total);
		}

		[TestMethod]
		public void GetPurchaseTotal_OnePurchasedItemWithDiscount()
		{
			_purchase.AddItem(new PurchasedItem(ItemType.Apple, 0.5));
			_purchase.AddItem(new PurchasedItem(ItemType.Banana, 0.7));

			var total = _purchaseManager.GetPurchaseTotal(_purchase);

			Assert.AreEqual(1.2, total);
		}

		[TestMethod]
		public void GetPurchaseTotal_MultiplePurchasedItemsWithDiscount()
		{
			_purchase.AddItem(new PurchasedItem(ItemType.Apple, 0.5));
			_purchase.AddItem(new PurchasedItem(ItemType.Banana, 0.7));
			_purchase.AddItem(new PurchasedItem(ItemType.Banana, 0.7));
			_purchase.AddItem(new PurchasedItem(ItemType.Orange, 0.45));
			_purchase.AddItem(new PurchasedItem(ItemType.Orange, 0.45));
			_purchase.AddItem(new PurchasedItem(ItemType.Orange, 0.45));

			var total = _purchaseManager.GetPurchaseTotal(_purchase);

			Assert.AreEqual(2.4, total);
		}

		[TestMethod]
		public void GetPurchaseTotal_NullPurchase_ShouldThrow()
		{
			Assert.ThrowsException<ArgumentNullException>(() => _purchaseManager.GetPurchaseTotal(null));
		}
	}
}
