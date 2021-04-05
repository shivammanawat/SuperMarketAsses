using Moq;
using NUnit.Framework;
using SuperMarket.Models;
using SuperMarket.Repository;
using SuperMarket.Service;
using System;
using System.Collections.Generic;

namespace SuperMarket_Test
{
    [TestFixture]
    public class StockServiceTest
    {
        private Mock<IStockRepository> _stockMockRepo = null;
        private StockService _stockService = null;

        private List<ProductsDataModel> products = null;
        private List<string> items = null;

        [SetUp]
        public void Setup()
        { 
            _stockMockRepo = new Mock<IStockRepository>();
            _stockService = new StockService(_stockMockRepo.Object);

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
            _stockMockRepo = null;
            _stockService = null;
        }

        [Test]
        public void CheckAvailablilityOfStocks()
        {
            _stockMockRepo.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products); 
            var result = _stockService.CheckStockStatus(items);
            Assert.AreEqual(result,  products);
        }



    }

}

