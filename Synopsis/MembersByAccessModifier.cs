using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
//using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Synopsis
{
    public class MembersByAccessModifier : SyntaxAnalyzer
    {
        public MembersByAccessModifier(string code)
            : base(code)
        {
        }

        private IEnumerable<string> _publicMethods;

        public IEnumerable<string> PublicMethods
        {
            get
            {
                if (_publicMethods == null)
                {
                    _publicMethods = MethodNodes.Where(mds => mds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PublicKeyword))
                        .Select(mds => mds.Identifier.ToString());
                }
                return _publicMethods;
            }
        }

        private IEnumerable<string> _protectedMethods;

        public IEnumerable<string> ProtectedMethods
        {
            get
            {
                if (_protectedMethods == null)
                {
                    _protectedMethods = MethodNodes.Where(mds => mds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.ProtectedKeyword))
                        .Select(mds => mds.Identifier.ToString());
                }
                return _protectedMethods;
            }
        }

        private IEnumerable<string> _privateMethods;

        public IEnumerable<string> PrivateMethods
        {
            get
            {
                if (_privateMethods == null)
                {
                    _privateMethods = MethodNodes.Where(mds => mds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PrivateKeyword))
                        .Select(mds => mds.Identifier.ToString());
                }
                return _privateMethods;
            }
        }

        private IEnumerable<string> _publicFields;

        public IEnumerable<string> PublicFields
        {
            get
            {
                if (_publicFields == null)
                {
                    // TODO, handle the field declarations better.
                    _publicFields = FieldNodes.Where(fds => fds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PublicKeyword)).Select(fds => fds.Declaration.Variables.First().Identifier.ToString());
                }
                return _publicFields;
            }
        }

        protected IEnumerable<string> _protectedFields;

        public IEnumerable<string> ProtectedFields
        {
            get
            {
                if (_protectedFields == null)
                {
                    _protectedFields = FieldNodes.Where(fds => fds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.ProtectedKeyword)).Select(fds => fds.Declaration.Variables.First().Identifier.ToString());
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
                    // TODO, handle the field declarations better.
                    _privateFields = FieldNodes.Where(fds => fds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PrivateKeyword)).Select(fds => fds.Declaration.Variables.First().Identifier.ToString());
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
                    _publicProperties = PropertyNodes.Where(pds => pds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PublicKeyword))
                        .Select(mds => mds.Identifier.ToString());
                }
                return _publicProperties;
            }
        }

        private IEnumerable<string> _protectedProperties;

        public IEnumerable<string> ProtectedProperties
        {
            get
            {
                if (_protectedProperties == null)
                {
                    _protectedProperties = PropertyNodes.Where(pds => pds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.ProtectedKeyword))
                        .Select(mds => mds.Identifier.ToString());
                }
                return _protectedProperties;
            }
        }

        private IEnumerable<string> _privateProperties;

        public IEnumerable<string> PrivateProperties
        {
            get
            {
                if (_privateProperties == null)
                {
                    _privateProperties = PropertyNodes.Where(pds => pds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PrivateKeyword))
                        .Select(mds => mds.Identifier.ToString());
                }
                return _privateProperties;
            }
        }

        private IEnumerable<string> _publicConstructors;

        public IEnumerable<string> PublicConstructors
        {
            get
            {
                if (_publicConstructors == null)
                {
                    _publicConstructors = ConstructorNodes.Where(cds => cds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PublicKeyword)).Select(cds => cds.Identifier.ToString());
                }
                return _publicConstructors;
            }
        }

        private IEnumerable<string> _protectedConstructors;

        public IEnumerable<string> ProtectedConstructors
        {
            get
            {
                if (_protectedConstructors == null)
                {
                    _protectedConstructors = ConstructorNodes.Where(cds => cds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.ProtectedKeyword)).Select(cds => cds.Identifier.ToString());
                }
                return _protectedConstructors;
            }
        }

        private IEnumerable<string> _privateConstructors;

        public IEnumerable<string> PrivateConstructors
        {
            get
            {
                if (_privateConstructors == null)
                {
                    _privateConstructors = ConstructorNodes.Where(cds => cds.Modifiers.Any(m => m.CSharpKind() == SyntaxKind.PrivateKeyword)).Select(cds => cds.Identifier.ToString());
                }
                return _privateConstructors;
            }
        }
    }
}