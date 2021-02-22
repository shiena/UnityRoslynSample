using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

public class Sample02
{
    public static Task<int> OnClick(out string code)
    {
        code = "1 + 2";
        return CSharpScript.EvaluateAsync<int>(code);
    }
}