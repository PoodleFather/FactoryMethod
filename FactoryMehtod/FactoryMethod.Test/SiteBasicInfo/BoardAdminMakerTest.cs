using FactoryMehtodLib.Model;
using FactoryMehtodLib.SiteBasicInfo;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodLib.Test.SiteBasicInfo
{
    [TestFixture]
    public class BoardAdminMakerTest
    {
        Mock<BoardAdminMaker> mockThis;
        Mock<Joiner> mockJoiner;
        [SetUp]
        public void setup()
        {
            mockJoiner = new Mock<Joiner>();
            mockThis = new Mock<BoardAdminMaker>(mockJoiner.Object) { CallBase = true };
        }

        [Test]
        public void Dispose()
        {
            //Arrange
            mockThis.Object.TemplateJoiner = new Joiner();
            //Act
            mockThis.Object.Dispose();
            //Assert
            Assert.AreEqual(null, mockThis.Object.CreatedJoiner);
            Assert.AreEqual(null, mockThis.Object.TemplateJoiner);

        }
    }
}
