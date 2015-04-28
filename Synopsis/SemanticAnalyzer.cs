using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
//using Roslyn.Compilers;
//using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synopsis
{
    public class SemanticAnalyzer : SyntaxAnalyzer
    {
        public SemanticAnalyzer(string code)
            :base(code)
        {
        }


        private MetadataReference _mscorlib; // = MetadataReference.CreateAssemblyReference( "mscorlib");

        private Compilation _compliation;
        protected Compilation Compilation
        {
            get
            {
                if (_compliation == null)
                {
                    _mscorlib = new MetadataFileReference(typeof(object).Assembly.Location);

                    _compliation = CSharpCompilation.Create("HelloWorld")
                        .AddReferences(_mscorlib)
                        .AddSyntaxTrees(Tree);
                }
                return _compliation;
            }

        }

        private SemanticModel _semanticModel;
        protected SemanticModel SematicModel
        {
            get
            {
                if (_semanticModel == null)
                {
                    _semanticModel = Compilation.GetSemanticModel(Tree);
                }
                return _semanticModel;
            }
        }
    }
}
