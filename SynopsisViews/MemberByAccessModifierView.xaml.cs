//using EnvDTE;
using Synopsis.SynopsisVSPkg.ViewModels;
using System.Windows.Controls;

namespace Synopsis.SynopsisVSPkg
{
    /// <summary>
    /// Interaction logic for MemberByAccessModifierView.xaml
    /// </summary>
    public partial class MemberByAccessModifierView : UserControl
    {
        public MemberByAccessModifierView()
        {
            InitializeComponent();

            var vm = new MemberByAccessModifierViewModel();
            this.DataContext = vm;
        }

        //private SynopsisVSPkgPackage _package;

        //public SynopsisVSPkgPackage Package
        //{
        //    get { return _package; }
        //    set
        //    {
        //        _package = value;
        //        var document = _package.IDE.ActiveDocument;

        //        if (document != null)
        //        {
        //            var textDocument = (TextDocument)document.Object("TextDocument");
        //            var fullText = textDocument.StartPoint.CreateEditPoint().GetText(textDocument.EndPoint);

        //            var vm = new MemberByAccessModifierViewModel();
        //            vm.SetDocument(fullText);
        //            this.DataContext = vm;
        //        }
        //    }
        //}

        private string _fileText;
        public string FileText
        {
            get
            {
                return _fileText;
            }
            set
            {
                _fileText = value;

                var vm = new MemberByAccessModifierViewModel();
                vm.SetDocument(_fileText);
                this.DataContext = vm;
            }
        }
    }
}