using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    public class Receipt
    {

        public static List<string> GetReceipt(List<Item> shoppingCart)
        {
            double shoppingCartTotal = 0;
            double shoppingCartTax = 0;

            List<string> receipt = new List<string>();

            foreach (Item item in shoppingCart)
            {
                //item.importTax = GetImportTax(item.price, item.importItem);
                //item.salesTax = GetSalesTax(item.price, item.salesTaxExemptItem);
                item.total = (item.price + item.importTax + item.salesTax) * item.count;

                shoppingCartTotal += item.total;
                shoppingCartTax += (item.salesTax + item.importTax) * item.count;
            }

            foreach (Item item in shoppingCart)
            {
                receipt.Add(item.ToString());
            }

            receipt.Add($"Sales Taxes: {shoppingCartTax:0.00}");
            receipt.Add($"Total: {Math.Round(shoppingCartTotal, 2):0.00}");

            return receipt;
        }

        public static void PrintReceipt(List<String> receipt)
        {
            Console.WriteLine("\n\nRECEIPT");

            foreach (string receiptLine in receipt)
            {
                Console.WriteLine(receiptLine);
            }

            Console.WriteLine();
        }
    }
}
