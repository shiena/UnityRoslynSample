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
    [SerializeField] private VisualTreeAsset visualTree;
    [SerializeField] private StyleSheet styleSheet;

    private void CreateGUI()
    {
        var root = rootVisualElement;
        root.styleSheets.Add(styleSheet);
        visualTree.CloneTree(root);
        root.Bind(new SerializedObject(this));

        root.Q<Button>("sample01").clicked += async () =>
        {
            var ret = await Sample01.OnClick(out code);
            result = $"{ret}";
        };

        root.Q<Button>("sample02").clicked += async () =>
        {
            var ret = await Sample02.OnClick(out code);
            result = $"{ret}";
        };

        root.Q<Button>("sample03").clicked += async () =>
        {
            var ret = await Sample03.OnClick(out var c, out var globals);
            code = $"{c}, {globals}";
            result = $"{ret}";
        };

        root.Q<Button>("sample04").clicked += () =>
        {
            result = Sample04.OnClick(out code);
        };

        root.Q<Button>("sample05").clicked += () =>
        {
            var ret = Sample05.OnClick(out code);
            result = string.Join("\n", ret.Select(e => e.Name));
        };
    }
}