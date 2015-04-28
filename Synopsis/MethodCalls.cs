using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Extensions;
using Microsoft.CodeAnalysis.Shared.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
//using Roslyn.Compilers.CSharp;
using Synopsis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Synopsis
{
    public class MethodCalls : SemanticAnalyzer
    {
        public MethodCalls(string code)
            : base(code)
        {
        }

        public MethodsData Analyze()
        {
            var methodDefinitionData = GetMethodDeclarations();

            var methodCallData = GetMethodCalls();

            var data = new MethodsData();
            data.Calls = methodCallData;
            data.Definitions = methodDefinitionData;
            return data;
        }

        private List<MethodCall> GetMethodCalls()
        {
            var methodCallData = new List<MethodCall>();

            foreach (var methodCallSyntax in MethodCalls)
            {
                var callData = new MethodCall();

                var identifier = methodCallSyntax.DescendantNodes().OfType<IdentifierNameSyntax>().First();
                callData.CalledMethodName = identifier.Identifier.ToString();
                callData.CallingLine = methodCallSyntax.GetLocation().GetLineSpan().StartLinePosition.Line;

                var methodCallSymbol = SematicModel.GetSymbolInfo(methodCallSyntax);
                if (methodCallSymbol.Symbol != null)
                {
                    foreach (var location in methodCallSymbol.Symbol.Locations)
                    {
                        if (location.IsInSource)
                        {
                            callData.CalledLine = location.GetLineSpan().StartLinePosition.Line;
                            methodCallData.Add(callData);
                        }
                    }
                }
            }
            return methodCallData;
        }

        private List<MethodDefinition> GetMethodDeclarations()
        {
            var methodDefinitionData = new List<MethodDefinition>();

            foreach (var method in MethodNodes)
            {
                var methodDefData = new MethodDefinition();
                methodDefData.Name = method.Identifier.ToString();
                methodDefData.Line = method.GetLocation().GetLineSpan().StartLinePosition.Line;
                methodDefinitionData.Add(methodDefData);
            }
            return methodDefinitionData;
        }
    }
}