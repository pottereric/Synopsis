//using EnvDTE;
//using EnvDTE80;
//using Microsoft.VisualStudio.Shell;
//using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;

namespace Synopsis.SynopsisVSPkg.ViewModels
{
    public class MemberByAccessModifierViewModel : BaseViewModel
    {
        private MembersByAccessModifier analyzer;

        public MemberByAccessModifierViewModel()
        {
        }

        public void SetDocument(string document)
        {
            if (!String.IsNullOrWhiteSpace(document))
            {
                analyzer = new MembersByAccessModifier(document);
            }
        }

        public IEnumerable<string> PublicConstructors
        {
            get
            {
                return analyzer != null ? analyzer.PublicConstructors : null;
            }
        }

        public IEnumerable<string> ProtectedConstructors
        {
            get
            {
                return analyzer != null ? analyzer.ProtectedConstructors : null;
            }
        }

        public IEnumerable<string> PrivateConstructors
        {
            get
            {
                return analyzer != null ? analyzer.PrivateConstructors : null;
            }
        }

        public IEnumerable<string> PublicMethods
        {
            get
            {
                return analyzer != null ? analyzer.PublicMethods : null;
            }
        }

        public IEnumerable<string> ProtectedMethods
        {
            get
            {
                return analyzer != null ? analyzer.ProtectedMethods : null;
            }
        }

        public IEnumerable<string> PrivateMethods
        {
            get
            {
                return analyzer != null ? analyzer.PrivateMethods : null;
            }
        }

        public IEnumerable<string> PublicProperties
        {
            get
            {
                return analyzer != null ? analyzer.PublicProperties : null;
            }
        }

        public IEnumerable<string> ProtectedProperties
        {
            get
            {
                return analyzer != null ? analyzer.ProtectedProperties : null;
            }
        }

        public IEnumerable<string> PrivateProperties
        {
            get
            {
                return analyzer != null ? analyzer.PrivateProperties : null;
            }
        }

        public IEnumerable<string> PublicFields
        {
            get
            {
                return analyzer != null ? analyzer.PublicFields : null;
            }
        }

        public IEnumerable<string> ProtectedFields
        {
            get
            {
                return analyzer != null ? analyzer.ProtectedFields : null;
            }
        }

        public IEnumerable<string> PrivateFields
        {
            get
            {
                return analyzer != null ? analyzer.PrivateFields : null;
            }
        }

        //public IEnumerable<string> PublicEvents
        //{
        //    get
        //    {
        //        return analyzer != null ? analyzer.PublicEvents : null;
        //    }
        //}

        //public IEnumerable<string> ProtectedEvents
        //{
        //    get
        //    {
        //        return analyzer != null ? analyzer.ProtectedEvents : null;
        //    }
        //}

        //public IEnumerable<string> PrivateEvents
        //{
        //    get
        //    {
        //        return analyzer != null ? analyzer.PrivateEvents : null;
        //    }
        //}
    }
}