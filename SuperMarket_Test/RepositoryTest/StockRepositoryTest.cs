using NUnit.Framework;
using SuperMarket.Models;
using SuperMarket.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket_Test.RepositoryTest
{
    public class StockRepositoryTest
    {
        private List<ProductsDataModel> products = null;
        private List<string> items = null;
        private IStockRepository _stockRepo = null;

        [SetUp]
        public void Setup()
        {
           
            _stockRepo = new StockRepository();

            products = new List<ProductsDataModel>();
            items = new List<string>();

            products.Clear();
            products.Add(new ProductsDataModel()
            {
                Name = "Biscuits",
                Price = 100,
            });
            products.Add(new ProductsDataModel()
            {
                Name = "Milk",
                Price = 300,
            });
            items.Clear();
            items.Add("Bread");
            items.Add("Milk");
            items.Add("cheese");
            items.Add("Butter");
            items.Add("Biscuits");
        }

        [TearDown]
        public void TearDown()
        {
            _stockRepo = null;
        }

        [Test]
        public void CheckAvailablilityOfStocks()
        {
            var result = _stockRepo.CheckStockStatus(items);
            Assert.NotNull(items);
        }
    }
}
