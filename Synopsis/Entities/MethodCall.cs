using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synopsis.Entities
{
    public class MethodCall
    {
        public string CalledMethodName { get; set; }
        public int CallingLine { get; set; }
        public int CalledLine { get; set; }
    }
}
