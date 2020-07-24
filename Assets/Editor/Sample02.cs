using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

public class Sample02
{
    public static (Task<int>, string) OnClick()
    {
        string code = "1 + 2";
        var result = CSharpScript.EvaluateAsync<int>(code);
        return (result, code);
    }
}