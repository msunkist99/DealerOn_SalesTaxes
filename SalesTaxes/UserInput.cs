using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    public class UserInput
    {
        public static Item GetItemDescription(Item item)
        {
            string inputValue = GetUserInput("\n\nEnter item description - ");

            if (inputValue == "")
            {
                Console.Write("Invalid item description --- defaulting to XXX");
                item.description = "XXX";
            }
            else
            {
                item.description = inputValue;
            }

            return item;
        }

        public static Item GetItemPrice(Item item)
        {
            string inputValue = GetUserInput("\n\nEnter item price -  ");

            try
            {
                item.price = double.Parse(inputValue);
            }
            catch
            {
                Console.Write("Invalid item price --- default to 1.00");
                item.price = 1;
            }

            return item;
        }

        public static Item GetItemCount(Item item)
        {
            string inputValue = GetUserInput("\n\nEnter item count - ");

            try
            {
                item.count = int.Parse(inputValue);
            }
            catch
            {
                Console.Write("Invalid item count --- default to 1");
                item.count = 1;
            }

            return item;
        }

        public static Item GetItemImportStatus(Item item)
        {
            string inputValue = GetUserInput("\n\nEnter item import status true/false - ");

            if (inputValue == "TRUE")
            {
                item.importItem = true;
            }
            else if (inputValue == "FALSE")
            {
                item.importItem = false;
            }
            else
            {
                Console.Write("Invalid item inport status --- default to true");
                item.importItem = true;
            }

            return item;
        }

        public static Item GetItemSalesTaxExemptStatus(Item item)
        {
            string inputValue = GetUserInput("\n\nEnter item sales tax exempt status true/false - ");

            if (inputValue == "TRUE")
            {
                item.salesTaxExemptItem = true;
            }
            else if (inputValue == "FALSE")
            {
                item.salesTaxExemptItem = false;
            }
            else
            {
                Console.Write("Invalid item sales inport status --- default to false");
                item.salesTaxExemptItem = false;
            }
            
            return item;
        }

        private static string GetUserInput(string text)
        {
            string inputValue;

            Console.WriteLine(text);
            return Console.ReadLine().ToUpper();
        }
    }
}
