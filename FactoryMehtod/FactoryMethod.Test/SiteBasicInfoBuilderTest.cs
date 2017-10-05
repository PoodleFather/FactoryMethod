using FactoryMehtodLib.Repository;
using FactoryMehtodLib.SiteBasicInfo;
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
        [DataRow(typeof(BoardAdminMaker), SiteBasicInfoMakerType.BoardAdmin)]
        public void GetMaker(Type expectedType, SiteBasicInfoMakerType type)
        {
            //Act
            var actualType =  thisMock.Object.GetMaker(It.IsAny<SiteBasicInfoMakerType>());
            //Assert
            Assert.AreEqual(expectedType, actualType.GetType());
        }
    }
}
