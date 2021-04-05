
using Moq;
using NUnit.Framework;
using SuperMarket.Client;
using SuperMarket.Logging;
using SuperMarket.Models;
using SuperMarket.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_Test
{

    [TestFixture]
    public class ShoppingServiceTest
    {

        ShoppingService _shoppingService;
        private Mock<ILogger> _logger;
        private Mock<IDiscountService> _discountService;
        private Mock<IPaymentGatewayClient> _paymentGateWay;
        private Mock<IStockService> _stockRepository;

        private List<ProductsDataModel> products = null;
        private List<string> items = null;
        private int customerId = 1053;
      
        [SetUp]
        public void SetUp()
        {
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

            _discountService = new Mock<IDiscountService>();
            _paymentGateWay = new Mock<IPaymentGatewayClient>();
            _stockRepository = new Mock<IStockService>();
            _logger = new Mock<ILogger>();
            _shoppingService = new ShoppingService(customerId, _stockRepository.Object, _discountService.Object, _paymentGateWay.Object, _logger.Object);
            _stockRepository.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products);
        }


        [TearDown]
        public void TearDown()
        {
            _discountService = null;
            _paymentGateWay = null;
            _stockRepository = null;
            _logger = null;
            _shoppingService = null;
        }


        [Test]
        public void WhenCalledBuyItem_PaymentSuccessfulForAvailableItemsInStock_ReturnsItemCount()
        {
   
            _discountService.Setup(x => x.ApplyDiscount(It.IsAny<Int16>(), It.IsAny<double>())).Returns(It.IsAny<double>());
            _paymentGateWay.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            _logger.Setup(x => x.write(It.IsAny<string>()));
            var result = _shoppingService.BuyItems(items);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void WhenCalledBuyItem_PaymentFailedDueToBadRequest_ThrowsException()
        {
            _discountService.Setup(x => x.ApplyDiscount(It.IsAny<Int16>(), It.IsAny<double>())).Returns(It.IsAny<double>());
            _paymentGateWay.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)));
            _logger.Setup(x => x.write(It.IsAny<string>()));
            Assert.Throws<ArgumentException>(() => _shoppingService.BuyItems(items));
        }

        [Test]
        public void WhenCalledBuyItem_ErrorInPaymentProcessing()
        {
            _discountService.Setup(x => x.ApplyDiscount(It.IsAny<Int16>(), It.IsAny<double>())).Returns(70);
            _paymentGateWay.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)));
            _logger.Setup(x => x.write(It.IsAny<string>()));
            var result = _shoppingService.BuyItems(items);
            var output = new StringWriter();
            Console.SetOut(output);
            var logger = new Logger();
            var errorMsg = "Error in processing payment " + customerId;
            logger.write(errorMsg);
            Assert.That(output.ToString(), Is.EqualTo(errorMsg + string.Format(Environment.NewLine)));
            Assert.AreEqual(2, result);
        }

    }
}