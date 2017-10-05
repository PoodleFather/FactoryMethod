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
        Mock<SiteBasicInfoBuilder> mock = new Mock<SiteBasicInfoBuilder>();

        [TestMethod]
        public void Builder()
        {
            //Arrange
            mock.Setup(s => s.DoMaker());
            //Act
            mock.Object.Builder();
            //Assert
            mock.Verify(v => v.DoMaker());
        }
        [TestMethod]
        public void DoMaker()
        {
            //Arrange
            Mock<ISiteBasicInfoMaker> mock_IMaker = new Mock<ISiteBasicInfoMaker>();
            //Act
            mock.Object.DoMaker();
            //Assert
            foreach (SiteBasicInfoMakerType type in Enum.GetValues(typeof(SiteBasicInfoMakerType)))
            {
                mock.Verify(v => v.GetMaker(type), Times.Once);
            }
            mock_IMaker.Verify(v => v.Do(), Times.Exactly(Enum.GetNames(typeof(SiteBasicInfoMakerType)).Length));

        }
    }
}
