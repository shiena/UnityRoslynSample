using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class Sample04
{
    public static (string, string) OnClick()
    {
        string code =
            @"using System;
using System.Collections;
using System.Linq;
using System.Text;
 
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}";
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);

        var root = (CompilationUnitSyntax) tree.GetRoot();
        var firstMember = root.Members[0];
        var helloWorldDeclaration = (NamespaceDeclarationSyntax) firstMember;
        var programDeclaration = (ClassDeclarationSyntax) helloWorldDeclaration.Members[0];
        var mainDeclaration = (MethodDeclarationSyntax) programDeclaration.Members[0];
        var argsParameter = mainDeclaration.ParameterList.Parameters[0];
        var firstParameters = from methodDeclaration in root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
            where methodDeclaration.Identifier.ValueText == "Main"
            select methodDeclaration.ParameterList.Parameters.First();
        var argsParameter2 = firstParameters.Single();

        return (argsParameter2.ToString(), code);
    }
}