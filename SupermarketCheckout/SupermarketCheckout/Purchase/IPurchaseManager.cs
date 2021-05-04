using SupermarketCheckout.Purchase;

namespace SupermarketCheckout.Purchase
{
	public interface IPurchaseManager
	{
		double GetPurchaseTotal(CustomerPurchase purchase);
	}
}
