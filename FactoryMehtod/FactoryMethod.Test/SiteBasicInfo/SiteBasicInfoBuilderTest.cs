using FactoryMehtodLib.Repository;
using FactoryMehtodLib.SiteBasicInfo;
using FactoryMehtodLib.SiteBasicInfo.Wrap;
using FactoryMethodLib.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace FactoryMehtodLibLib.Test
{
    [TestClass]
    public class SiteBasicInfoBuilderTest : MockThis<SiteBasicInfoBuilder>
    {
        Mock<SiteBasicInfoBuilder> thisMock = new Mock<SiteBasicInfoBuilder> { CallBase = true };
        Mock<IActivatorWrap> mockActivatorWrap = new Mock<IActivatorWrap>();
        Mock<ITypeWrap> mockTypeWrap = new Mock<ITypeWrap>();

        [TestInitialize]
        public void Initialize()
        {
            thisMock.Object.ActivatorWrap = mockActivatorWrap.Object;
            thisMock.Object.TypeWrap = mockTypeWrap.Object;
        }
        [TestMethod]
        public void Builder()
        {
            //Arrange
            thisMock.Setup(s => s.DoMaker());
            //Act
            thisMock.Object.DoBuild();
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
        public void GetMaker()
        {
            //Arrange
            thisMock.Setup(s => s.GetInstance(It.IsAny<SiteBasicInfoMakerType>()));
            //Act
            thisMock.Object.GetMaker(It.IsAny<SiteBasicInfoMakerType>());
            //Assert
            thisMock.Verify(v=>v.GetInstance(It.IsAny<SiteBasicInfoMakerType>()), Times.Once);
        }
        [TestMethod]
        public void GetInstance()
        {
            //Arrange
            thisMock.Setup(s => s.GetTypeOfNameSpace(It.IsAny<SiteBasicInfoMakerType>()));
            thisMock.Setup(s => s.CreateIntance(It.IsAny<Type>()));
            //Act
            thisMock.Object.GetInstance(It.IsAny<SiteBasicInfoMakerType>());
            //Assert
            thisMock.Verify(v=>v.GetTypeOfNameSpace(It.IsAny<SiteBasicInfoMakerType>()), Times.Once);
            thisMock.Verify(v => v.CreateIntance(It.IsAny<Type>()), Times.Once);
        }
        [TestMethod]
        public void GetTypeOfNameSpace_NotThrowException()
        {
            //Arrange
            var mockType = new Mock<Type>();
            mockTypeWrap.Setup(s => s.GetType(It.IsAny<string>())).Returns(mockType.Object);
            //Act
            AssertEx.NoExceptionThrown<Exception>(()=> thisMock.Object.GetTypeOfNameSpace(It.IsAny<SiteBasicInfoMakerType>()));
            //Assert
            mockTypeWrap.Verify(v=>v.GetType(It.IsAny<string>()), Times.Once);
        }
        [TestMethod]
        public void GetTypeOfNameSpace_ThrowException()
        {
            //Arrange
            mockTypeWrap.Setup(s => s.GetType(It.IsAny<string>())).Returns<Type>(null);
            //Act Assert
            Assert.ThrowsException<Exception>(() => thisMock.Object.GetTypeOfNameSpace(It.IsAny<SiteBasicInfoMakerType>()));
            mockTypeWrap.Verify(v => v.GetType(It.IsAny<string>()), Times.Once);
        }
        [TestMethod]
        [DataRow(typeof(BoardAdminMaker), SiteBasicInfoMakerType.BoardAdmin)]
        public void GetTypeOfNameSpace(Type expectedType, SiteBasicInfoMakerType type)
        {
            thisMock.Object.TypeWrap = new TypeWrap();
            var actualType = thisMock.Object.GetTypeOfNameSpace(type);
            Assert.AreEqual(expectedType, actualType);
        }
        [TestMethod]
        public void CreateIntance()
        {
            //Arrange
            //Act
            thisMock.Object.CreateIntance(It.IsAny<Type>());
            //Assert
            mockActivatorWrap.Verify(v => v.CreateInstance(It.IsAny<Type>()));
        }
    }
}
