using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class RoslynSample : EditorWindow
{
    [MenuItem("Tools/Roslyn Sample")]
    public static void ShowWindow() => GetWindow<RoslynSample>("Roslyn Sample");

    [SerializeField] private string code = string.Empty;
    [SerializeField] private string result = string.Empty;

    private void OnEnable()
    {
        var root = rootVisualElement;
        root.styleSheets.Add(Resources.Load<StyleSheet>("RoslynSample"));
        var visualTree = Resources.Load<VisualTreeAsset>("RoslynSample");
        visualTree.CloneTree(root);
        root.Bind(new SerializedObject(this));

        root.Query<Button>()
            .ForEach(x =>
            {
                if (x.name == "sample01")
                {
                    x.clickable.clicked += async () =>
                    {
                        var (t, c) = Sample01.OnClick();
                        var ret = await t;
                        code = c;
                        result = $"{ret}";
                    };
                }

                if (x.name == "sample02")
                {
                    x.clickable.clicked += async () =>
                    {
                        var (t, c) = Sample02.OnClick();
                        var ret = await t;
                        code = c;
                        result = $"{ret}";
                    };
                }

                if (x.name == "sample03")
                {
                    x.clickable.clicked += async () =>
                    {
                        var (t, c, globals) = Sample03.OnClick();
                        var ret = await t;
                        code = $"{c}, {globals}";
                        result = $"{ret}";
                    };
                }

                if (x.name == "sample04")
                {
                    x.clickable.clicked += () =>
                    {
                        var (ret, c) = Sample04.OnClick();
                        code = c;
                        result = ret;
                    };
                }

                if (x.name == "sample05")
                {
                    x.clickable.clicked += () =>
                    {
                        var (ret, c) = Sample05.OnClick();
                        code = c;
                        result = string.Join("\n", ret.Select(e => e.Name));
                    };
                }
            });
    }
}