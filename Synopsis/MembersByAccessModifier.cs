using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Synopsis
{
    public class MembersByAccessModifier
    {
        private string _code;

        public MembersByAccessModifier(string code)
        {
            _code = code;
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

        private MemberDeclarationSyntax _firstClass;

        public MemberDeclarationSyntax FirstClass
        {
            get
            {
                if (_firstClass == null)
                {
                    CompilationUnitSyntax compilationUnit = (CompilationUnitSyntax)Tree.GetRoot();

                    // TODO: don't hard code [0]
                    // Get the Namespace node
                    NamespaceDeclarationSyntax namespaceDeclaration = (NamespaceDeclarationSyntax)compilationUnit.Members[0];

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
                    var nodes = FirstClass.ChildNodes();
                    //LogNodes(nodes);
                    _methodNodes = nodes.Where(sn => sn is MethodDeclarationSyntax).Select(sn => sn as MethodDeclarationSyntax);
                }
                return _methodNodes;
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

        private IEnumerable<string> _publicMethods;

        public IEnumerable<string> PublicMethods
        {
            get
            {
                if (_publicMethods == null)
                {
                    _publicMethods = MethodNodes.Where(mds => mds.Modifiers.Any(SyntaxKind.PublicKeyword)).Select(mds => mds.ToString());
                }
                return _publicMethods;
            }
        }

        private IEnumerable<string> _privateMethods;

        public IEnumerable<string> PrivateMethods
        {
            get
            {
                if (_privateMethods == null)
                {
                    _privateMethods = MethodNodes.Where(mds => mds.Modifiers.Any(SyntaxKind.PrivateKeyword)).Select(mds => mds.ToString());
                }
                return _privateMethods;
            }
        }


        protected IEnumerable<string> _protectedFields;

        public IEnumerable<string> ProtectedFields
        {
            get
            {
                if (_protectedFields == null)
                {
                    _protectedFields =  FieldNodes.Where(mds => mds.Modifiers.Any(SyntaxKind.ProtectedKeyword)).Select(mds => mds.ToString());
                }
                return _protectedFields;
            }
        }

        private IEnumerable<string> _privateFields;

        public IEnumerable<string> PrivateFields
        {
            get
            {
                if (_privateFields == null)
                {
                    _privateFields =  FieldNodes.Where(mds => mds.Modifiers.Any(SyntaxKind.PrivateKeyword)).Select(mds => mds.ToString());
                }
                return _privateFields;
            }
        }

        private IEnumerable<string> _publicProperties;

        public IEnumerable<string> PublicProperties
        {
            get
            {
                if (_publicProperties == null)
                {
                    _publicProperties = PropertyNodes.Where(mds => mds.Modifiers.Any(SyntaxKind.PublicKeyword)).Select(mds => mds.ToString());
                }
                return _publicProperties;
            }
        }


        private IEnumerable<string> _publicConstructors;

        public IEnumerable<string> PublicConstructors
        {
            get
            {
                if (_publicConstructors == null)
                {
                    _publicConstructors = ConstructorNodes.Where(mds => mds.Modifiers.Any(SyntaxKind.PublicKeyword)).Select(mds => mds.ToString());
                }
                return _publicConstructors;
            }
        }


    }
}