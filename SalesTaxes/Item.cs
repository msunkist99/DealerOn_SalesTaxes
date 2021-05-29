using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    public class Item
    {
        public string description;
        public double price;
        public bool salesTaxExemptItem;
        public bool importItem;
        public int count;
        public double total;
        public double salesTax;
        public double importTax = 0;

        public Item() { }

        public Item(string description, double price, bool salesTaxExemptItem, bool importItem, int count)
        {
            this.description = description;
            this.price = price;
            this.salesTaxExemptItem = salesTaxExemptItem;
            this.importItem = importItem;
            this.count = count;
        }

        public override string ToString()
        {
            if (this.count == 1)
            {
                return $"{this.description}: {Math.Round(this.price + this.importTax + this.salesTax, 2):0.00}";
            }
            else
            {
                return $"{this.description}: {this.total:0.00} ({this.count} @ {Math.Round(this.price + this.importTax + this.salesTax, 2):0.00})";
            }
        }

    }
}
