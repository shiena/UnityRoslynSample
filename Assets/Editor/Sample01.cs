using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

public class Sample01
{
    public static Task<object> OnClick(out string code)
    {
        code = "1 + 2";
        return CSharpScript.EvaluateAsync(code);
    }
}