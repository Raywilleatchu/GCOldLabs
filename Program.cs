using System;
using System.Collections.Generic;

namespace Assessment2
{
    class Program
    {
        static void UserAddItem(List<string> list)
        {

            Console.WriteLine("How many items would you like to add?");
            int amountOfItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= amountOfItems; i++)
            {
                Console.WriteLine("Please Provide Item Name: ");
                string userItem = Console.ReadLine();
                string sub1 = userItem.Substring(0, 1).ToUpper();
                string sub2 = userItem.Substring(1);
                string finalInput = sub1 + sub2;


                if (list.Contains(finalInput))
                {
                    Console.WriteLine("Item already exists. Please use a different item name.");
                    string recentInput = finalInput;
                    if (i == 1)
                    {
                        i = 0;
                    }
                    else
                    {
                        if (finalInput == recentInput)
                        {
                            i--;
                        }
                        /*
                            *FIXED*
                            bug: If you enter an item that already exists twice in a row, 
                            you will end up increasing the amount of items to add.
                            *FIXED*
                        */
                    }
                }
                else
                {
                    list.Add(finalInput);
                }
            }

        }

        static void UserRemoveItem(List<string> list)
        {
            Console.WriteLine("What item would you like to remove?");
            string userInput = Console.ReadLine();
            string sub1 = userInput.Substring(0, 1).ToUpper();
            string sub2 = userInput.Substring(1);
            string finalInput = sub1 + sub2;
            Console.WriteLine($"Removing {finalInput}");
            list.Remove(finalInput);
            Console.WriteLine($"Successfully Removed {finalInput}!");
        }

        static void UserViewInventory(List<string> list)
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }


        static bool mainMenu()
        {
            bool valid = false;
            bool loop = false;
            do
            {
                Console.WriteLine("Would you like to return to the main menu(1) or exit the program(2)?");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    valid = false;
                    loop = true;
                }
                else if (input == "2")
                {
                    valid = true;
                    loop = true;
                }
                else
                {
                    Console.WriteLine("Incorrect Option");
                }
            } while (loop == false); ;

            return valid;
        }

        static void Main(string[] args)
        {
            List<string> items = new List<string>() { "Broccoli", "Tomatoes", "Zucchini" };
            Console.WriteLine("Welcome to my shop!");
            do
            {
                Console.WriteLine("Please Enter one of the Following: ");
                Console.WriteLine("(1) Add\n(2) Remove\n(3) View Inventory");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    UserAddItem(items);
                }
                else if (input == "2")
                {
                    UserRemoveItem(items);
                }
                else if (input == "3")
                {
                    UserViewInventory(items);
                }
                else
                {
                    Console.WriteLine("Error: Incorrect Option");
                }
            } while (mainMenu() == false);


        }
    }
}

