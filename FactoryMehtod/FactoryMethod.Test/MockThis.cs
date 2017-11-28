using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodLib.Test
{
    public class MockThis<T> where T : class
    {
        protected Mock<T> mockThis { get; set; }
        protected Dictionary<object, object> mockProperties = new Dictionary<object, object>();

        protected void mockSetup()
        {
            mockThis = new Mock<T> { CallBase = true };
        }
        protected void mockSetup(object obj)
        {
            mockThis = new Mock<T>(obj) { CallBase = true };
        }
        protected void SetMock<K>() where K : class
        {
            mockProperties.Add(typeof(K), new Mock<K>());
        }
        protected Mock<K> GetMock<K>() where K : class
        {
            object propMock;
            if (AnyDic<K>(out propMock)) return (Mock<K>)propMock;
            SetMock<K>();
            return GetMock<K>();
        }

        private bool AnyDic<K>(out object propMock) where K : class
        {
            return mockProperties.TryGetValue(typeof(K), out propMock);
        }
    }
}
