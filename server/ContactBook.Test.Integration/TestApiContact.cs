using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AddressBook.Test.Integration
{
    public class TestApiContact
    {
        [TestCase("Get", "api/Contact")]
        [TestCase("Get", "api/Contact/1")]
        public async Task GetAllCContactTestAsync(string method, string URL)
        {
            using var client = new TestClientProvider().Client;
            var request = new HttpRequestMessage(new HttpMethod(method), URL);
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}