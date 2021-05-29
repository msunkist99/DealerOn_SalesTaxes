using NUnit.Framework;
using SalesTaxes;
using System.Collections.Generic;

namespace SalesTaxesTests
{
    public class TaxCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSalesTax_NonExempt()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("domestic item", 10, false, false, 1));


            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);

            Assert.AreEqual(1, shoppingCart[0].salesTax);
        }

        [Test]
        public void TestSalesTax_Exempt()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("domestic item", 10, true, false, 2));


            shoppingCart = TaxCalculator.GetSalesTax(shoppingCart);

            Assert.AreEqual(0, shoppingCart[0].salesTax);
        }

        [Test]
        public void TestImportTax_NonImport()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("domestic item", 10, true, false, 2));

            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);

            Assert.AreEqual(0, shoppingCart[0].importTax);
        }


        [Test]
        public void TestImportTax_Import()
        {
            List<Item> shoppingCart = new List<Item>();

            shoppingCart = new List<Item>();
            shoppingCart.Add(new Item("domestic item", 10, true, true, 2));

            shoppingCart = TaxCalculator.GetImportTax(shoppingCart);

            Assert.AreEqual(.5, shoppingCart[0].importTax);
        }
    }
}