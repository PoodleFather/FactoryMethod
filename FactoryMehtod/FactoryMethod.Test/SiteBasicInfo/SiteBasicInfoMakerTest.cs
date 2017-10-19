using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FactoryMehtodLib.SiteBasicInfo;
using Moq;
using FactoryMehtodLib.Model;

namespace FactoryMethodLib.Test.SiteBasicInfo
{
    [TestFixture]
    public class SiteBasicInfoMakerTest
    {
        Mock<SiteBasicInfoMaker> mockThis;
        Mock<Joiner> mockCreatedJoiner;
        [SetUp]
        public void setup()
        {
            mockCreatedJoiner = new Mock<Joiner>();
            mockThis = new Mock<SiteBasicInfoMaker>(mockCreatedJoiner.Object) { CallBase = true };
        }
        [Test]
        public void SiteBasicInfoMaker_constructor()
        {
            //Arrange
            //Act

            //Assert
            Assert.AreEqual(mockCreatedJoiner.Object, mockThis.Object.CreatedJoiner);
        }
        [Test]
        public void SiteBasicInfoMaker_Dispose()
        {
            mockThis.Object.TemplateJoiner = new Joiner();
            mockThis.Object.Dispose();
            Assert.AreEqual(null, mockThis.Object.CreatedJoiner);
            Assert.AreEqual(null, mockThis.Object.TemplateJoiner);
        }
    }
}

