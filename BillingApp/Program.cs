using System;
using System.Collections.Generic;

namespace BillingApp
{
    public class PromoEngine
    {
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

                var count = MultiOrderPromList[index].ItemCount;
                var amount = MultiOrderPromList[index].Amount;

                int quotient = orderCount / count;
                int reminder = orderCount % count;

                if (quotient > 0)
                {
                    flagMutualExclusive = true;
                    totalItemPrice = quotient * amount + reminder * itemPrice;
                }
            }

            return totalItemPrice;
        }

        public double ComboSkuOrder(int id)
        {
            double totalItemPrice = 0;
            int cnt = 0;
            foreach (var ComboList in ComboOrderList)
            {
                cnt = 0;
                if (ComboList.Id == id)
                {
                    bool bflag = false;
                    foreach (var orderItem in OrderList)
                    {
                        if (orderItem.quantity > 0)
                        {

                            foreach (var it in ComboList.Items)
                            {
                                if (orderItem.Id == it)
                                {
                                    cnt++;
                                    continue;
                                }
                            }
                        }
                    }

                    if (cnt == ComboList.Items.Count)
                    {
                        totalItemPrice = ComboList.Amount;

                        foreach (var orderItem in OrderList)
                        {
                            if (orderItem.quantity > 0)
                            {
                                foreach (var it in ComboList.Items)
                                {
                                    if (orderItem.Id == it)
                                    {
                                        orderItem.quantity--;
                                        continue;
                                    }
                                }
                            }

                        }

                    }
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
            PromoEngine engine = new PromoEngine();
            while (true)
            {
                OrderList.Clear();
                double totalAmount = 0;
                string item = String.Empty;
                string itemqty = String.Empty;
                int qty = 0;
                int id = 0;

                while (true)
                {
                    try
                    {
                        Console.Write("Enter the item ID for Order - Available Item Ids {1=A,2=B,3=C,4=D}: ");
                        item = Console.ReadLine();
                        id = Convert.ToInt32(item);
                        Console.WriteLine();

                        Console.Write("Enter the Item Quantity: ");
                        itemqty = Console.ReadLine();
                        qty = Convert.ToInt32(itemqty);
                        Console.WriteLine();

                        Order newitem = new Order(id, qty);
                        OrderList.Add(newitem);


                        Console.Write("Enter 1 to continue Purchase or 0 for checkin out Order:");
                        string continuePurchase = Console.ReadLine();
                        int contPur = Convert.ToInt32(continuePurchase);

                        Console.WriteLine();

                        if (0 == contPur) break;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                foreach (var orderItem in OrderList)
                {
                    if (false == flagMutualExclusive)
                        totalAmount += engine.MultiSkuOrder(orderItem.Id, orderItem.quantity);

                    if (false == flagMutualExclusive)
                    {
                        int counter = orderItem.quantity;
                        while (counter > 0)
                        {
                            totalAmount += engine.ComboSkuOrder(orderItem.Id);
                            counter--;
                        }
                    }


                    if (false == flagMutualExclusive)
                    {
                        var itemPrice = items[orderItem.Id - 1].Price;
                        totalAmount += itemPrice * orderItem.quantity;
                    }

                    flagMutualExclusive = false;

                }

                Console.WriteLine("Total bill Amount = {0}", totalAmount);
                Console.WriteLine();
                try
                {
                    Console.Write("Enter 1 for new order or 0 for Exit: ");
                    string continueOrder = Console.ReadLine();
                    int contOrd = Convert.ToInt32(continueOrder);
                    Console.WriteLine("---------------------------------------------------------");
                    if (0 == contOrd) return;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
