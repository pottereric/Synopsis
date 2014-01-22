using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synopsis;
using System.Linq;

namespace Synopsis_UnitTests.MembersByAccessModifier_UnitTests
{
    [TestClass]
    public class WhenASimpleFileIsAnalized
    {
        private MembersByAccessModifier analyzer;

        [TestInitialize]
        public void Init()
        {
            analyzer = new MembersByAccessModifier(FileReader.Read(@"TestData\JsonDocStore.cs.test"));
        }
        
        [TestMethod]
        public void ThenThereWillBeTheCorrectNumberOfPublicMethods()
        {
            Assert.AreEqual(2, analyzer.PublicMethods.Count());
        }

        [TestMethod]
        public void ThereWillBeTheCorrectNumberOfPrivateMethods()
        {
            Assert.AreEqual(1, analyzer.PrivateMethods.Count());
        }
    }
}
