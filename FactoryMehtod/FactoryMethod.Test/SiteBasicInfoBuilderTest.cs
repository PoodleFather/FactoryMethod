using FactoryMehtodLib.Repository;
using FactoryMehtodLib.SiteBasicInfo;
using FactoryMethodLib.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace FactoryMehtodLibLib.Test
{
    [TestClass]
    public class SiteBasicInfoBuilderTest
    {
        Mock<SiteBasicInfoBuilder> thisMock = new Mock<SiteBasicInfoBuilder> { CallBase = true };

        [TestMethod]
        public void Builder()
        {
            //Arrange
            thisMock.Setup(s => s.DoMaker());
            //Act
            thisMock.Object.Builder();
            //Assert
            thisMock.Verify(v => v.DoMaker());
        }
        [TestMethod]
        public void DoMaker()
        {
            //Arrange
            Mock<ISiteBasicInfoMaker> mock_IMaker = new Mock<ISiteBasicInfoMaker>();
            thisMock.Setup(s => s.GetMaker(It.IsAny<SiteBasicInfoMakerType>())).Returns(mock_IMaker.Object);
            //Act
            thisMock.Object.DoMaker();
            //Assert
            int makerTypeCnt = Enum.GetNames(typeof(SiteBasicInfoMakerType)).Length;
            thisMock.Verify(v => v.GetMaker(It.IsAny<SiteBasicInfoMakerType>()), Times.Exactly(makerTypeCnt));
            mock_IMaker.Verify(v => v.Do(), Times.Exactly(makerTypeCnt));
        }
        [TestMethod]
        public void GetMaker_NotThrowException()
        {
            //Arrange
            var mockMaker = new Mock<ISiteBasicInfoMaker>();
            thisMock.Setup(s=>s.GetInstance(It.IsAny<SiteBasicInfoMakerType>())).Returns(mockMaker.Object);
            //Act
            AssertEx.NoExceptionThrown<Exception>(()=> thisMock.Object.GetMaker(It.IsAny<SiteBasicInfoMakerType>()));
            //Assert
            thisMock.Verify(v=>v.GetInstance(It.IsAny<SiteBasicInfoMakerType>()), Times.Once);
        }
        [TestMethod]
        public void GetMaker_ThrowException()
        {
            //Arrange
            thisMock.Setup(s => s.GetInstance(It.IsAny<SiteBasicInfoMakerType>())).Returns<SiteBasicInfoMakerType>(null);
            //Act Assert
            Assert.ThrowsException<Exception>(()=> thisMock.Object.GetMaker(It.IsAny<SiteBasicInfoMakerType>()));
            thisMock.Verify(v => v.GetInstance(It.IsAny<SiteBasicInfoMakerType>()), Times.Once);
        }
        [TestMethod]
        public void GetInstance()
        {
            //Arrange

            //Act
            thisMock.Object.GetInstance(It.IsAny<SiteBasicInfoMakerType>());
            //Assert
            thisMock.Verify(v => v.GetTypeOfNameSpace(It.IsAny<SiteBasicInfoMakerType>()), Times.Once);
        }
        [TestMethod]
        [DataRow(typeof(BoardAdminMaker), SiteBasicInfoMakerType.BoardAdmin)]
        [DataRow(typeof(BoardAdminMaker), SiteBasicInfoMakerType.Categroy)]
        public void GetInstance_Unit(Type expectedType, SiteBasicInfoMakerType type)
        {
            var actualIntance = thisMock.Object.GetInstance(type);
            Assert.AreEqual(expectedType, actualIntance.GetType());
        }

        [TestMethod]
        public void GetType()
        {

        }
    }
}
