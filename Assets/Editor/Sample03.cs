using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

public class Sample03
{
    public static Task<int> OnClick(out string code, out Globals globals)
    {
        code = "X+Y";
        globals = new Globals {X = 1, Y = 2};
        return CSharpScript.EvaluateAsync<int>(code, globals: globals);
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