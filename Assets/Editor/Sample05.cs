using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class Sample05
{
    public static (List<UsingDirectiveSyntax>, string) OnClick()
    {
        string code =
            @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
 
namespace TopLevel
{
    using Microsoft;
    using System.ComponentModel;
 
    namespace Child1
    {
        using Microsoft.Win32;
        using System.Runtime.InteropServices;
 
        class Foo { }
    }
 
    namespace Child2
    {
        using System.CodeDom;
        using Microsoft.CSharp;
 
        class Bar { }
    }
}";

        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        var root = (CompilationUnitSyntax) tree.GetRoot();

        var collector = new UsingCollector();
        collector.Visit(root);

        return (collector.Usings, code);
    }

    class UsingCollector : CSharpSyntaxWalker
    {
        public readonly List<UsingDirectiveSyntax> Usings = new List<UsingDirectiveSyntax>();

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            if (node.Name.ToString() != "System" &&
                !node.Name.ToString().StartsWith("System."))
            {
                this.Usings.Add(node);
            }
        }
    }
}