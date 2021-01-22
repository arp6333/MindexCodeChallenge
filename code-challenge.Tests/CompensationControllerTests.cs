using challenge.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using code_challenge.Tests.Integration.Extensions;
using System.Net;
using System.Net.Http;
using code_challenge.Tests.Integration.Helpers;
using System.Text;
using System;

namespace code_challenge.Tests.Integration
{
    /// <summary>
    /// Test class for the Compensation controller.
    /// </summary>
    [TestClass]
    public class CompensationControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        /// <summary>
        /// Initialize the test class with a test server and client.
        /// </summary>
        /// <param name="context">Testing context.</param>
        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestServerStartup>()
                .UseEnvironment("Development"));

            _httpClient = _testServer.CreateClient();
        }

        /// <summary>
        /// Cleanup by disposing of the client and server.
        /// </summary>
        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }

        /// <summary>
        /// Test CreateCompensation with a valid employee id returns Created and valid info.
        /// </summary>
        [TestMethod]
        public void CreateCompensation_Valid_Returns_Created()
        {
            // Arrange
            Compensation compensation = new Compensation()
            {
                EmployeeId = "New_Employee_Test",
                EffectiveDate = Convert.ToDateTime("01/22/2021"),
                Salary = 99999.99
            };

            var requestContent = new JsonSerialization().ToJson(compensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            Compensation newCompensation = response.DeserializeContent<Compensation>();
            Assert.IsNotNull(newCompensation.EmployeeId);
            Assert.AreEqual(compensation.EffectiveDate, newCompensation.EffectiveDate);
            Assert.AreEqual(compensation.Salary, newCompensation.Salary);
        }

        /// <summary>
        /// Test CreateCompensation with an invalid employee id (already exists) fails.
        /// </summary>
        [TestMethod]
        public void CreateCompensation_Returns_Created()
        {
            // Arrange
            Compensation compensation = new Compensation()
            {
                EmployeeId = "03aa1462-ffa9-4978-901b-7c001562cf6f",
                EffectiveDate = Convert.ToDateTime("01/22/2021"),
                Salary = 99999.99
            };

            var requestContent = new JsonSerialization().ToJson(compensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        /// Test GetCompensationById with a valid employee id returns Ok and valid info.
        /// </summary>
        [TestMethod]
        public void GetCompensationById_Valid_Returns_Ok()
        {
            // Arrange
            string employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            DateTime expectedEffectiveDate = Convert.ToDateTime("01/22/2021");
            double expectedSalary = 99999.99;

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Compensation compensation = response.DeserializeContent<Compensation>();
            Assert.AreEqual(expectedEffectiveDate, compensation.EffectiveDate);
            Assert.AreEqual(expectedSalary, compensation.Salary);
        }

        /// <summary>
        /// Test GetCompensationById with an invalid employee id returns not found.
        /// </summary>
        [TestMethod]
        public void GetCompensationById_Invalid_Returns_NotFound()
        {
            // Arrange
            string employeeId = "Invalid_Id";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
