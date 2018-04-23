using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCoreWebApi.BusinessLayer.Repositories;
using SampleCoreWebApi.Controllers;
using SampleCoreWebApi.DataModel.Models;
using SampleCoreWebApi.DataModel.UOWGenericRepo;

namespace SampleCoreWepApi.MSTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestTokenKey()
        {
           Assert.AreEqual(true, true, "Both Values are mismatch");
        }
    }
}
