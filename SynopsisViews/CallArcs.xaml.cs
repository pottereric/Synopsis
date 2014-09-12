using Synopsis;
using SynopsisViews.Tools;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SynopsisViews
{
    /// <summary>
    /// Interaction logic for CallArcs.xaml
    /// </summary>
    public partial class CallArcs : UserControl
    {
        private string _codeText;

        public string CodeText
        {
            get
            {
                return _codeText;
            }
            set
            {
                _codeText = value;
                DrawArcs();
            }
        }

        public int LinesInFile
        {
            get
            {
                Regex myRegex = new Regex("\n", RegexOptions.Multiline);
                MatchCollection mCollection = myRegex.Matches(CodeText);
                return mCollection.Count;
            }
        }

        public int VerticalScaleFactor
        {
            get
            {
                var linesInFile = LinesInFile;
                var windowHeight = this.ActualHeight;
                if (windowHeight == double.NaN || windowHeight == 0.0)
                {
                    return 5;
                }
                else
                {
                    return (int)(windowHeight / linesInFile);
                }
            }
        }

        public CallArcs()
        {
            InitializeComponent();
        }

        private void DrawArcs()
        {
            
            var arcAdder = new ArcAdder(LayoutRoot);

            MethodCalls a = new MethodCalls(CodeText);
            var methodInfo = a.Analyze();

            foreach (var methodCall in methodInfo.Calls)
            {
                arcAdder.AddArc(methodCall.CallingLine * VerticalScaleFactor, methodCall.CalledLine * VerticalScaleFactor);
            }

            foreach (var definition in methodInfo.Definitions)
            {
                AddTextToScreen(definition.Name, definition.Line * VerticalScaleFactor);
            }

            arcAdder.AddCollectionToCanvas();
        }

        private void AddTextToScreen(string text, int pos)
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            //textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, 10);

            Canvas.SetTop(textBlock, pos);

            LayoutRoot.Children.Add(textBlock);
        }

        private void LayoutRoot_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            DrawArcs();
        }
    }
}