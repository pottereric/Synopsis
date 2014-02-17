using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synopsis.SynopsisVSPkg.ViewModel
{
    public class MembersByAccessModifierViewModel : ViewModelBase
    {
        private string test = "FrankStallone";

        public string Test
        {
            get { return test; }
            set { test = value; }
        }

        public IEnumerable<string> Funcs
        {
            get
            {
                var strings = new List<string>();
                strings.Add("one");
                strings.Add("two");
                strings.Add("three");

                return strings;
            }

        }
    }
}
