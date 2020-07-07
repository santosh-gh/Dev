using System;
using System.Collections.Generic;

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
            public List<int> Items { get; set; }
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
        static bool flagMutualExclusive = false;
        static List<Sku> items = new List<Sku>()
            {
                new Sku{ Id=1, Name="A", Price= 50},
                new Sku{ Id=2, Name="B", Price= 30},
                new Sku{ Id=3, Name="C", Price= 20},
                new Sku{ Id=4, Name="D", Price= 15 }
            };


        static List<MultiOrderProm> MultiOrderPromList = new List<MultiOrderProm>()
            {
                new MultiOrderProm{ Id=1, ItemCount= 3, Amount = 130},
                new MultiOrderProm{ Id=2, ItemCount= 2, Amount = 45 }
            };

        static List<ComboOrder> ComboOrderList = new List<ComboOrder>()
            {
                new ComboOrder{ Id=3, Items = new List<int> {3,4}, Amount = 30}
                //new ComboOrder{ Id=4, Items = new List<int> {1,2,3 }, Amount = 3}
            };



        static List<PercentDiscountPromo> PercentDiscountPromoList = new List<PercentDiscountPromo>()
            {
                new PercentDiscountPromo{ Id=1, percent= 5},
                new PercentDiscountPromo{ Id=2, percent= 3}
            };

        static List<Order> OrderList = new List<Order>();

        public double MultiSkuOrder(int id, int orderCount)
        {
            double totalItemPrice = 0;
            int index = id - 1;
            var itemPrice = items[index].Price;

            if (MultiOrderPromList.Count > index && MultiOrderPromList[index].Id == id)
            {
                flagMutualExclusive = true;
                var count = MultiOrderPromList[index].ItemCount;
                var amount = MultiOrderPromList[index].Amount;

                int quotient = orderCount / count;
                int reminder = orderCount % count;

                totalItemPrice = quotient * amount + reminder * itemPrice;
            }

            return totalItemPrice;
        }

        public double ComboSkuOrder(int id)
        {
            double totalItemPrice = 0;


            foreach (var item in ComboOrderList)
            {
                flagMutualExclusive = true;
                foreach (var item1 in item.Items)
                {
                    
                }
             
            }

            return totalItemPrice;
        }
        public double PercentageDiscountSkuOrder(int id, int count)
        {
            double totalItemPrice = 0;
            int index = id - 1;
            var itemPrice = items[index].Price;

            if (PercentDiscountPromoList.Count > index && PercentDiscountPromoList[index].Id == id)
            {
                flagMutualExclusive = true;
                var percent = PercentDiscountPromoList[index].percent;

                totalItemPrice = count * (itemPrice * percent / 100);
            }

            return totalItemPrice;
        }


        static void Main(string[] args)
        {
            Console.Write(" ");
        }
    }
}
