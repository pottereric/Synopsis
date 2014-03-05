using Synopsis;
using SynopsisViews.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SynopsisViews
{
    /// <summary>
    /// Interaction logic for CallArcs.xaml
    /// </summary>
    public partial class CallArcs : UserControl
    {
        public CallArcs()
        {
            InitializeComponent();


            var arcAdder = new ArcAdder(LayoutRoot);

            MethodCalls a = new MethodCalls(testCode);
            var methodInfo = a.Analyze();

            foreach (var methodCall in methodInfo.Calls)
            {
                arcAdder.AddArc(methodCall.CallingLine * 5, methodCall.CalledLine * 5);
            }

            foreach (var definition in methodInfo.Definitions)
            {
                AddTextToScreen(definition.Name, definition.Line);
            }

            arcAdder.AddCollectionToCanvas();
        }

        private void AddTextToScreen(string text, int pos)
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            //textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, 10);

            Canvas.SetTop(textBlock, pos * 5);

            LayoutRoot.Children.Add(textBlock);
        }

        private string testCode
        {
            get
            {
                return @"using System;

namespace RoslynExploration
{
    internal class TestClass
    {
        public void MethodOne()
        {
            Console.WriteLine(""One"");
            MethodOneA();
            MethodOneB();
        }

        public void MethodTwo()
        {
            Console.WriteLine(""Two"");
            MethodTwoA();
            MethodTwoB();
        }

        private void MethodOneA()
        {
            Console.WriteLine(""One A"");
        }

        private void MethodOneB()
        {
            Console.WriteLine(""One B"");
        }

        private void MethodTwoA()
        {
            Console.WriteLine(""Two A"");
        }

        private void MethodTwoB()
        {
            Console.WriteLine(""Two B"");
        }
    }
}"";";
            }
        }
    }
}
