using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

public class Sample01
{
    public static (Task<object>, string) OnClick()
    {
        string code = "1 + 2";
        var result = CSharpScript.EvaluateAsync(code);
        return (result, code);
    }
}