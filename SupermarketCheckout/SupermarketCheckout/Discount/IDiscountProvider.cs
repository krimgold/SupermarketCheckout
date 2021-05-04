using SupermarketCheckout.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.Discount
{
	public interface IDiscountProvider
	{
		Discount GetDiscount(ItemType type);
	}
}
