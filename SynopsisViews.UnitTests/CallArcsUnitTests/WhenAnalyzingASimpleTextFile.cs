using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synopsis;

namespace SynopsisViews.UnitTests.CallArcsUnitTests
{
    [TestClass]
    public class WhenAnalyzingASimpleTextFile
    {
        private CallArcs arcs;

        [TestInitialize]
        public void Initialize()
        {
            arcs = new CallArcs();
            arcs.CodeText = testCode1;
        }

        [TestMethod]
        public void ThenThereWillBeTheRightNumberOfLines()
        {
            Assert.AreEqual(41, arcs.LinesInFile);
        }

        private string testCode1
        {
            get
            {
                var text = FileReader.Read(@"H:\Projects\Synopsis\TestFiles\Simple.cs");
                return text;
            }
        }
    }
}