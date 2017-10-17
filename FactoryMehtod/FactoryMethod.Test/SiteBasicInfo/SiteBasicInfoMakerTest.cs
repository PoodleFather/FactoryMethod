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

        [Test]
        public void SiteBasicInfoMaker_constructor()
        {
            //Arrange
            var mockCreatedJoiner = new Mock<Joiner>();
            mockThis = new Mock<SiteBasicInfoMaker>(mockCreatedJoiner.Object);
            //Act

            //Assert
            Assert.AreEqual(mockCreatedJoiner.Object, mockThis.Object.CreatedJoiner);
        }
    }
}

