using FactoryMehtodLib.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactoryMehtodLibLib.Test
{
    [TestClass]
    public class SiteBasicInfoBuilderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var unit = new UnitOfWorks();
            var a = unit.BoardAdminRepo.GetById(1);
        }
    }
}
