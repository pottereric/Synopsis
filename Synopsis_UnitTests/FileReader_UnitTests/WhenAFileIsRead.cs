using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synopsis;

namespace Synopsis_UnitTests.FileReader_UnitTests
{
    [TestClass]
    public class WhenAFileIsRead
    {
        string fileContents;

        [TestInitialize]
        public void Init()
        {
            fileContents = FileReader.Read(@"TestData\JsonDocStore.cs.test");
        }

        [TestMethod]
        public void ThenTheContentsAreNotNullOrEmpty()
        {
            Assert.IsFalse(String.IsNullOrWhiteSpace(fileContents));
        }
    }
}
