//using EnvDTE;
//using EnvDTE80;
//using Microsoft.VisualStudio.Shell;
//using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synopsis.SynopsisVSPkg.ViewModels
{
    public class MemberByAccessModifierViewModel : BaseViewModel
    {
        private MembersByAccessModifier analyzer;



        public MemberByAccessModifierViewModel()
        {
            // TODO - remove
            //analyzer = new MembersByAccessModifier(FileReader.Read(@"H:\Projects\VelociRead\VelociRead\ViewModel\MainViewModel.cs"));
            analyzer = new MembersByAccessModifier(FileReader.Read(@"C:\SampleCode\Euler9.cs"));
        }

        public void SetDocument(string document)
        {
            analyzer = new MembersByAccessModifier(document);
        }

        public IEnumerable<string> PublicConstructors 
        {
            get
            {
                return analyzer.PublicConstructors;
            }
        }

        public IEnumerable<string> ProtectedConstructors
        {
            get
            {
                return analyzer.ProtectedConstructors;
            }
        }

        public IEnumerable<string> PrivateConstructors
        {
            get
            {
                return analyzer.PrivateConstructors;
            }
        }

        
        public IEnumerable<string> PublicMethods 
        {
            get
            {
                return analyzer.PublicMethods;
            }
        }

        public IEnumerable<string> ProtectedMethods
        {
            get
            {
                return analyzer.ProtectedMethods;
            }
        }

        public IEnumerable<string> PrivateMethods 
        {
            get
            {
                return analyzer.PrivateMethods;
            }
        }

        public IEnumerable<string> PublicProperties 
        {
            get
            {
                return analyzer.PublicProperties;
            }
        }

        public IEnumerable<string> ProtectedProperties
        {
            get
            {
                return analyzer.ProtectedProperties;
            }
        }

        public IEnumerable<string> PrivateProperties
        {
            get
            {
                return analyzer.PrivateProperties;
            }
        }

        public IEnumerable<string> PublicFields
        {
            get
            {
                return analyzer.PublicFields;
            }
        }

        public IEnumerable<string> ProtectedFields 
        {
            get
            {
                return analyzer.ProtectedFields;
            }
        }

        public IEnumerable<string> PrivateFields 
        {
            get
            {
                return analyzer.PrivateFields;
            }
        }

        //public IEnumerable<string> PublicEvents 
        //{
        //    get
        //    {
        //        return analyzer.PublicEvents;
        //    }
        //}

        //public IEnumerable<string> ProtectedEvents 
        //{
        //    get
        //    {
        //        return analyzer.ProtectedEvents;
        //    }
        //}

        //public IEnumerable<string> PrivateEvents 
        //{
        //    get
        //    {
        //        return analyzer.PrivateEvents;
        //    }
        //}

    }
}
