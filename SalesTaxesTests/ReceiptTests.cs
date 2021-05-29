using NUnit.Framework;
using SalesTaxes;
using System.Collections.Generic;

namespace SalesTaxesTests
{
    public class ReceiptTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestReceipt_OneItemCount()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("domestic item", 10, false, false, 1));

            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);
            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);

            List<string> receipt = Receipt.GetReceipt(shoppingCart);

            Assert.AreEqual("domestic item: 11.00", receipt[0]);
            Assert.AreEqual("Sales Taxes: 1.00", receipt[1]);
            Assert.AreEqual("Total: 11.00", receipt[2]);
        }

        [Test]
        public void TestReceipt_TwoItemCount()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("domestic item", 10, false, false, 2));

            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);
            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);

            List<string> receipt = Receipt.GetReceipt(shoppingCart);

            Assert.AreEqual("domestic item: 22.00 (2 @ 11.00)", receipt[0]);
            Assert.AreEqual("Sales Taxes: 2.00", receipt[1]);
            Assert.AreEqual("Total: 22.00", receipt[2]);
        }


        [Test]
        public void TestReceipt_MultipleItems()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();

            shoppingCart.Add(new Item("Imported bottle of perfume", 27.99, false, true, 1));
            shoppingCart.Add(new Item("Bottle of perfume", 18.99, false, false, 1));
            shoppingCart.Add(new Item("Packet of headache pills", 9.75, true, false, 1));
            shoppingCart.Add(new Item("Imported box of chocolates", 11.25, true, true, 2));

            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);
            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);

            List<string> receipt = Receipt.GetReceipt(shoppingCart);

            Assert.AreEqual("Imported bottle of perfume: 32.19", receipt[0]);
            Assert.AreEqual("Bottle of perfume: 20.89", receipt[1]);
            Assert.AreEqual("Packet of headache pills: 9.75", receipt[2]);
            Assert.AreEqual("Imported box of chocolates: 23.70 (2 @ 11.85)", receipt[3]);
            Assert.AreEqual("Sales Taxes: 7.30", receipt[4]);
            Assert.AreEqual("Total: 86.53", receipt[5]);

        }
    }
}
