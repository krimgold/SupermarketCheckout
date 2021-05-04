using Microsoft.VisualStudio.TestTools.UnitTesting;
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
	[TestClass]
	public class DiscountProviderTests
	{
		DiscountProvider _discountProvider;
		public DiscountProviderTests()
		{
			_discountProvider = new DiscountProvider();
		}

		[TestMethod]
		public void GetDiscount_Banana_ShouldReturnCorrectDiscount()
		{
			var discount = _discountProvider.GetDiscount(ItemType.Banana);
			Assert.AreEqual(2, discount.NumberOfItems);
			Assert.AreEqual(1, discount.DiscountedPrice);
		}

		[TestMethod]
		public void GetDiscount_Orange_ShouldReturnCorrectDiscount()
		{
			var discount = _discountProvider.GetDiscount(ItemType.Orange);
			Assert.AreEqual(3, discount.NumberOfItems);
			Assert.AreEqual(0.9, discount.DiscountedPrice);
		}
	}
}
