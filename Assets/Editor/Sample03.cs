using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

public class Sample03
{
    public static (Task<int>, string, Globals) OnClick()
    {
        string code = "X+Y";
        var globals = new Globals {X = 1, Y = 2};
        var result = CSharpScript.EvaluateAsync<int>(code, globals: globals);
        return (result, code, globals);
    }

    public class Globals
    {
        public int X;
        public int Y;

        public override string ToString()
        {
            return $"{{X = {X}, Y = {Y}}}";
        }
    }
}