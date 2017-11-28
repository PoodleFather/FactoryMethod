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
    public class BoardAdminMakerTest : MockThis<BoardAdminMaker>
    {
        Mock<Joiner> mockJoiner;

        [SetUp]
        public void Setup()
        {
            SetMock<Joiner>();
            mockSetup(GetMock<Joiner>());
        }
        [Test]
        public void Do()
        {
            //Arrange
            //Act
            //mockThis.Object.Do();
            //Assert
        }
    }
}
