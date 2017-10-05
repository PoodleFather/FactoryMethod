using FactoryMehtodLib.Repository;
using FactoryMehtodLib.SiteBasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    }
}
