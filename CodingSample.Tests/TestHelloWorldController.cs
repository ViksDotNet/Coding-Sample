using CodingSample.API.Controllers;
using CodingSample.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace CodingSample.Tests
{
    [TestClass]
    public class TestHelloWorldController
    {

        [TestMethod]
        public void Get_ShouldReturnHelloWorld()
        {
            //arrange
            var testResults = GetTestResults();
            var controller = new HelloWorldController();

            //act
            IHttpActionResult actionResult = controller.Get();
            var result = ((OkNegotiatedContentResult<OutputModel>)actionResult);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testResults[1].OutputData, result.Content.OutputData);
        }

        private List<OutputModel> GetTestResults()
        {
            var testResults = new List<OutputModel>();
            testResults.Add(new OutputModel { OutputData = "Test" });
            testResults.Add(new OutputModel { OutputData = "Hello World" });
            testResults.Add(new OutputModel { OutputData = "Good Bye" });
           

            return testResults;
        }

    }
}
