using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    public class TaxCalculator
    {
        //public static double GetImportTax(double price, bool importItem)
        public static List<Item> GetImportTax(List<Item> shoppingCart)
        {
            foreach (Item item in shoppingCart)
            {
                if (item.importItem)
                {
                    item.importTax =  Math.Ceiling((item.price * .05) / .05) * .05;
                }
                else
                {
                    item.importTax = 0;
                }
            }

            return shoppingCart;

        }

        public static List<Item> GetSalesTax(List<Item> shoppingCart)
        {
            foreach (Item item in shoppingCart)
            {
                if (item.salesTaxExemptItem)
                {
                    item.salesTax = 0;
                }
                else
                {
                    item.salesTax = Math.Ceiling((item.price * .10) / .05) * .05;
                }
            }

            return shoppingCart;

        }
    }
}

