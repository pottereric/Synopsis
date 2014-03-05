using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synopsis.Entities
{
    public class MethodsData
    {
        public IEnumerable<MethodCall> Calls { get; set; }

        public IEnumerable<MethodDefinition> Definitions { get; set; }
    }
}
