using Moq;
using Moq.Protected;
using NUnit.Framework;
using SuperMarket.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMarket_Test
{
    [TestFixture]
    public class ClientPaymentTest
    {
        private Mock<HttpMessageHandler> mockHandler = null;
        private string requestUri = null;
        private HttpResponseMessage response = null;

        [SetUp]
        public void Setup()
        {
             mockHandler = new Mock<HttpMessageHandler>();
             requestUri = "http://www.google.com/search?q=7.0";
             response = new HttpResponseMessage
             {
                StatusCode = HttpStatusCode.OK
             };
        }

        [TearDown]
        public void TearDown()
        {
           mockHandler = null;
           requestUri = null;
           response = null;
        }

        [Test]
        public void WhenCalledPaymentGateway_ReturnsPaymentIsSuccessful()
        {
           
            mockHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                            ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHandler.Object);
            var paymentGateway = new PaymentGatewayClient(httpClient);
            var retrievedPosts = paymentGateway.GetAsync(requestUri);

            Assert.NotNull(retrievedPosts);

            mockHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>( req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());

        }

       
    }
}
