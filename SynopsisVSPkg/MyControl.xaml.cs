using EnvDTE;
using Synopsis.SynopsisVSPkg.ViewModels;
using System.Windows.Controls;

namespace Synopsis.SynopsisVSPkg
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public MyControl(SynopsisVSPkgPackage package)
        {
            InitializeComponent();

            if (package != null)
            {
                var vm = new MemberByAccessModifierViewModel();
                this.DataContext = vm;
            }
            else
            {
                var vm = new MemberByAccessModifierViewModel();
                this.DataContext = vm;
            }
        }

        private SynopsisVSPkgPackage _package;

        public SynopsisVSPkgPackage Package
        {
            get { return _package; }
            set
            {
                _package = value;
                var document = _package.IDE.ActiveDocument;

                if (document != null)
                {
                    var textDocument = (TextDocument)document.Object("TextDocument");
                    var fullText = textDocument.StartPoint.CreateEditPoint().GetText(textDocument.EndPoint);

                    var vm = new MemberByAccessModifierViewModel();
                    vm.SetDocument(fullText);
                    this.DataContext = vm;
                }
            }
        }
    }
}