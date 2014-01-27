using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synopsis;
using System.Linq;

namespace Synopsis_UnitTests.MembersByAccessModifier_UnitTests
{
    [TestClass]
    public class WhenASecondFileIsAnalized
    {
        private MembersByAccessModifier analyzer;

        [TestInitialize]
        public void Init()
        {
            analyzer = new MembersByAccessModifier(FileReader.Read(@"TestData\Bracket.cs.test"));
        }

        [TestMethod]
        public void ThenThereWillBeTheCorrectNumberOfPublicMethods()
        {
            Assert.AreEqual(5, analyzer.PublicMethods.Count());
        }

        [TestMethod]
        public void ThereWillBeTheCorrectNumberOfPrivateMethods()
        {
            Assert.AreEqual(0, analyzer.PrivateMethods.Count());
        }

        [TestMethod]
        public void ThenThereWillBeTHeCorrectNumberOfProtectedFields()
        {
            Assert.AreEqual(2, analyzer.ProtectedFields.Count());
        }

        [TestMethod]
        public void ThenThereWillBeTHeCorrectNumberOfPrivateFields()
        {
            Assert.AreEqual(2, analyzer.PrivateFields.Count());
        }

        [TestMethod]
        public void ThenThereWillBeTheCorrectNumberOfPublicProperties()
        {
            Assert.AreEqual(0, analyzer.PublicProperties.Count());
        }

        [TestMethod]
        public void ThenThereWillBeTheCorrectNumberOfPublicConstructors()
        {
            Assert.AreEqual(0, analyzer.PublicConstructors.Count());
        }
    }
}
