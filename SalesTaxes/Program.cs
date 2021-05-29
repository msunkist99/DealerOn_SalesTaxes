using System;
using System.Collections.Generic;

namespace SalesTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> shoppingCart = new List<Item>();

            string inputValue = null;

            Console.WriteLine("Enter item information");

            while (inputValue != "COMPLETE")
            {
                Item item = new Item();

                item = UserInput.GetItemDescription(item);
                item = UserInput.GetItemPrice(item);
                item = UserInput.GetItemCount(item);
                item = UserInput.GetItemImportStatus(item);
                item = UserInput.GetItemSalesTaxExemptStatus(item);

                shoppingCart.Add(item);

                Console.WriteLine("Press enter to input next item information or enter COMPLETE");
                inputValue = Console.ReadLine().ToUpper();
            }

            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);
            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);


            List<String> receipt = Receipt.GetReceipt(shoppingCart);
            Receipt.PrintReceipt(receipt);

            /*
            shoppingCart.Add(new Item("Book", 12.49, true, false, 2));
            shoppingCart.Add(new Item("Music CD", 14.99, false, false, 1));
            shoppingCart.Add(new Item("Chocolate Bar", .85, true, false, 1));


            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);
            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);
           

            List<String> receipt = Receipt.GetReceipt(shoppingCart);
            Receipt.PrintReceipt(receipt);

            /*
            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("Imported box of chocolates", 10.00, true, true, 1));
            shoppingCart.Add(new Item("Imported bottle of perfume", 47.50, false, true, 1));

            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);
            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);

            receipt = Receipt.GetReceipt(shoppingCart);
            Receipt.PrintReceipt(receipt);


            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("Imported bottle of perfume", 27.99, false, true, 1));
            shoppingCart.Add(new Item("Bottle of perfume", 18.99, false, false, 1));
            shoppingCart.Add(new Item("Packet of headache pills", 9.75, true, false, 1));
            shoppingCart.Add(new Item("Imported box of chocolates", 11.25, true, true, 2));

            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);
            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);
            
            receipt = Receipt.GetReceipt(shoppingCart);
            Receipt.PrintReceipt(receipt);
            */

            Console.ReadLine();
        }
    }
}
