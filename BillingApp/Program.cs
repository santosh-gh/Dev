using System;

namespace BillingApp
{
    public class PromoEngine
    {

        public void Display()
        {
            Console.Write("Hallo World! ");
        }

        public class Sku
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class MultiOrderProm
        {
            public int Id { get; set; }
            public int ItemCount { get; set; }
            public double Amount { get; set; }

        }


        public class ComboOrder
        {
            public int Id { get; set; }
            //public List<int> Items { get; set; }
            public double Amount { get; set; }

        }

        public class PercentDiscountPromo
        {
            public int Id { get; set; }
            public int percent { get; set; }

        }

        public class Order
        {
            public Order(int _Id, int _quantity)
            {
                Id = _Id;
                quantity = _quantity;
            }

            public int Id { get; set; }
            public int quantity { get; set; }
        }

        public class PromoType
        {
            public double MultiSkuOrder(int id, int count)
            {

                return 0;
            }
            public double ComboSkuOrder1(long ComboPrice, params string[] IdList)
            {

                return 0;
            }
            public double PercentageDiscountSkuOrder(int id, int count)
            {
                return 0;
            }
            public void CheckoutOrder(int id, int count)
            {


            }
            public void CancelOrder(long ComboPrice, params string[] IdList)
            {

            }

        }


        static void Main(string[] args)
        {
            Console.Write("Enter 1 for new order or 0 for Exit: ");
        }
    }
}
