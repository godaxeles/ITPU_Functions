using System.Collections.Generic;
using System.Linq;
using Functions.Task4.ThirdParty;

namespace Functions.Task4
{
    public class Order
    {
        public IList<IProduct> Products { get; set; }

        public double GetPriceOfAvailableProducts()
        {
            CleanNotAvailableProducts();
            return CalculateOrderPrice();
        }

        private double CalculateOrderPrice()
        {
            var orderPrice = 0.0;
            
            foreach (var product in Products)
            {
                orderPrice += product.GetProductPrice();
            }

            return orderPrice;
        }

        private void CleanNotAvailableProducts()
        {
            IEnumerator<IProduct> enumerator = Products.ToList().GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                RemoveProduct(enumerator);
            }
        }

        private void RemoveProduct(IEnumerator<IProduct> enumerator)
        {
            var currentProduct = enumerator.Current;
                
            if (IsNotAvailableProduct(currentProduct))
            {
                Products.Remove(currentProduct);
            }
        }

        private bool IsNotAvailableProduct(IProduct product)
        {
            return product != null && !product.IsAvailable();
        }
    }
}
