using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillingApp;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Display()
        {
            PromoEngine pe = new PromoEngine();
            pe.Display();
        }
        [TestMethod]
        public void Test_MultiSkuOrder()
        {
            PromoEngine pe = new PromoEngine();
            pe.MultiSkuOrder(1,5);
        }
    }
}
