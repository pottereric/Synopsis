using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synopsis
{
    public class SyntaxAnalyzer
    {
        private string _code;

        public SyntaxAnalyzer(string code)
        {
            this._code = code;
        }

        private SyntaxTree _tree;

        public SyntaxTree Tree
        {
            get
            {
                if (_tree == null)
                {
                    _tree = SyntaxTree.ParseText(_code);
                }
                return _tree;
            }
        }

        private CompilationUnitSyntax _root;

        public CompilationUnitSyntax Root
        {
            get
            {
                if(_root == null)
                {
                    _root = Tree.GetRoot() as CompilationUnitSyntax;
                }
                return _root;
            }
        }

        private MemberDeclarationSyntax _firstClass;

        public MemberDeclarationSyntax FirstClass
        {
            get
            {
                if (_firstClass == null)
                {

                    // TODO: don't hard code [0]
                    // Get the Namespace node
                    NamespaceDeclarationSyntax namespaceDeclaration = (NamespaceDeclarationSyntax)Root.Members[0];

                    // Get the class node
                    var classes = namespaceDeclaration.Members;
                    _firstClass = classes.First();
                }
                return _firstClass;
            }
        }

        private IEnumerable<MethodDeclarationSyntax> _methodNodes;

        public IEnumerable<MethodDeclarationSyntax> MethodNodes
        {
            get
            {
                if (_methodNodes == null)
                {
                    _methodNodes = Root.DescendantNodes().OfType<MethodDeclarationSyntax>();
                }
                return _methodNodes;
            }
        }

        private IEnumerable<InvocationExpressionSyntax> _methodCalls;

        public IEnumerable<InvocationExpressionSyntax> MethodCalls
        {
            get
            {
                if (_methodCalls == null)
                {
                    _methodCalls = Root.DescendantNodes().OfType<InvocationExpressionSyntax>();
                }
                return _methodCalls;
            }
        }
	

        private IEnumerable<FieldDeclarationSyntax> _fieldNodes;

        public IEnumerable<FieldDeclarationSyntax> FieldNodes
        {
            get
            {
                if (_fieldNodes == null)
                {
                    var nodes = FirstClass.ChildNodes();
                    //LogNodes(nodes);
                    _fieldNodes = nodes.Where(sn => sn is FieldDeclarationSyntax).Select(sn => sn as FieldDeclarationSyntax);
                }
                return _fieldNodes;
            }
        }


        private IEnumerable<PropertyDeclarationSyntax> _propertyNodes;

        public IEnumerable<PropertyDeclarationSyntax> PropertyNodes
        {
            get
            {
                if (_propertyNodes == null)
                {
                    var nodes = FirstClass.ChildNodes();
                    //LogNodes(nodes);
                    _propertyNodes = nodes.Where(sn => sn is PropertyDeclarationSyntax).Select(sn => sn as PropertyDeclarationSyntax);
                }
                return _propertyNodes;
            }
        }


        private IEnumerable<ConstructorDeclarationSyntax> _constructorNodes;

        public IEnumerable<ConstructorDeclarationSyntax> ConstructorNodes
        {
            get
            {
                if (_constructorNodes == null)
                {
                    var nodes = FirstClass.ChildNodes();
                    //LogNodes(nodes);
                    _constructorNodes = nodes.Where(sn => sn is ConstructorDeclarationSyntax).Select(sn => sn as ConstructorDeclarationSyntax);
                }
                return _constructorNodes;
            }
        }




        [System.Diagnostics.Conditional("DEBUG")]
        private void LogNodes(IEnumerable<SyntaxNode> nodes)
        {
            foreach (var node in nodes)
            {
                System.Diagnostics.Debug.WriteLine(node.ToString());
            }
        }
    }
}
