﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Assignment
{
    class ReadyOrderState : OrderState
    {
        private Order order;

        public ReadyOrderState(Order order)
        {
            this.order = order;
        }

        public void cancelOrder()
        {
            if (DateTime.Now > order.deliveryDateTime)
            {
                order.state = order.cancelledOrderState;
                foreach (Observer o in order.observers)
                {
                    order.removeObserver(o);
                }
                order.refundCustomer();
                order.archiveOrder();
                Console.WriteLine($"Cancelled Order {order.id}\n");
            }
            else
            {
                Console.WriteLine("Cannot cancel order.\n");
            }
        }

        public void confirmOrder()
        {
            Console.WriteLine($"Cannot confirm Ready Order\n");
        }

        public void deliverOrder()
        {
            Console.WriteLine($"Cannot deliver Ready Order\n");
        }

        public void dispatchOrder()
        {
            // assign first dispatcher and remove the rest
            Dispatcher dispatcher = (Dispatcher)order.observers[0];
            dispatcher.update(order);
            foreach (Observer o in order.observers)
            {
                order.removeObserver(o);
            }
            order.state = order.dispatchedOrderState;
            Console.WriteLine($"Changed Order {order.id} to Dispatched.\n");
        }

        public void prepareOrder()
        {
            Console.WriteLine($"Cannot prepare Ready Order\n");
        }

        public void readyOrder()
        {
            Console.WriteLine($"Order is already Ready\n");
            order.status = "ready";
        }
    }
}
