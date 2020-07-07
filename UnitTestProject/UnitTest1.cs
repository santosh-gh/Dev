using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillingApp;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {       
        [TestMethod]
        public void Test_MultiSkuOrder()
        {
            PromoEngine pe = new PromoEngine();
            double price = pe.MultiSkuOrder(1,3);           
            Assert.AreEqual(price, 130);                  
        }
        [TestMethod]
        public void Test_ComboSkuOrder()
        {
            PromoEngine pe = new PromoEngine();
            double price = pe.ComboSkuOrder(1);
            Assert.AreEqual(price, 0);
        }
        [TestMethod]
        public void Test_PercentageDiscountSkuOrderr()
        {
            PromoEngine pe = new PromoEngine();
            double price = pe.PercentageDiscountSkuOrder(1, 5);
            Assert.AreEqual(price, 12.5);
        }
    }
}
