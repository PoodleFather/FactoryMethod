using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FactoryMehtodLib.SiteBasicInfo;
using Moq;
using FactoryMehtodLib.Model;
using FactoryMehtodLib.SiteBasicInfo.Wrap;
using System.Reflection;

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
        public void Dispose()
        {
            //Arrange
            mockThis.Object.TemplateJoiner = new Joiner();
            //Act
            mockThis.Object.Dispose();
            //Assert
            mockThis.Verify(v => v.Dispose(mockThis.Object.disposed), Times.Once);
            mockThis.Verify(v => v.SuppressFinalize(mockThis.Object), Times.Once);
            Assert.AreEqual(null, mockThis.Object.CreatedJoiner);
            Assert.AreEqual(null, mockThis.Object.TemplateJoiner);
        }
        [Test]
        public void Dispose_false_disposed_True()
        {
            //Arrnage
            mockThis.Object.disposed = false;
            var props = typeof(SiteBasicInfoMaker).GetProperties(BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);
            mockThis.Setup(s => s.GetAllProperties()).Returns(props);
            //Act
            mockThis.Object.Dispose(true);
            //Assert
            mockThis.Verify(v => v.GetAllProperties(), Times.Once);
            Assert.IsTrue(mockThis.Object.disposed);
            foreach (var prop in mockThis.Object.GetType().GetProperties())
            {
                if (prop.CanWrite) Assert.IsNull(prop);
            }
        }
        [Test]
        public void Dispose_True_disposed_True()
        {
            //Arrnage
            mockThis.Object.disposed = true;
            var props = typeof(SiteBasicInfoMaker).GetProperties(BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);
            mockThis.Setup(s => s.GetAllProperties()).Returns(props);
            //Act
            mockThis.Object.Dispose(true);
            //Assert
            mockThis.Verify(v => v.GetAllProperties(), Times.Never);
            Assert.IsTrue(mockThis.Object.disposed);
        }
        [Test]
        public void Dispose_false_disposed_false()
        {
            //Arrnage
            mockThis.Object.disposed = false;
            var props = typeof(SiteBasicInfoMaker).GetProperties(BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);
            mockThis.Setup(s => s.GetAllProperties()).Returns(props);
            //Act
            mockThis.Object.Dispose(false);
            //Assert
            mockThis.Verify(v => v.GetAllProperties(), Times.Never);
            Assert.IsTrue(mockThis.Object.disposed);
        }
    }
}

