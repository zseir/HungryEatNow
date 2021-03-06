﻿using System;
using static SE_Assignment.MainFunctions;
using static SE_Assignment.HelperFunctions;
//using static SE_Assignment.managerFunctions;

namespace SE_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            InitData();

            Object user = null;
            while (true)
            {
                Console.WriteLine("Login");
                Console.WriteLine("=====");
                Console.WriteLine("1 Customer");
                Console.WriteLine("2 Employee");
                Console.WriteLine("0 Exit");
                Console.Write("Please select an option: ");
                int loginOption = -1;
                try
                {
                    loginOption = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("");

                    string email = "";
                    string password = "";

                    if (loginOption == 1 || loginOption == 2)
                    {
                        user = HandleLogin(loginOption, email, password);
                        if (user is Chef)
                        {
                            DisplayChefMenu((Chef)user);
                        }
                        else if (user is Manager)
                        {
                            DisplayManagerMainMenu((Manager)user);
                        }
                        else if (user is Customer)
                        {
                            DisplayCustomerMenu((Customer)user);
                        }
                    }
                    else if (loginOption == 0) { break; }
                    else
                    {
                        Console.WriteLine("Please enter a valid option!\n");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid option!\n");
                }
            }

            Console.ReadKey();

            // Initialize all data here
            void InitData()
            {
                string password = "123";

                // Customer
                Account customerAccount1 = new Account(1, "customer", password);
                allAccounts.Add(customerAccount1);
                Customer customer1 = new Customer(1, "customer1", "Yew Tee", "87654321", customerAccount1);
                allCustomers.Add(customer1);

                Account customerAccount2 = new Account(2, "customer1@se.com", password);
                allAccounts.Add(customerAccount2);
                Customer customer2 = new Customer(2, "customer2", "Yew Tee", "87654321", customerAccount2);
                allCustomers.Add(customer2);

                // Manager
                Account managerAccount1 = new Account(3, "manager", password);
                allAccounts.Add(managerAccount1);
                Manager manager1 = new Manager(1, "manager1", "T1234567A", "Male", "87654321", DateTime.Now, "Status", managerAccount1, DateTime.Now);
                allEmployees.Add(manager1);

                // Store Assistant
                Account storeAssistantAccount1 = new Account(4, "storeAssistant1@se.com", password);
                allAccounts.Add(storeAssistantAccount1);
                StoreAssistant storeAssistant1 = new StoreAssistant(1, "storeAssistant1", "T1234567A", "Male", "87654321", DateTime.Now, "Status", storeAssistantAccount1);
                allStoreAssistants.Add(storeAssistant1);

                // Chef
                Account chefAccount1 = new Account(5, "chef", password);
                allAccounts.Add(chefAccount1);
                Chef chef1 = new Chef(1, "chef1", "T1234567A", "Male", "87654321", DateTime.Now, "Status", chefAccount1);
                allEmployees.Add(chef1);

                // Dispatcher
                Account dispatcherAccount1 = new Account(6, "dispatcher1@se.com", password);
                allAccounts.Add(dispatcherAccount1);
                Dispatcher dispatcher1 = new Dispatcher(1, "dispatcher1", "T1234567A", "Male", "87654321", DateTime.Now, "Status", dispatcherAccount1);
                allDispatchers.Add(dispatcher1);

                Account dispatcherAccount2 = new Account(7, "dispatcher1@se.com", password);
                allAccounts.Add(dispatcherAccount2);
                Dispatcher dispatcher2 = new Dispatcher(2, "dispatcher2", "T1234567A", "Male", "87654321", DateTime.Now, "Status", dispatcherAccount2);
                allDispatchers.Add(dispatcher2);

                Account dispatcherAccount3 = new Account(8, "dispatcher1@se.com", password);
                allAccounts.Add(dispatcherAccount3);
                Dispatcher dispatcher3 = new Dispatcher(3, "dispatcher2", "T1234567A", "Male", "87654321", DateTime.Now, "Status", dispatcherAccount3);
                allDispatchers.Add(dispatcher3);

                // FoodItem
                Item foodItem1 = new Item(1, "Buttermilk Crispy Chicken", "Crispy whole-muscle chicken thigh flavoured with buttermilk packed in a glazed burger bun.", 9.90, 1, "available");
                Item foodItem2 = new Item(2, "Original Angus Cheeseburger", "Made from all the things you love – two slices of melty cheese, slivered onions and 100% Angus beef.", 11.90, 1, "available");
                Item foodItem3 = new Item(3, "Classic Angus Cheese", "Our delicious classic begins with a juicy 100% Angus beef patty between creamy Colby cheese slices.", 10.90, 1, "available");
                Item foodItem4 = new Item(4, "French Fries", "For winning flavour and texture, we only use premium Russet Burbank variety potatoes for that fluffy inside, crispy outside taste of our world-famous fries.", 5.90, 1, "available");
                Item foodItem5 = new Item(5, "Apple Slices", "Go fruity with fresh, ready-to-eat apple slices!", 3.20, 1, "available");
                Item foodItem6 = new Item(6, "Coca-Cola", "Icy cold cola.", 3.5, 1, "available");
                Item foodItem7 = new Item(7, "100% Pure Orange Juice", "Pure orange juice, with Vitamin C.", 3.0, 1, "available");
                Item foodItem8 = new Item(8, "Test food", "Food Description", 10.0, 10, "available");
                Item[] alacarte = { foodItem1, foodItem2, foodItem3, foodItem4, foodItem5, foodItem6, foodItem7, foodItem8 };
                int FICount = 0; //keep id in ascending order
                foreach (Item a in alacarte)
                {
                    a.itemId = FICount + 1;
                    allFoodItems.Add(a);
                    FICount++;

                }
                // SetMenu
                SetMenu setMenu1 = new SetMenu(1, "Buttermilk Crispy Chicken Set", "Buttermilk Crispy Chicken with French Fries and Coca-Cola", 12.80, 1, "available");
                Item[] setItem1 = { foodItem1, foodItem4, foodItem6 };
                int SMIcount = 0;
                foreach (Item i in setItem1)
                {

                    SetMenuItem smi = new SetMenuItem(SMIcount + 1, i.name, setMenu1, i);
                    setMenu1.setMenuItemList.Add(smi);
                    SMIcount++;
                }

                SetMenu setMenu2 = new SetMenu(2, "Original Angus Cheeseburger Set", "Original Angus Cheeseburger with Apple Slices and 100% Pure Orange Juice", 13.90, 1, "available");
                Item[] setItem2 = { foodItem2, foodItem5, foodItem7 };
                SMIcount = 0;
                foreach (Item i in setItem2)
                {
                    SetMenuItem smi = new SetMenuItem(SMIcount + 1, i.name, setMenu2, i);
                    setMenu2.setMenuItemList.Add(smi);
                    SMIcount++;
                }
                SetMenu[] menuList = { setMenu1, setMenu2 };
                FICount = 0;
                foreach (SetMenu menu in menuList)
                {
                    menu.setMenuId = FICount + 1;
                    allSetMenus.Add(menu);
                    FICount++;
                }

                // Order               
                Order order1 = new Order(1, DateTime.Now);
                Payment payment1 = new Payment(1, DateTime.Now, "Online", order1);
                order1.payment = payment1;
                order1.orderItemList.Add(new OrderItem(1, 1, setMenu1));
                order1.orderItemList.Add(new OrderItem(1, 2, foodItem1));
                allOrders.Add(order1);
                //customer1.orderList.Add(order1);

                Order order2 = new Order(2, DateTime.Now);
                Payment payment2 = new Payment(2, DateTime.Now, "Online", order2);
                order2.payment = payment2;
                order2.orderItemList.Add(new OrderItem(1, 1, setMenu2));
                order2.orderItemList.Add(new OrderItem(1, 2, foodItem2));
                allOrders.Add(order2);
                //customer1.orderList.Add(order2);

                Order order3 = new Order(3, DateTime.Now);
                Payment payment3 = new Payment(3, DateTime.Now, "Online", order3);
                order3.payment = payment3;
                order3.orderItemList.Add(new OrderItem(1, 1, setMenu1));
                order3.orderItemList.Add(new OrderItem(1, 2, foodItem3));
                allOrders.Add(order3);
                customer1.orderList.Add(order3);

                Order order4 = new Order(4, DateTime.Now);
                Payment payment4 = new Payment(4, DateTime.Now, "Online", order4);
                order4.payment = payment4;
                order4.orderItemList.Add(new OrderItem(1, 1, setMenu1));
                order4.orderItemList.Add(new OrderItem(1, 2, foodItem4));
                order4.state = order4.preparingOrderState;
                allOrders.Add(order4);
                //customer1.orderList.Add(order4);
            }
        }
    }
}
